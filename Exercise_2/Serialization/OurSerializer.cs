using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace Serialization
{
    public class OurSerializer : IFormatter
    {
        public SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public StreamingContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        Type type;
        public void Serialize(Stream serializationStream, object graph)
        {
            type = graph.GetType();

            throw new NotImplementedException();
        }

        public object Deserialize(Stream serializationStream)
        {
            //type;
            throw new NotImplementedException();
        }

        
    }
}
