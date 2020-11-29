using System;
using System.Runtime.Serialization;

namespace Data
{
    public class Class1 : ISerializable
    {
        public Class2 Class2 { get; set; }
        public Class3 Class3 { get; set; }

        public double Number { get; set; }
        public bool BooleanValue { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public Class1() { }

        public Class1(double number, bool booleanValue, string text, DateTime dateTime)
        {
            Number = number;
            BooleanValue = booleanValue;
            Text = text;
            DateTime = dateTime;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
