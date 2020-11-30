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
        };
        public static void Serialize(object obj, string filePath)
        {
            File.Delete(filePath);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented, JsonSettings);
            fileStream.Write(Encoding.UTF8.GetBytes(json));
        }

        public static T Deserialize<T>(string filePath)
        {
            using FileStream fileStream = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes);
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(bytes), JsonSettings);
        }


    }
}

