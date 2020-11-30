using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Serialization
{
    public class JsonSerializer
    {
        private static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore,
        };
        public static void Serialize(Stream serializationStream, object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, JsonSettings);
            serializationStream.Write(Encoding.UTF8.GetBytes(json));
        }

        public static T Deserialize<T>(Stream serializationStream)
        {            
            byte[] bytes = new byte[serializationStream.Length];
            serializationStream.Read(bytes);
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), JsonSettings);
        }


    }
}

