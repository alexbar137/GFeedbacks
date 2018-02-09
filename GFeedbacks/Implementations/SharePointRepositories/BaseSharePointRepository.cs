using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using GFeedbacks.ListsService;
using System.Xml.Linq;

namespace GFeedbacks.Implementations.SharePointRepositories
{
    public abstract class BaseSharePointRepository : ISharePointRepository
    {
        protected ListsSoapClient _client;
        protected Dictionary<int, string> _internalDictionary;

        protected string ListName { get; set; }
        protected Dictionary<int, string> InternalDictionary => _internalDictionary ?? GetData(ListName);
        public string this[int key] => InternalDictionary[key];
        public bool Contains(KeyValuePair<int, string> item) => InternalDictionary.Contains(item);
        public bool ContainsValue(string item) => InternalDictionary.Any(s => s.Value == item);
        public int? GetKey(string value) => InternalDictionary.FirstOrDefault(s => s.Value == value).Key;
        public BaseSharePointRepository()
        {
            Connect();
        }

        protected virtual void Connect()
        {
            _client = new ListsSoapClient();
            _client.ClientCredentials.Windows.AllowedImpersonationLevel =
                System.Security.Principal.TokenImpersonationLevel.Impersonation;
            _client.ClientCredentials.Windows.ClientCredential =
                CredentialCache.DefaultNetworkCredentials;
        }
        protected virtual Dictionary<int, string> GetData(string _listName)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            string rowLimit = Properties.Settings.Default.RowLimit;
            var query = new XElement("Query", "");
            var viewFields = new XElement("ViewFields", "");
            var queryOptions = new XElement("QueryOptions", "");
            var listData = _client.GetListItems(_listName, null, query, viewFields, rowLimit, queryOptions, null);

            foreach (var item in listData.Descendants())
            {
                if (item.Attributes().Any(s => s.Name == "ows_ID"))
                {
                    int key = int.Parse(item.Attributes().FirstOrDefault(s => s.Name == "ows_ID").Value);
                    string value = item.Attributes().FirstOrDefault(s => s.Name == "ows_Title").Value;
                    dict.Add(key, value);
                }
            }
            return dict;
        }

        public virtual IEnumerator<KeyValuePair<int, string>> GetEnumerator()
        {
            foreach (KeyValuePair<int, string> pair in InternalDictionary)
            {
                yield return pair;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (KeyValuePair<int, string> pair in InternalDictionary)
            {
                yield return pair;
            }
        }
    }
}
