using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace StringSerializers
{
	public class NewtonsoftJsonSerializer : IStringDeserializer, IStringSerializer
    {
        public static int DefaultBufferSize = 256;

		public static JsonSerializerSettings DefaultSettings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new JsonConverter[] { new StringEnumConverter()},
			DateTimeZoneHandling = DateTimeZoneHandling.Utc,
			CheckAdditionalContent = false
		};

		readonly JsonSerializer _serializer;

		public NewtonsoftJsonSerializer() : this(DefaultSettings)
		{
		}

		public NewtonsoftJsonSerializer(JsonSerializerSettings settings) 
		{
			_serializer = JsonSerializer.CreateDefault(settings);
		}

        public string FormatName { get; } = "JSON";
        public string NullValue { get; } = "null";

        public T Deserialize<T>(TextReader reader)
		{
			using (var jsonReader = new JsonTextReader(reader))
			{
				return (T)_serializer.Deserialize(jsonReader, typeof(T));
			}
		}
		
		public object Deserialize(string str, Type type)
		{
			using (var jsonReader = new JsonTextReader(new StringReader(str)))
			{
				return _serializer.Deserialize(jsonReader, type);
			}
		}

		public object Deserialize(TextReader reader, Type type)
		{
			using (var jsonReader = new JsonTextReader(reader))
			{
				return _serializer.Deserialize(jsonReader, type);
			}
		}

		public string Serialize(object obj, Type type)
		{
			using (var sw = new StringWriter(new StringBuilder(DefaultBufferSize), CultureInfo.InvariantCulture))
			{
				using (var jsonWriter = new JsonTextWriter(sw))
				{
					_serializer.Serialize(jsonWriter, obj, type);
				}
				return sw.ToString();
			}
		}

		public void Serialize<T>(TextWriter writer, T obj)
		{
			using (var jsonWriter = new JsonTextWriter(writer))
			{
				_serializer.Serialize(jsonWriter, obj);
			}
		}

		public void Serialize(TextWriter writer, object obj)
		{
			using (var jsonWriter = new JsonTextWriter(writer))
			{
				_serializer.Serialize(jsonWriter, obj);
			}
		}

		public void Serialize(TextWriter writer, object obj, Type type)
		{
			using (var jsonWriter = new JsonTextWriter(writer))
			{
				_serializer.Serialize(jsonWriter, obj, type);
			}
		}
	}
}
