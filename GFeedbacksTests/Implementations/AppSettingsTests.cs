using Microsoft.VisualStudio.TestTools.UnitTesting;
using GFeedbacks.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace GFeedbacks.Implementations.Tests
{
    [TestClass()]
    public class AppSettingsTests
    {
        [TestMethod()]
        public void AppSettingsTest()
        {
            AppSettings settings = new AppSettings();
            Setting g = settings.FirstOrDefault(s=>s.Name=="Google");
            string result = g.SourceLangSource;
            Assert.AreEqual("Static", result);
        }
    }
}