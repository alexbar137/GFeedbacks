using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    public enum LQAResult { Pass, Fail, Recall}

    public class LQA
    {
       
        public LQAResult? Result { get; set; }
        public int? Wc { get; set; }
        public string Lang { get; set; }
        public string ProjCode { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string AttachmentPath { get; set; }
        public string SourceLang { get; set; }
        public string TargetLang { get; set; }
        
    }
}
