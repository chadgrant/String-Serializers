using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace StringSerializers
{
    public class DataContractXmlSerializer : IStringSerializer, IStringDeserializer
    {
        static readonly ConcurrentDictionary<Type, DataContractSerializer> SerializerCache = new ConcurrentDictionary<Type, DataContractSerializer>();

        public string FormatName { get; } = "XML";
        public string NullValue { get; } = "";

        public void Serialize(TextWriter writer, object obj, Type type)
        {
            using (var xmlWriter = XmlWriter.Create(writer))
                GetSerializer(type).WriteObject(xmlWriter, obj);
        }

        public object Deserialize(TextReader reader, Type type)
        {
            using (var xmlReader = XmlReader.Create(reader))
                return GetSerializer(type).ReadObject(xmlReader);
        }

        protected virtual DataContractSerializer GetSerializer(Type type)
        {
            return SerializerCache.GetOrAdd(type, t => new DataContractSerializer(t));
        }
    }
}
