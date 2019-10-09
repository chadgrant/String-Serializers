using System.Collections.Generic;

namespace StringSerializers.Tests.YAML
{
    public class YamlDotNetYamlDeserializerTests : DeserializerTestsBase
    {
        public override IStringDeserializer GetSerializer()
        {
            return new YamlDotNetStringSerializer();
        }

        public override IEnumerable<string> GetTestString()
        {
            yield return "Name: Unit Tests";
        }
    }

    public class YamlDotNetYamlSerializerTests : SerializerTestsBase
    {
        public override IStringSerializer GetSerializer()
        {
            return new YamlDotNetStringSerializer();
        }
    }
}
