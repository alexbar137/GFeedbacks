using GFeedbacks.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations.Settings
{
    public static class JsonProfileHelper 
    {
        public static IProfile GetProfileFromJson(string path)
        {
            JSONProfile setting;
            using (StreamReader file = File.OpenText(path))
            {

                JsonSerializer serializer = new JsonSerializer();
                setting = (JSONProfile)serializer.Deserialize(file, typeof(JSONProfile));
            }

            return setting;
        }

        public static IProfile GetProfileFromJson(byte[] str)
        {
            JSONProfile setting;
            using (StreamReader file = new StreamReader(new MemoryStream(str)))
            {

                JsonSerializer serializer = new JsonSerializer();
                setting = (JSONProfile)serializer.Deserialize(file, typeof(JSONProfile));
            }

            return setting;
        }

        public static void Save(IProfile setting, string path)
        {
            throw new NotImplementedException();
        }
    }
}
