using System;
using System.Runtime.Serialization;

namespace Data
{
    public class Class3 : ISerializable
    {
        public Class1 Class1 { get; set; }
        public Class2 Class2 { get; set; }


        public double Number { get; set; }
        public bool BooleanValue { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public Class3() { }

        public Class3(double number, bool booleanValue, string text, DateTime dateTime)
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
