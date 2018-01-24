using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using GFeedbacks.Implementations;
using System.Resources;
using System.Diagnostics;
using System.Collections;

namespace NUnitTest
{
    [TestFixture]
    class TestResources
    {
        string path = @"C:\Users\barabash\documents\visual studio 2015\Projects\GFeedbacks\GFeedbacks\SettingsFolder\ggl.json";

        [Test]
        public void Test()
        {
            JSONSettings setting;
            using (StreamReader file = File.OpenText(path))
            {
                
                JsonSerializer serializer = new JsonSerializer();
                setting = (JSONSettings)serializer.Deserialize(file, typeof(JSONSettings));
                

                using (ResXResourceWriter resx = new ResXResourceWriter(@".\Resource.resx"))
                {
                    resx.AddResource("GglNew", setting);
                }
            }

            
        }

        [Test]
        public void Test_EnumResources()
        { 
            JsonSerializer serializer = new JsonSerializer();
            var file = GFeedbacks.Properties.Resources.DefaultProfile;
            JSONSettings setting;
            using (StreamReader reader = new StreamReader(new MemoryStream(file)))
            {
                setting =
                    (JSONSettings)serializer.Deserialize(reader, typeof(JSONSettings));
            }

            Console.WriteLine(setting.LogFolder);

        }
    }
}
