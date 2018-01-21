using GFeedbacks.Interfaces;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations
{
    /// <summary>
    /// Parses email message with LQA report
    /// </summary>
    class MailParser : IParser
    {
        internal ISetting _settings;

        /// <summary>
        /// Parses email message with LQA report
        /// </summary>
        /// <param name="settings">App settings with parsing options</param>
        public MailParser(ISetting settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Parse email
        /// </summary>
        /// <param name="item">Email to parse</param>
        /// <returns>Information about LQA report</returns>
        public LQA Parse(MailItem item)
        {

            LQA report = new LQA()
            {
                TargetLang = GetParsedData(item, _settings.TargetLang),
                SourceLang = GetParsedData(item, _settings.SourceLang),
                Result = ParseResult(GetParsedData(item, _settings.Result)),
                WordCount = int.Parse(GetParsedData(item, _settings.WordCount)),
                ProjCode = GetParsedData(item, _settings.ProjectCode),
                Date = item.ReceivedTime,
                Content = item.Body
            };
            return report;
        }


        internal string GetParsedData(MailItem item, ParsingItem setting)
        {
            switch (setting.Source)
            {
                case SourceType.Static:
                    return setting.Pattern;
                case SourceType.Body:
                    return ProcessRegExp(item.Body, setting);
                case SourceType.Subject:
                    return ProcessRegExp(item.Subject, setting);
                default:
                    return String.Empty;
            }
        }


        internal string ProcessRegExp(string text, ParsingItem settings)
        {
            Regex reg = new Regex(settings.Pattern);
            if (settings.Group != null && settings.Group != -1)
            {
                return reg.Match(text).Groups[(int)settings.Group].Value;
            }
            else
                return reg.Match(text).Value;
        }


        internal LQAResult? ParseResult(string pattern)
        {
            if (pattern == _settings.ResultParser.Pass) return LQAResult.Pass;
            if (pattern == _settings.ResultParser.Fail) return LQAResult.Fail;
            if (pattern == _settings.ResultParser.Recall) return LQAResult.Recall;
            return null;

        }
    }
}
