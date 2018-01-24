using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    public static class ErrorLogger
    {
        public static void LogError(Exception e)
        {
            Debug.WriteLine(e.Message);
            Debug.WriteLine(e.Source);
            Debug.WriteLine(e.StackTrace);
        }
    }
}
