using System;
using System.Collections.Concurrent;
using System.IO;
using System.Xml.Serialization;

namespace StringSerializers
{
    public class SystemXmlSerializer : IStringSerializer, IStringDeserializer
    {
        static readonly ConcurrentDictionary<Type,XmlSerializer> SerializerCache = new ConcurrentDictionary<Type, XmlSerializer>();

        public string FormatName { get; } = "XML";
        public string NullValue { get; } = "";

        public void Serialize(TextWriter writer, object obj, Type type)
        {
            GetSerializer(type).Serialize(writer, obj);
        }

        public object Deserialize(TextReader reader, Type type)
        {
            return GetSerializer(type).Deserialize(reader);
        }

        protected virtual XmlSerializer GetSerializer(Type type)
        {
            return SerializerCache.GetOrAdd(type, t => new XmlSerializer(t));
        }
    }
}
