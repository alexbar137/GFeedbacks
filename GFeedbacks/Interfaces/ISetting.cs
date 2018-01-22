using GFeedbacks.Implementations;
using GFeedbacks.Interfaces;
using System.Collections.Generic;

namespace GFeedbacks.Interfaces
{
    public interface ISetting
    {
        int Account { get; set; }
        int Client { get; set; }
        string Email { get; set; }
        string LogFolder { get; set; }
        string Name { get; set; }
        int Pm { get; set; }
        ParsingItem ProjectCode { get; set; }
        string ReportFolder { get; set; }
        ParsingItem Result { get; set; }
        ParsingItem SourceLang { get; set; }
        string Subj { get; set; }
        ParsingItem TargetLang { get; set; }
        string TargetMailFolder { get; set; }
        int Team { get; set; }
        ResParser ResultParser { get; set; }
        ParsingItem WordCount { get; set; }
        Dictionary<string, int> Languages { get; set; }
        string SharePointSite { get; set; }
        string FeedbackType { get; set; }
    }
}