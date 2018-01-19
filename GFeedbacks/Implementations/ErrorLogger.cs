using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    public static class ErrorLogger
    {
        public static void LogError(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
