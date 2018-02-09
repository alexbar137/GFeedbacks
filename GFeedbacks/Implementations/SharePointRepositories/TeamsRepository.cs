using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFeedbacks.Implementations.SharePointRepositories
{
    public class TeamsRepository : BaseSharePointRepository
    {
        public TeamsRepository() : base()
        {
            ListName = "Palex Teams";
        }
    }
}
