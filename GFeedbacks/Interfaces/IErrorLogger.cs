using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Interfaces
{
    interface IErrorLogger
    {
        void LogError(Exception e);
    }
}
