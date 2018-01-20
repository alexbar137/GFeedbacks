using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    public class ParsingItem : IParsingItem
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public SourceType Source { get; set; }
        public int? Group { get; set; }
    }
}
