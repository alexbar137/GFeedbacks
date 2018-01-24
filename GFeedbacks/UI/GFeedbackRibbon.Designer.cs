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
            this.Feedbacks = this.Factory.CreateRibbonTab();
            this.GFeedback = this.Factory.CreateRibbonGroup();
            this.Settings = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.Feedbacks.SuspendLayout();
            this.GFeedback.SuspendLayout();
            this.SuspendLayout();
            // 
            // Feedbacks
            // 
            this.Feedbacks.Groups.Add(this.GFeedback);
            this.Feedbacks.Label = "Feedbacks";
            this.Feedbacks.Name = "Feedbacks";
            // 
            // GFeedback
            // 
            this.GFeedback.Items.Add(this.button1);
            this.GFeedback.Items.Add(this.Settings);
            this.GFeedback.Label = "Feedbacks";
            this.GFeedback.Name = "GFeedback";
            // 
            // Settings
            // 
            this.Settings.Image = ((System.Drawing.Image)(resources.GetObject("Settings.Image")));
            this.Settings.Label = "Settings";
            this.Settings.Name = "Settings";
            this.Settings.ShowImage = true;
            this.Settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Send to SharePoint";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            // 
            // GFeedbackRibbon
            // 
            this.Name = "GFeedbackRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.Feedbacks);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GFeedbackRibbon_Load);
            this.Feedbacks.ResumeLayout(false);
            this.Feedbacks.PerformLayout();
            this.GFeedback.ResumeLayout(false);
            this.GFeedback.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GFeedback;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Settings;
        public Microsoft.Office.Tools.Ribbon.RibbonTab Feedbacks;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal GFeedbackRibbon GFeedbackRibbon
        {
            get { return this.GetRibbon<GFeedbackRibbon>(); }
        }
    }
}
