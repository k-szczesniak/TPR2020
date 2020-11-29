﻿using System;

namespace Data
{
    public class Class3
    {
        public Class1 Class1 { get; set; }
        public Class2 Class2 { get; set; }

        public double Number { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public Class3() { }

        public Class3(double number, string text, DateTime dateTime)
        {
            Number = number;
            Text = text;
            DateTime = dateTime;
        }
    }
}
