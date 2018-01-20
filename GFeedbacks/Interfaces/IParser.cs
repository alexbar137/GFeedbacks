using GFeedbacks.Implementations;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Interfaces
{
    interface IParser
    {
        LQA Parse(MailItem item);
    }
}
