using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GFeedbacks.Implementations.SharePointRepositories
{
    public class PmRepository : BaseSharePointRepository
    {
        public PmRepository() : base()
        {
            ListName = "Project Managers";
        }

    }
}