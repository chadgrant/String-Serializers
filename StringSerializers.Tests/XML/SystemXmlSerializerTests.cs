using System.Collections.Generic;

namespace StringSerializers.Tests.XML
{
    public class SystemXmlSerializerTests : DeserializerTestsBase
    {
        public override IStringDeserializer GetSerializer()
        {
            return new SystemXmlSerializer();
        }

        public override IEnumerable<string> GetTestString()
        {
            yield return "<TestSerializedObject><Name>Unit Tests</Name></TestSerializedObject>";
        }
    }
}
