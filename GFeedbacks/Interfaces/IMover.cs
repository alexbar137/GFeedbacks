﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace GFeedbacks.Interfaces
{
    interface IMover
    {
        void Move(MailItem item, string folderName);
    }
}
