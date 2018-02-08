using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using IniParser.Model;
using GFeedbacks.SharePointLQASite;
using GFeedbacks.Implementations.SharePointUpdater;

namespace GFeedbacks.Implementations
{
    public class Processor : IProcessor
    {
        public Folders Root { get; set; }
        internal IAppSettings _settings;
        internal FreelancersDataContext _context;

        public Processor(IAppSettings settings)
        {
            _settings = settings;
        }

        public void Process(MailItem item)
        {
            IProfile setting = Select(item);
            if(setting != null)
            {
                IMover mv = new Mover(Root);
                mv.Move(item, setting.TargetMailFolder);
                IParser parser = new MailParser(setting);
                IReport report = parser.Parse(item);
                SharePointUtilities provider = new SharePointUtilities(setting);
                SPUpdater updater = new SPUpdater(provider);
                updater.AddItem(report, provider.FindReport(report));


            }
        }

        internal IProfile Select(MailItem item)
        {
            foreach (IProfile d in _settings)
            {
                if (item.SenderEmailAddress == d.Email &&
                    item.Subject.Contains(d.Subj)) return d;
            }
            return null;
        }
    }
}
