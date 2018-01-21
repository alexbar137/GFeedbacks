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
                TargetLang = GetTargetLang(item),
                SourceLang = GetSourceLang(item),
                Result = GetResult(item)
            };
            return report;
        }

        private string GetSourceLang(MailItem item)
        {
            switch (_settings.SourceLang.Source)
            {
                case SourceType.Static:
                    return _settings.SourceLang.Pattern;
                case SourceType.Body:
                    return ProcessRegExp(item.Body, _settings.SourceLang);
                case SourceType.Subject:
                    return ProcessRegExp(item.Subject, _settings.SourceLang);
                default:
                    return String.Empty;
            }
        }

        internal string GetTargetLang(MailItem item)
        {
            switch(_settings.TargetLang.Source)
            {
                case SourceType.Static:
                    return _settings.TargetLang.Pattern;
                case SourceType.Body:
                    return ProcessRegExp(item.Body, _settings.TargetLang);
                case SourceType.Subject:
                    return ProcessRegExp(item.Subject, _settings.TargetLang);
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

        internal LQAResult? GetResult(MailItem item)
        {
            switch (_settings.Result.Source)
            {
                case SourceType.Static:
                    return ParseResult(_settings.Result.Pattern);
                case SourceType.Body:
                    return ParseResult(ProcessRegExp(item.Body, _settings.Result));
                case SourceType.Subject:
                    return ParseResult(ProcessRegExp(item.Subject, _settings.Result));
                default:
                    return null;
            }
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
