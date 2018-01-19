using System;
using NUnit.Framework;
using NSubstitute;
using GFeedbacks.Implementations;
using GFeedbacks.Interfaces;
using System.Collections.Generic;
using Microsoft.Office.Interop.Outlook;

namespace NUnitTest
{

   
    [TestFixture]
    public class ProcessorTests
    {
        IAppSettings settings;
        List<Setting> settingsList;

        [SetUp]
        public void Init()
        {
            
            settingsList = new List<Setting>
            {
                new Setting() {Email = "Hello", Subj = "Buy" },
                new Setting() {Email = "Bonjour", Subj = "Arevour" }
            };

            settings = Substitute.For<IAppSettings>();
            settings.GetEnumerator().Returns(Iterate());

        }

        public IEnumerator<Setting> Iterate()
        {
            foreach (Setting s in settingsList) yield return s;
        }



        [TestCase("Hello", "Buy", true)]
        [TestCase("Hello", "Dz", false)]
        [TestCase("Bonjour", "", false)]
        public void TestSelect(string email, string subj, bool exp)
        {
            //arrange
            Processor pr = new Processor(settings);
            MailItem item = Substitute.For<MailItem>();
            item.Subject.Returns(subj);
            item.SenderEmailAddress.Returns(email);

            //act
            bool result = pr.Select(item) != null;
            //assert

            Assert.AreEqual(exp, result);
        }
    }
}
