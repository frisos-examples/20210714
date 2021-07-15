using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    public class ParcelJsonHandler : IParcelFileHandler
    {
        public Container Deserialize(string filePath)
        {
            var data = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(filePath));
            return data.SelectToken("Container", false).ToObject<Container>();
        }
    }
}
