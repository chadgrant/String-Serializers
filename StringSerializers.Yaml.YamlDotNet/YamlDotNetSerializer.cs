using System;
using System.IO;
using YamlDotNet.Serialization;

namespace StringSerializers
{
    public class YamlDotNetStringSerializer : IStringSerializer, IStringDeserializer
    {
        readonly Deserializer _deserializer = new Deserializer();
        readonly Serializer _serializer = new Serializer();

        public string FormatName { get; } = "YAML";
        public string NullValue { get; } = "";

        public object Deserialize(string str, Type type)
        {
            return _deserializer.Deserialize(str, type);
        }

        public object Deserialize(TextReader reader, Type type)
        {
            return _deserializer.Deserialize(reader, type);
        }

        public void Serialize<T>(TextWriter writer, T obj)
        {
            _serializer.Serialize(writer, obj);
        }
        
        public void Serialize(TextWriter writer, object obj, Type type)
        {
            _serializer.Serialize(writer, obj, type);
        }
    }
}
