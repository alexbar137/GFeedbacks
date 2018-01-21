using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GFeedbacks.Interfaces;
using GFeedbacks.SharePointLQASite;

namespace GFeedbacks.Implementations.SharePointUpdater
{
    public class FreelancersContextProvider
    {
        public FreelancersDataContext Context{ get; }

        public FreelancersContextProvider(ISetting settings)
        {
            Context = new FreelancersDataContext(new Uri(settings.SharePointSite))
            {
                Credentials = CredentialCache.DefaultNetworkCredentials
            };

        }

        public FeedbacksItem FindReport(LQA report)
        {
            return Context.Feedbacks.FirstOrDefault(s => s.ProjectCode == report.ProjCode);
        }
        
    }
}
