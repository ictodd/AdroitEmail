using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using AdroitEmail.Interface.Config;

namespace AdroitEmail.Interface {
    public partial class AdroitRibbon {
        private void AdroitRibbon_Load(object sender, RibbonUIEventArgs e) {
            
        }

        private void btnLoad_Click(object sender, RibbonControlEventArgs e) {
            var config = new ConfigWindow();
            config.ShowDialog();
        }
    }
}
