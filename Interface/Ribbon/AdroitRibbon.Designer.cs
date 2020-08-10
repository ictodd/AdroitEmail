namespace AdroitEmail.Interface {
    partial class AdroitRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AdroitRibbon()
            : base(Globals.Factory.GetRibbonFactory()) {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.grpControls = this.Factory.CreateRibbonGroup();
            this.btnLoad = this.Factory.CreateRibbonButton();
            this.btnSendEmails = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.grpControls);
            this.tab1.Label = "Adroit Email";
            this.tab1.Name = "tab1";
            // 
            // grpControls
            // 
            this.grpControls.Items.Add(this.btnLoad);
            this.grpControls.Items.Add(this.btnSendEmails);
            this.grpControls.Label = "Controls";
            this.grpControls.Name = "grpControls";
            // 
            // btnLoad
            // 
            this.btnLoad.Label = "Load Config";
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnLoad_Click);
            // 
            // btnSendEmails
            // 
            this.btnSendEmails.Label = "Send Emails";
            this.btnSendEmails.Name = "btnSendEmails";
            // 
            // AdroitRibbon
            // 
            this.Name = "AdroitRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.AdroitRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpControls;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnLoad;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSendEmails;
    }
}
