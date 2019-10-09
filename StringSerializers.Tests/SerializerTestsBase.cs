using System;
using Xunit;

namespace StringSerializers.Tests
{
	public abstract class SerializerTestsBase
	{
		public abstract IStringSerializer GetSerializer();

		protected virtual TestSerializedObject GetTestObject()
		{
			return new TestSerializedObject
            {
                Name = "Unit Tests"
            };
		}

		[Fact]
		public void Serializer_Should_Serialize()
		{
			var serializer = GetSerializer();

			var obj = GetTestObject();

			var str = serializer.Serialize(obj);

			Assert.False(String.IsNullOrWhiteSpace(str));
		}
    }
}
