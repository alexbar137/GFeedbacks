using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using GFeedbacks.Implementations;
using System.IO;
using Newtonsoft.Json;

namespace NUnitTest
{
    [TestFixture]
    class JsonSettingsTest
    {
        JSONAppSettings settings;
        [SetUp]
        public void Init()
        { 
            settings = new JSONAppSettings();
        }

        [Test]
        public void TestReadJson()
        {
            
            Assert.IsTrue(settings.Count() > 0);
        }

        [Test]
        public void TestCorrectJsonRead()
        {
            Assert.IsTrue(settings.Any(s => s.Name == "Default Profile"));
        }

        [Test]
        public void TestJsonRead_slash()
        {
            string exp = @"Word Count:\s(\w*)\s\((\w*)";
            string actual = settings.FirstOrDefault(s => s.Name == "Default Profile").WordCount.Pattern;
            Assert.AreEqual(exp, actual);
        }

        [Test]
        public void Test_UserProfileRead()
        {
            Assert.IsTrue(settings.Any(s => s.Name == "TestProfile"));
            
        }


    }
}
