using GFeedbacks.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Interfaces
{
    public interface IAppSettings: IEnumerable<ISetting>
    {
        new IEnumerator<ISetting> GetEnumerator();
        List<string> Names { get;}
    }

    
}
