using System;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    public class Class2 : ISerializable
    {
        public Class1 Class1 { get; set; }
        public Class3 Class3 { get; set; }
        public double Number { get; set; }
        public bool BooleanValue { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
    
        public Class2() { }

        public Class2(double number, bool booleanValue, string text, DateTime dateTime)
        {
            Number = number;
            BooleanValue = booleanValue;
            Text = text;
            DateTime = dateTime;
        }

        public Class2(SerializationInfo info, StreamingContext context)
        {
            Class1 = (Class1)info.GetValue("Class1", typeof(Class1));
            Class3 = (Class3)info.GetValue("Class3", typeof(Class3));
            Number = (double)info.GetValue("Number", typeof(double));
            BooleanValue = (bool)info.GetValue("BooleanValue", typeof(bool));
            Text = (string)info.GetValue("Text", typeof(string));
            DateTime = (DateTime)info.GetValue("DateTime", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Class1", Class1, typeof(Class1));
            info.AddValue("Class3", Class3, typeof(Class3));
            info.AddValue("Number", Number, typeof(double));
            info.AddValue("BooleanValue", BooleanValue, typeof(bool));
            info.AddValue("Text", Text, typeof(string));
            info.AddValue("DateTime", DateTime, typeof(DateTime));
        }
    }
}
