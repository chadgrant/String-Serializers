using System;
using System.IO;
using System.Text;

namespace StringSerializers
{
	public interface IStringSerializer : ISerializer
	{
        string NullValue { get; }

        void Serialize(TextWriter writer, object obj, Type type);

        string Serialize<T>(T obj)
        {
            return Serialize(obj, typeof(T));
        }

        void Serialize<T>(TextWriter writer, T obj)
        {
            Serialize(writer, obj, typeof(T));
        }

        string Serialize(object obj, Type type)
        {
            using (var writer = new StringWriter(new StringBuilder()))
            {
                Serialize(writer, obj, type);
                return writer.ToString();
            }
        }

        void Serialize(TextWriter writer, object obj)
        {
            if (obj == null) return;

            Serialize(writer, obj, obj.GetType());
        }

        string Serialize(object obj)
        {
            if (obj == null)
                return NullValue;

            return Serialize(obj, obj.GetType());
        }

        bool TrySerialize(object obj, out string result)
        {
            result = default;
            if (obj == null)
                return false;

            return TrySerialize(obj, obj.GetType(), out result);
        }

        bool TrySerialize(object obj, Type type, out string result)
        {
            result = default;

            if (obj == null)
                return false;

            try
            {
                result = Serialize(obj, type);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
