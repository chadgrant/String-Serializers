using System;
using System.IO;

namespace StringSerializers
{
	public interface IStringDeserializer : ISerializer
    { 
		object Deserialize(TextReader reader, Type type);

        T Deserialize<T>(string str)
        {
            return (T)Deserialize(str, typeof(T));
        }

        object Deserialize(string str, Type type)
        {
            using (var reader = new StringReader(str))
                return Deserialize(reader, type);
        }

        T Deserialize<T>(TextReader reader)
        {
            return (T)Deserialize(reader, typeof(T));
        }

        bool TryDeserialize<T>(string str, out T result)
        {
            result = default;

            if (string.IsNullOrWhiteSpace(str))
                return false;

            try
            {
                result = Deserialize<T>(str);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool TryDeserialize(string str, Type type, out object result)
        {
            result = default;

            if (string.IsNullOrWhiteSpace(str))
                return false;

            try
            {
                result = Deserialize(str, type);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool TryDeserialize<T>(TextReader reader, out T result)
        {
            result = default;

            try
            {
                result = Deserialize<T>(reader);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool TryDeserialize(TextReader reader, Type type, out object result)
        {
            result = default;

            try
            {
                result = Deserialize(reader, type);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
