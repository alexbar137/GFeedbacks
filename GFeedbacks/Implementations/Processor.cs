using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using IniParser.Model;

namespace GFeedbacks.Implementations
{
    public class Processor : IProcessor
    {
        public Folders Root { get; set; }
        internal IAppSettings _settings;
        public Processor(IAppSettings settings)
        {
            _settings = settings;
        }

        public void Process(MailItem item)
        {
            ISetting setting = Select(item);
            if(setting != null)
            {
                IMover mv = new Mover(Root);
                mv.Move(item, setting.TargetMailFolder);


            }
        }

        internal ISetting Select(MailItem item)
        {
            foreach (ISetting d in _settings)
            {
                if (item.SenderEmailAddress == d.Email &&
                    item.Subject.Contains(d.Subj)) return d;
            }
            return null;
        }
    }
}
