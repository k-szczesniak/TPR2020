using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System;
using System.IO;

namespace SerializationTests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void GraphSerializationTestMethod_class1()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class1 testClass1;

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph1Test.txt", FileMode.Create))
            {
                OurSerializer ourSerializer = new OurSerializer();
                ourSerializer.Serialize(fileStream, class1);
            }

            using (FileStream fileStream = new FileStream("serializationGraph1Test.txt", FileMode.Open))
            {
                OurSerializer ourSerializer = new OurSerializer();
                testClass1 = (Class1)ourSerializer.Deserialize(fileStream);
            }

            Assert.IsNotNull(testClass1);
            Assert.AreNotSame(class1, testClass1);

            Assert.AreEqual(class1.Number, testClass1.Number);
            Assert.AreEqual(class1.DateTime, testClass1.DateTime);
            Assert.AreEqual(class1.Text, testClass1.Text);
            Assert.AreEqual(class1.BooleanValue, testClass1.BooleanValue);

            Assert.AreEqual(class1.Class2.Number, testClass1.Class2.Number);
            Assert.AreEqual(class1.Class2.DateTime, testClass1.Class2.DateTime);
            Assert.AreEqual(class1.Class2.Text, testClass1.Class2.Text);
            Assert.AreEqual(class1.Class2.BooleanValue, testClass1.Class2.BooleanValue);

            Assert.AreEqual(class1.Class3.Number, testClass1.Class3.Number);
            Assert.AreEqual(class1.Class3.DateTime, testClass1.Class3.DateTime);
            Assert.AreEqual(class1.Class3.Text, testClass1.Class3.Text);
            Assert.AreEqual(class1.Class3.BooleanValue, testClass1.Class3.BooleanValue);
        }

        [TestMethod]
        public void GraphSerializationTestMethod_class2()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class2 testClass2;

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph2Test.txt", FileMode.Create))
            {
                OurSerializer ourSerializer = new OurSerializer();
                ourSerializer.Serialize(fileStream, class2);
            }

            using (FileStream fileStream = new FileStream("serializationGraph2Test.txt", FileMode.Open))
            {
                OurSerializer ourSerializer = new OurSerializer();
                testClass2 = (Class2)ourSerializer.Deserialize(fileStream);
            }

            Assert.IsNotNull(testClass2);
            Assert.AreNotSame(class2, testClass2);

            Assert.AreEqual(class2.Number, testClass2.Number);
            Assert.AreEqual(class2.DateTime, testClass2.DateTime);
            Assert.AreEqual(class2.Text, testClass2.Text);
            Assert.AreEqual(class2.BooleanValue, testClass2.BooleanValue);

            Assert.AreEqual(class2.Class1.Number, testClass2.Class1.Number);
            Assert.AreEqual(class2.Class1.DateTime, testClass2.Class1.DateTime);
            Assert.AreEqual(class2.Class1.Text, testClass2.Class1.Text);
            Assert.AreEqual(class2.Class1.BooleanValue, testClass2.Class1.BooleanValue);

            Assert.AreEqual(class2.Class3.Number, testClass2.Class3.Number);
            Assert.AreEqual(class2.Class3.DateTime, testClass2.Class3.DateTime);
            Assert.AreEqual(class2.Class3.Text, testClass2.Class3.Text);
            Assert.AreEqual(class2.Class3.BooleanValue, testClass2.Class3.BooleanValue);
        }

        [TestMethod]
        public void GraphSerializationTestMethod_class3()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class3 testClass3;

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph3Test.txt", FileMode.Create))
            {
                OurSerializer ourSerializer = new OurSerializer();
                ourSerializer.Serialize(fileStream, class3);
            }

            using (FileStream fileStream = new FileStream("serializationGraph3Test.txt", FileMode.Open))
            {
                OurSerializer ourSerializer = new OurSerializer();
                testClass3 = (Class3)ourSerializer.Deserialize(fileStream);
            }

            Assert.IsNotNull(testClass3);
            Assert.AreNotSame(class3, testClass3);

            Assert.AreEqual(class3.Number, testClass3.Number);
            Assert.AreEqual(class3.DateTime, testClass3.DateTime);
            Assert.AreEqual(class3.Text, testClass3.Text);
            Assert.AreEqual(class3.BooleanValue, testClass3.BooleanValue);

            Assert.AreEqual(class3.Class1.Number, testClass3.Class1.Number);
            Assert.AreEqual(class3.Class1.DateTime, testClass3.Class1.DateTime);
            Assert.AreEqual(class3.Class1.Text, testClass3.Class1.Text);
            Assert.AreEqual(class3.Class1.BooleanValue, testClass3.Class1.BooleanValue);

            Assert.AreEqual(class3.Class2.Number, testClass3.Class2.Number);
            Assert.AreEqual(class3.Class2.DateTime, testClass3.Class2.DateTime);
            Assert.AreEqual(class3.Class2.Text, testClass3.Class2.Text);
            Assert.AreEqual(class3.Class2.BooleanValue, testClass3.Class2.BooleanValue);
        }
    }
}
