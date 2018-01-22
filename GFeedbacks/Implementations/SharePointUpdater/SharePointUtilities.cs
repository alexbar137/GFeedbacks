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
    public class SharePointUtilities
    {
        public FreelancersDataContext Context{ get; }
        public ISetting Settings { get; }

        public SharePointUtilities(ISetting settings)
        {
            Context = new FreelancersDataContext(new Uri(settings.SharePointSite))
            {
                Credentials = CredentialCache.DefaultNetworkCredentials
            };
            Settings = settings;

        }

        public FeedbacksItem FindReport(IReport report)
        {
            return Context.Feedbacks.Where(s => s.ProjectCode == report.ProjCode).FirstOrDefault();
        }

        public void AddFeedbacksItem(FeedbacksItem item)
        {
            try
            {
                Context.AddToFeedbacks(item);
                Save();
            }
            catch(Exception e)
            {
                ErrorLogger.LogError(e);
            }

        }

        public void Save()
        {
            Context.SaveChanges();
        }

        
    }
}
