namespace GFeedbacks
{
    partial class GFeedbackRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GFeedbackRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GFeedbackRibbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.GFeedback = this.Factory.CreateRibbonGroup();
            this.Settings = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.GFeedback.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.GFeedback);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // GFeedback
            // 
            this.GFeedback.Items.Add(this.Settings);
            this.GFeedback.Label = "Feedbacks";
            this.GFeedback.Name = "GFeedback";
            // 
            // Settings
            // 
            this.Settings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.Label = "Settings";
            this.Settings.Name = "Settings";
            this.Settings.ShowImage = true;
            this.Settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // GFeedbackRibbon
            // 
            this.Name = "GFeedbackRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GFeedbackRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.GFeedback.ResumeLayout(false);
            this.GFeedback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GFeedback;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Settings;
    }

    partial class ThisRibbonCollection
    {
        internal GFeedbackRibbon GFeedbackRibbon
        {
            get { return this.GetRibbon<GFeedbackRibbon>(); }
        }
    }
}
