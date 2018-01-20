using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    public class ResParser : IResultParser
    {
        public string Pass { get; set; }
        public string Fail { get; set; }
        public string Recall { get; set; }
    }
}
