using GFeedbacks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;

namespace GFeedbacks.Implementations
{
    public class Mover : IMover
    {
        internal Folders _root;

        public Mover(Folders root)
        {
            _root = root;
        }

        public void Move(MailItem item, string folderName)
        {
            MAPIFolder targetFolder = GetFolder(folderName, _root);
            try
            {
                item.Move(targetFolder);
            }
            catch (System.Exception e)
            {
                ErrorLogger.LogError(e);
            }
        }

        
        public MAPIFolder GetFolder(string folderName, Folders root)
        {
            foreach (MAPIFolder f in root)
            {
                if (f.FolderPath.Contains(folderName)) return f;
                if (f.Folders.Count != 0)
                {
                    MAPIFolder result = GetFolder(folderName, f.Folders);
                    if (result != null) return result;
                }
            }

            return null;

        }
        
    }
}
