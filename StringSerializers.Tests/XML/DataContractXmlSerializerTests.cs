using System.Collections.Generic;

namespace StringSerializers.Tests.XML
{
    public class DataContractXmlSerializerTests : DeserializerTestsBase
    {
        public override IStringDeserializer GetSerializer()
        {
            return new DataContractXmlSerializer();
        }

        public override IEnumerable<string> GetTestString()
        {
            yield return "<TestSerializedObject><Name>Unit Tests</Name></TestSerializedObject>";
        }
    }
}
