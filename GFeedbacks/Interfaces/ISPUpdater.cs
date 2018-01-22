using GFeedbacks.SharePointLQASite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Interfaces
{
    interface ISPUpdater
    {
        void AddItem(IReport report, FeedbacksItem existingITem);
    }
}
