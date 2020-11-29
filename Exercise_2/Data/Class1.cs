using System;

namespace Data
{
    public class Class1
    {
        public Class2 Class2 { get; set; }
        public Class3 Class3 { get; set; }

        public double Number { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public Class1() { }

        public Class1(double number, string text, DateTime dateTime)
        {
            Number = number;
            Text = text;
            DateTime = dateTime;
        }
    }
}
