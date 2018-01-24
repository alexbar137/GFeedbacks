using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFeedbacks.Implementations;
using GFeedbacks.Interfaces;

namespace GFeedbacks.Implementations
{
    [Serializable]
    public class JSONSettings : ISetting
    {
        public string Name { get; set; }
        public string TargetMailFolder { get; set; }
        public string ReportFolder { get; set; }
        public string LogFolder { get; set; }
        public int Pm { get; set; }
        public int Account { get; set; }
        public int Client { get; set; }
        public int Team { get; set; }
        public string Email { get; set; }
        public string Subj { get; set; }
        public ParsingItem SourceLang { get; set; }
        public ParsingItem TargetLang { get; set; }
        public ParsingItem WordCount { get; set; }
        public ParsingItem Result { get; set; }
        public ParsingItem ProjectCode { get; set; }
        public ResParser ResultParser { get; set; }
        public Dictionary<string, int> Languages { get; set; }
        public string SharePointSite { get; set; }
        public string FeedbackType { get; set; }
    }

}
