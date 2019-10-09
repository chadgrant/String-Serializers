using StringSerializers.Jil;

namespace StringSerializers.Tests.JSON
{
	public class JilJsonSerializerTestsBase : JsonSerializerTestsBase
	{
		public override IStringSerializer GetSerializer()
		{
			return new JilSerializer();
		}
	}

	public class JilJsonDeserializerTestsBase : JsonDeserializerTestsBase
	{
		public override IStringDeserializer GetSerializer()
		{
			return new JilSerializer();
		}
	}
}
