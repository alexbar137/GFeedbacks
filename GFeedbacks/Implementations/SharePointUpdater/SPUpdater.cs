using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFeedbacks.SharePointLQASite;
using System.Threading;

namespace GFeedbacks.Implementations.SharePointUpdater
{
    class SPUpdater : ISPUpdater
    {
        internal Dictionary<LQAResult?, string> _results = new Dictionary<LQAResult?, string>()
        {
            { LQAResult.Pass, "Pass" },
            {LQAResult.Fail, "Fail" },
            {LQAResult.Recall, "Recall" }
        };
        internal SharePointUtilities _utils;
        internal ISetting _settings;
        public SPUpdater(SharePointUtilities utils)
        {
            _utils = utils;
            _settings = utils.Settings;

        }
        public void AddItem(IReport report, FeedbacksItem existingItem = null)
        {
            FeedbacksItem item = Map(report, existingItem ?? new FeedbacksItem());
            if(existingItem == null) _utils.AddFeedbacksItem(item);
            Thread.Sleep(5000);
            UpdateTargetLang(report, item);
            _utils.Save();
        }

        internal FeedbacksItem Map(IReport report, FeedbacksItem item)
        {
            item.ResultValue = _results[report.Result];
            item.Wordcount = report.WordCount;
            item.SourceLanguageId = _settings.Languages[report.SourceLang];
            item.FeedbackTypeValue = _settings.FeedbackType;
            item.ManagerId = _settings.Pm;
            item.ProjectCode = report.ProjCode;
            item.AccountId = _settings.Account;
            item.ClientId = _settings.Client;
            item.PalexTeamsId = _settings.Team;
            item.FeedbackContent = report.Content;
            item.FeedbackDate = report.Date;

            return item;
        }

        internal void UpdateTargetLang(IReport report, FeedbacksItem item)
        {
            int langId = _utils.Settings.Languages[report.TargetLang];
            LanguagesItem targetLang = _utils.Context.Languages.Where(s => s.Идентификатор == langId).FirstOrDefault();
            item.TargetLanguage.Add(targetLang);
            _utils.Context.AddLink(item, "TargetLanguage", targetLang);
        }
    }
}
