using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CyranoLibrary.WorldGeoloc.Utils
{
    public class ResourceReader
    {
        public async Task<JObject> ReadResourceAsJObjectAsync(string resourceName)
        {
            ExceptionChecker.ThrowArgumentNullExceptionIfNullOrEmpty(resourceName, nameof(resourceName));

            var resourceStream = Assembly.GetAssembly(typeof(ResourceReader)).GetManifestResourceStream(resourceName);

            using var reader = new StreamReader(resourceStream, Encoding.UTF8);
            var json = await reader.ReadToEndAsync();

            return JObject.Parse(json);
        }

        public async Task<List<T>> ReadResourceAsObjectsAsync<T>(string resourceName)
        {
            ExceptionChecker.ThrowArgumentNullExceptionIfNullOrEmpty(resourceName, nameof(resourceName));

            T output;
            var outputList = new List<T>();
            var resourceStream = Assembly.GetAssembly(typeof(ResourceReader)).GetManifestResourceStream(resourceName);

            using var reader = new StreamReader(resourceStream, Encoding.UTF8);
                var arr = await reader.ReadToEndAsync();
                var a = JArray.Parse(arr);

                foreach (var obj in a.Children())
                {
                    output = JsonConvert.DeserializeObject<T>(obj.ToString());
                    outputList.Add(output);
                }

            return outputList;
        }
    }
}
