using System;
using System.Runtime.Serialization;

namespace StringSerializers.Tests
{
	public enum TestEnum
	{
		NegativeOne = -1,
		Zero = 0,
		One = 1
	}

	[Serializable]
	public class ClassWithDate
	{
		public ClassWithDate()
		{
		}

		public ClassWithDate(DateTime date)
		{
			Date = date;
		}

		public DateTime Date { get; set; }
	}

	[Serializable]
	public class ClassWithNullableDate
	{
		public ClassWithNullableDate()
		{
		}

		public ClassWithNullableDate(DateTime? date)
		{
			Date = date;
		}

		public DateTime? Date { get; set; }
	}

	[Serializable]
	public class ClassWithTestEnum
	{
		public TestEnum TestEnum { get; set; }
	}

    public interface ITestSerializedObject
    {
        string Name { get; set; }
    }

    [DataContract(Name = "TestSerializedObject", Namespace = "")]
    public class TestSerializedObject : ITestSerializedObject
    {
        [DataMember]
        public string Name { get; set; }
    }
}
