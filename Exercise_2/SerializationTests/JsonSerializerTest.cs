using Data;
using Exercise_1.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serialization;
using System;
using System.IO;



namespace SerializationTests
{
    [TestClass]
    public class JsonSerializerTest
    {        
        [TestMethod]
        public void DataContextSerializationTestMethod()
        {
            IDataContext dataContext = new DataContext();
            IDataContext deserializedDataContext;
            IFiller filler = new TestFiller();
            filler.Fill(dataContext);

            using (FileStream fileStream = new FileStream("serializationDataContextTest.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, dataContext);                
            }

            using (FileStream fileStream = new FileStream("serializationDataContextTest.json", FileMode.Open))
            {
                deserializedDataContext = JsonSerializer.Deserialize<DataContext>(fileStream);
            }

            Assert.IsNotNull(deserializedDataContext);
            Assert.AreNotSame(dataContext, deserializedDataContext);
            CollectionAssert.AreEqual(dataContext.Users, deserializedDataContext.Users);
            CollectionAssert.AreEqual(dataContext.Catalogs, deserializedDataContext.Catalogs);
            CollectionAssert.AreEqual(dataContext.States, deserializedDataContext.States);
            CollectionAssert.AreEqual(dataContext.Events, deserializedDataContext.Events);
        }

        [TestMethod]
        public void GraphSerializationTestMethod_class1()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class1 class1Deserialized;
            
            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph1Test.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class1);
            }

            using (FileStream fileStream = new FileStream("serializationGraph1Test.json", FileMode.Open))
            {
                class1Deserialized = JsonSerializer.Deserialize<Class1>(fileStream);
            }        

            Assert.IsNotNull(class1Deserialized);
            Assert.AreNotSame(class1, class1Deserialized);

            Assert.AreEqual(class1.Number, class1Deserialized.Number);
            Assert.AreEqual(class1.DateTime, class1Deserialized.DateTime);
            Assert.AreEqual(class1.Text, class1Deserialized.Text);
            Assert.AreEqual(class1.BooleanValue, class1Deserialized.BooleanValue);

            Assert.AreEqual(class1.Class2.Number, class1Deserialized.Class2.Number);
            Assert.AreEqual(class1.Class2.DateTime, class1Deserialized.Class2.DateTime);
            Assert.AreEqual(class1.Class2.Text, class1Deserialized.Class2.Text);
            Assert.AreEqual(class1.Class2.BooleanValue, class1Deserialized.Class2.BooleanValue);

            Assert.AreEqual(class1.Class3.Number, class1Deserialized.Class3.Number);
            Assert.AreEqual(class1.Class3.DateTime, class1Deserialized.Class3.DateTime);
            Assert.AreEqual(class1.Class3.Text, class1Deserialized.Class3.Text);
            Assert.AreEqual(class1.Class3.BooleanValue, class1Deserialized.Class3.BooleanValue);
        }

        [TestMethod]
        public void GraphSerializationTestMethod_class2()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class2 class2Deserialized;

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph2Test.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class2);
            }

            using (FileStream fileStream = new FileStream("serializationGraph2Test.json", FileMode.Open))
            {
                class2Deserialized = JsonSerializer.Deserialize<Class2>(fileStream);
            }

            Assert.IsNotNull(class2Deserialized);
            Assert.AreNotSame(class2, class2Deserialized);

            Assert.AreEqual(class2.Number, class2Deserialized.Number);
            Assert.AreEqual(class2.DateTime, class2Deserialized.DateTime);
            Assert.AreEqual(class2.Text, class2Deserialized.Text);
            Assert.AreEqual(class2.BooleanValue, class2Deserialized.BooleanValue);

            Assert.AreEqual(class2.Class1.Number, class2Deserialized.Class1.Number);
            Assert.AreEqual(class2.Class1.DateTime, class2Deserialized.Class1.DateTime);
            Assert.AreEqual(class2.Class1.Text, class2Deserialized.Class1.Text);
            Assert.AreEqual(class2.Class1.BooleanValue, class2Deserialized.Class1.BooleanValue);

            Assert.AreEqual(class2.Class3.Number, class2Deserialized.Class3.Number);
            Assert.AreEqual(class2.Class3.DateTime, class2Deserialized.Class3.DateTime);
            Assert.AreEqual(class2.Class3.Text, class2Deserialized.Class3.Text);
            Assert.AreEqual(class2.Class3.BooleanValue, class2Deserialized.Class3.BooleanValue);
        }

        [TestMethod]
        public void GraphSerializationTestMethod_class3()
        {
            Class1 class1 = new Class1(1.1, true, "class1", new DateTime(2020, 12, 1, 11, 11, 11));
            Class2 class2 = new Class2(2.0, true, "class2", new DateTime(2020, 12, 2, 12, 12, 12));
            Class3 class3 = new Class3(3.0, true, "class3", new DateTime(2020, 12, 3, 13, 13, 13));
            Class3 class3Deserialized;

            class1.Class2 = class2;
            class1.Class3 = class3;

            class2.Class1 = class1;
            class2.Class3 = class3;

            class3.Class1 = class1;
            class3.Class2 = class2;

            using (FileStream fileStream = new FileStream("serializationGraph3Test.json", FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, class3);
            }

            using (FileStream fileStream = new FileStream("serializationGraph3Test.json", FileMode.Open))
            {
                class3Deserialized = JsonSerializer.Deserialize<Class3>(fileStream);
            }

            Assert.IsNotNull(class3Deserialized);
            Assert.AreNotSame(class3, class3Deserialized);

            Assert.AreEqual(class3.Number, class3Deserialized.Number);
            Assert.AreEqual(class3.DateTime, class3Deserialized.DateTime);
            Assert.AreEqual(class3.Text, class3Deserialized.Text);
            Assert.AreEqual(class3.BooleanValue, class3Deserialized.BooleanValue);

            Assert.AreEqual(class3.Class1.Number, class3Deserialized.Class1.Number);
            Assert.AreEqual(class3.Class1.DateTime, class3Deserialized.Class1.DateTime);
            Assert.AreEqual(class3.Class1.Text, class3Deserialized.Class1.Text);
            Assert.AreEqual(class3.Class1.BooleanValue, class3Deserialized.Class1.BooleanValue);

            Assert.AreEqual(class3.Class2.Number, class3Deserialized.Class2.Number);
            Assert.AreEqual(class3.Class2.DateTime, class3Deserialized.Class2.DateTime);
            Assert.AreEqual(class3.Class2.Text, class3Deserialized.Class2.Text);
            Assert.AreEqual(class3.Class2.BooleanValue, class3Deserialized.Class2.BooleanValue);
        }
    }
}
