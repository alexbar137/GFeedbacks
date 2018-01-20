using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Threading.Tasks;
using GFeedbacks.Implementations;
using GFeedbacks.Interfaces;

namespace GFeedbacks
{
    public partial class ThisAddIn
    {
        Outlook.MAPIFolder inBox;
        IAppSettings settings;


        internal void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            GetFolders();
            settings = new JSONAppSettings();
            inBox.Items.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
        }

        internal void Items_ItemAdd(object Item)
        {
            IProcessor pr = new Processor(settings)
            {
                Root = Application.ActiveExplorer().Session.Folders
            };
            Task task = new Task(() => pr.Process(Item as Outlook.MailItem));
            task.Start();
        }

        internal void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see http://go.microsoft.com/fwlink/?LinkId=506785
        }

        internal void GetFolders()
        {

            inBox = inBox?? Application.ActiveExplorer().Session.
                    GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        internal void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
