using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pukka.Tools.Countries.Utils
{
    internal static class JsonFileLoader
    {
        internal static JObject ReadAsJObject(string relativePath)
        {
            ExceptionChecker.ThrowArgumentNullExceptionIfNullOrEmpty(relativePath, nameof(relativePath));

            JObject output = null;
            var path = Path.Combine(Environment.CurrentDirectory, relativePath);

            using (var r = new StreamReader(path))
            {
                var obj = r.ReadToEnd();
                output = JObject.Parse(obj);
            }

            return output;
        }

        internal static List<T> ReadAsObject<T>(string relativePath)
        {
            ExceptionChecker.ThrowArgumentNullExceptionIfNullOrEmpty(relativePath, nameof(relativePath));

            T output;
            List<T> outputList = new List<T>();
            var path = Path.Combine(Environment.CurrentDirectory, relativePath);

            using (var r = new StreamReader(path))
            {
                var arr = r.ReadToEnd();
                var a = JArray.Parse(arr);

                foreach (var obj in a.Children())
                {
                    output = JsonConvert.DeserializeObject<T>(obj.ToString());
                    outputList.Add(output);
                }

            }

            return outputList;
        }
    }
}
