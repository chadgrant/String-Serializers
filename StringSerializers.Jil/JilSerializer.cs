using System;
using System.IO;
using Jil;

namespace StringSerializers.Jil
{
	public class JilSerializer : IStringDeserializer, IStringSerializer
	{
		public static Options DefaultSettings = new Options(
			excludeNulls: true, 
			includeInherited: true, 
			dateFormat: DateTimeFormat.ISO8601,
			unspecifiedDateTimeKindBehavior: UnspecifiedDateTimeKindBehavior.IsUTC//,
			//serializationNameFormat: SerializationNameFormat.CamelCase
		);

        readonly Options _settings;

		public JilSerializer(Options settings) 
		{
			_settings = settings;
		}

		public JilSerializer() : this(DefaultSettings)
		{
		}

        public string FormatName { get; } = "JSON";
        public string NullValue { get; } = "null";

		public T Deserialize<T>(string str)
		{
			return JSON.Deserialize<T>(str, _settings);
		}

		public object Deserialize(TextReader reader, Type type)
		{
			return JSON.Deserialize(reader, type, _settings);
		}

		public object Deserialize(string str, Type type)
		{
			return JSON.Deserialize(str, type, _settings);
		}

        public void Serialize<T>(TextWriter writer, T obj)
		{
			JSON.Serialize(obj, writer, _settings);
		}

		public void Serialize(TextWriter writer, object obj)
		{
			JSON.Serialize(obj, writer, _settings);
		}

		public void Serialize(TextWriter writer, object obj, Type type)
        {
            JSON.Serialize(obj, writer, _settings);
        }

        public string Serialize(object obj, Type type)
		{
			return JSON.Serialize(obj, _settings);
		}
	}
}
