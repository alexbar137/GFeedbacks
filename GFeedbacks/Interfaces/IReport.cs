using System;

namespace GFeedbacks.Interfaces
{
    public enum LQAResult { Pass, Fail, Recall }
    public interface IReport
    {
        string Content { get; set; }
        DateTime Date { get; set; }
        string Lang { get; set; }
        string ProjCode { get; set; }
        LQAResult? Result { get; set; }
        string SourceLang { get; set; }
        string TargetLang { get; set; }
        int? WordCount { get; set; }
    }
}