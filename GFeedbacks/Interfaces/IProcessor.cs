using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using GFeedbacks.Implementations;

namespace GFeedbacks.Interfaces
{
    interface IProcessor
    {
        void Process(MailItem item);
        Folders Root { get; set; }
    }
}
