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
    public static class SettingUtilities
    {
        public static ISetting GetSettingsFromJson(string path)
        {
            JSONSettings setting;
            using (StreamReader file = File.OpenText(path))
            {

                JsonSerializer serializer = new JsonSerializer();
                setting = (JSONSettings)serializer.Deserialize(file, typeof(JSONSettings));
            }

            return setting;
        }

        public static ISetting GetSettingsFromJson(byte[] str)
        {
            JSONSettings setting;
            using (StreamReader file = new StreamReader(new MemoryStream(str)))
            {

                JsonSerializer serializer = new JsonSerializer();
                setting = (JSONSettings)serializer.Deserialize(file, typeof(JSONSettings));
            }

            return setting;
        }

        public static void Save(ISetting setting, string path)
        {
            throw new NotImplementedException();
        }
    }
}
