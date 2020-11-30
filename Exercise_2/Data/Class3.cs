using System;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
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

        public Class3(SerializationInfo info, StreamingContext context)
        {
            Class1 = (Class1)info.GetValue("Class1", typeof(Class1));
            Class2 = (Class2)info.GetValue("Class2", typeof(Class2));
            Number = (double)info.GetValue("Number", typeof(double));
            BooleanValue = (bool)info.GetValue("BooleanValue", typeof(bool));
            Text = (string)info.GetValue("Text", typeof(string));
            DateTime = (DateTime)info.GetValue("DateTime", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class1", Class1, typeof(Class1));
            info.AddValue("Class2", Class2, typeof(Class2));
            info.AddValue("Number", Number, typeof(double));
            info.AddValue("BooleanValue", BooleanValue, typeof(bool));
            info.AddValue("Text", Text, typeof(string));
            info.AddValue("DateTime", DateTime, typeof(DateTime));
        }
    }
}
