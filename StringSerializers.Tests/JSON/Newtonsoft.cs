using Xunit;

namespace StringSerializers.Tests.JSON
{
	public class NewtonsoftJsonSerializerTestsBase : JsonSerializerTestsBase
	{
		public override IStringSerializer GetSerializer()
		{
			return new NewtonsoftJsonSerializer();
		}
        
		[Theory,
		InlineData(TestEnum.NegativeOne, "NegativeOne"), 
		InlineData(TestEnum.One, "One"), 
		InlineData(TestEnum.Zero, "Zero")]
		public void Serializer_Enum_Should_Be_String_Value(TestEnum value, string valueString)
		{
			var serializer = GetSerializer();

			var obj = new ClassWithTestEnum()
			{
				TestEnum = value
			};

			var json = serializer.Serialize(obj);

			Assert.Contains(valueString,json);
		}
	}

	public class NewtonsoftJsonDeserializerTestsBase : JsonDeserializerTestsBase
	{
		public override IStringDeserializer GetSerializer()
		{
			return new NewtonsoftJsonSerializer();
		}
	}
}
