using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StringSerializers.Tests
{
	/// <summary>
	/// Simple tests Test Text should always deserialize an object.
	/// With a Property Name that Equals "Unit Tests"
	/// </summary>
	public abstract class DeserializerTestsBase
	{
		public abstract IStringDeserializer GetSerializer();

		public abstract IEnumerable<string> GetTestString();

		[Fact]
		public void Serializer_Should_Deserialize()
		{
			var serializer = GetSerializer();

            foreach(var str in GetTestString())
            {
                Assert.False(string.IsNullOrWhiteSpace(str));

                var deserialized = serializer.Deserialize<TestSerializedObject>(str);

                Assert.NotNull(deserialized);
                Assert.Equal("Unit Tests", deserialized.Name);
            }
        }

        [Fact(Skip = "Manual Run")]
        public void Deserialize_SpeedTest()
        {
            var max = 1000000;
            var serializer = GetSerializer();
            var str = GetTestString().First();

            for (var i = 0; i < max; i++)
            {
                serializer.Deserialize<TestSerializedObject>(str);
            }
        }
    }
}
