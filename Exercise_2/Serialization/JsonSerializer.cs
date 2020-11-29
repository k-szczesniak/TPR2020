using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Serialization
{
    public class JsonSerializer
    {
        public static string Serialize(object obj, string filePath)
        {
            File.Delete(filePath);
            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            fileStream.Write(Encoding.UTF8.GetBytes(json));
            return json;
        }


    }
}
