using NUnit.Framework;
using System;
using NSubstitute;
using GFeedbacks.Implementations.SharePointUpdater;
using GFeedbacks.SharePointLQASite;
using GFeedbacks.Interfaces;
using GFeedbacks.Implementations;

namespace NUnitTest
{
    [TestFixture]
    public class SharePointContextTests
    {
        SharePointUtilities pr;
        IProfile settings;

        [SetUp]
        public void Init()
        {
            settings = Substitute.For<IProfile>();
            settings.SharePointSite.Returns(@"http://inside.office.palex/lqa/_vti_bin/ListData.svc");
        }

        [Test]
        public void TestSharePoint_ContextRead()
        {
            pr = new SharePointUtilities(settings);
        }

        [Test]
        public void TestSharePoint_ListRead()
        {
            pr = new SharePointUtilities(settings);
            Assert.NotNull(pr.Context.Feedbacks);
        }

        [TestCase("ru_G Suite_826064_TEXT_SNIPPET_7638427_en.HTML", true)]
        [TestCase("38595 VC_500W_software translation_Colour Label Editor", true)]
        [TestCase("No such project", false)]
        public void TestSharePoint_FindReport(string projCode, bool exp)
        {
            IReport report = Substitute.For<IReport>();
            report.ProjCode.Returns(projCode);
            pr = new SharePointUtilities(settings);
            Assert.AreEqual(exp, pr.FindReport(report) != null);
        }
    }
}
