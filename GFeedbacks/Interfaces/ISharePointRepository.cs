using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Interfaces
{
    public interface ISharePointRepository : IEnumerable<KeyValuePair<int, string>>
    {
        string this[int key] { get;}
        bool Contains(KeyValuePair<int, string> item);
        bool ContainsValue(string item);
        int? GetKey(string value);

    }
}
