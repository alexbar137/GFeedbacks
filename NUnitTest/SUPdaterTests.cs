using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using GFeedbacks.SharePointLQASite;
using GFeedbacks.Implementations.SharePointUpdater;
using GFeedbacks.Interfaces;

namespace NUnitTest
{
    [TestFixture]
    class SUPdaterTests
    {
        SharePointUtilities utilities;
        SPUpdater updater;
        ISetting setting;
        [SetUp]
        public void Init()
        {
            setting = Substitute.For<ISetting>();
            utilities = Substitute.For<SharePointUtilities>(setting);
            
            updater = new SPUpdater(utilities);
        }

        [Test]
        public void Test_Map()
        {

        }

    }
}
