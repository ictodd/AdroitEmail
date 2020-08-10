using AdroitEmail.Database;
using AdroitEmail.Database.Models;
using System;
using System.Windows.Forms;

namespace AdroitEmail.Interface.Config {
    public partial class ConfigWindow : Form {
        public ConfigWindow() {
            InitializeComponent();
            refreshData();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var addForm = new AddEditEmailForm();
            AddOwnedForm(addForm);
            addForm.ShowDialog();
            refreshData();
        }

        private void refreshData() {
            dgvEmails.DataSource = null;
            dgvEmails.DataSource = AdroitDatabaseService.Instance.AllEmails;
            dgvEmails.ReadOnly = true;
            dgvEmails.Refresh();
        }

        private void dgvEmails_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            Email email = null;
            try {
                email = dgvEmails.Rows[e.RowIndex].DataBoundItem as Email;
            }catch(Exception ex) {
                // pass
            }
            if (email == null) return;
            var addForm = new AddEditEmailForm(email);
            AddOwnedForm(addForm);
            addForm.ShowDialog();
            refreshData();
        }
    }
}
