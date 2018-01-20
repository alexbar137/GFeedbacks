using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using Microsoft.Office.Interop.Outlook;
using GFeedbacks.Interfaces;
using GFeedbacks.Implementations;
using NSubstitute.ExceptionExtensions;

namespace NUnitTest
{
    [TestFixture]
    class ParserTests
    {
        static MailItem firstMail = Substitute.For<MailItem>();
        static MailItem secondMail = Substitute.For<MailItem>();
        static MailItem emptyMail = Substitute.For<MailItem>();

        ISetting settings;

        /*
        [SetUp]
        public void Init()
        {
            firstMail.Body.Returns(@"Product: Tachyon Project ID: 825569  Document ID: 009ulyx01tnxczq0sb9c
                Review Vendor: VistaTEC Vendor ID: Moravia  Translator ID: 004 - be_0300@004vendor.com    
                Reviewer Account: 002 - be_0002@002vendor.com Reviewer ID: 002 - BE_0002    
                Audit Status: Fail  Word Count: 121(57) > Errors 1K: 3.33 
                LQE Date: 20 - Jan - 2018 02:59:45 UTC  
                Workflow: segmented");
            firstMail.Subject.Returns(@"ru_Tachyon_825569_Request_1_of_1.html - An LQE Audit Report has been shared with you");
            firstMail.SenderEmailAddress.Returns(@"no-reply@gloc-lqe-tool.appspotmail.com");

            secondMail.Body.Returns(@"Product: Gmail	
                 Project ID: 824585	Document ID: 0051x6o01tneaot0d8g0
                   Review Vendor: VistaTEC	Vendor ID: Moravia	
                   Translator ID: 004-be_0300@004vendor.com	
                   Reviewer Account: 002-be_0002@002vendor.com	
                   Reviewer ID: 002-BE_0002	Audit Status: Passed	
                   Word Count: 79 (79)> 	Errors 1K: 0.00	LQE Date: 19-Jan-2018 18:58:00 UTC	
                    Workflow: segmented");
            secondMail.Subject.Returns(@"be_Gmail_824585_Request_1_of_1.html - An LQE Audit Report has been shared with you");
            secondMail.SenderEmailAddress.Returns(@"no-reply@gloc-lqe-tool.appspotmail.com");

            emptyMail.Subject.Returns("");
            emptyMail.Body.Returns("");

            settings = Substitute.For<ISetting>();
            settings.TargetLang.Returns(@"^\D{2}");
            settings.TargetLangSource.Returns("Subject");
            settings.ResultSource.Returns("Body");
            settings.ResultPass.Returns("Passed");
            settings.ResultFail.Returns("Fail");
            settings.Result.Returns(@"Audit Status:\s(\w*)");
        }

        static object[] TestCasesResult =
        {
            new object[] { firstMail, false, true },
            new object[] { secondMail, true, true }
        };

        public class TestCaseFactory
        {
            public static IEnumerable<TestCaseData> TestCasesLangs
            {
                get
                {
                    yield return new TestCaseData(firstMail, "ru", true);
                    yield return new TestCaseData(firstMail, "be", false);
                    yield return new TestCaseData(secondMail, "be", true);
                    yield return new TestCaseData(secondMail, "ru", false);
                }
            }
        }

        [Test, TestCaseSource(typeof(TestCaseFactory), "TestCasesLangs")]
        public void TestParse_TargetLangs(MailItem item, string lang, bool exp)
        {
            MailParser parser = new MailParser(settings);
            Assert.AreEqual(exp, parser.Parse(item).TargetLang == lang);
        }

        [Test, TestCaseSource("TestCasesResult")]
        public void TestParse_Result(MailItem item, bool? result, bool exp)
        {
            MailParser parser = new MailParser(settings);
            bool? res = parser.Parse(item).Result;
            Assert.NotNull(res);
            Assert.AreEqual(exp, res == result);
        }
        */


    }
}
