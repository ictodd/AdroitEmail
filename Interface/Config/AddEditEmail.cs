using AdroitEmail.Common;
using AdroitEmail.Database;
using AdroitEmail.Database.Models;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AdroitEmail.Interface.Config {
    public partial class AddEditEmailForm : Form {
        private const string DEFAULT_SEND_DAY = "31";
        private Email updateEmail;

        public AddEditEmailForm() {
            InitializeComponent();
            txtSendDay.Text = DEFAULT_SEND_DAY;
        }

        // update constructor
        public AddEditEmailForm(Email email) : this() {
            Text = "Update Adroit Email";
            updateEmail = email;
            btnConfirm.Text = "Update";
            txtBody.Text = updateEmail.Body;
            txtName.Text = updateEmail.Name;
            txtRecipients.Text = string.Join(";", updateEmail.Recipients);
            txtSendDay.Text = updateEmail.SendDay.ToString();
            txtSubject.Text = updateEmail.Subject;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            if (!validate()) return;
            // add new
            if(updateEmail == null) {
                var email = AdroitEmailController.Instance.CreateNewEmailItem(
                    name: txtName.Text.Trim(),
                    recipients: recipientsToList(),
                    body: txtBody.Text,
                    subject: txtSubject.Text.Trim(),
                    sendDay: int.Parse(txtSendDay.Text.Trim())
                );
                AdroitDatabaseService.Instance.AddEmail(email);
            // update
            } else {
                updateEmail.Name = txtName.Text.Trim();
                updateEmail.Recipients = recipientsToList();
                updateEmail.SendDay = int.Parse(txtSendDay.Text.Trim());
                updateEmail.Subject = txtSubject.Text.Trim();
                updateEmail.Body = txtBody.Text;
                AdroitDatabaseService.Instance.UpdateEmail(updateEmail);
            }
            this.Dispose();
        }

        private List<string> recipientsToList() {
            return txtRecipients.Text.Trim().Split(';').ToList();
        }

        private bool validateRecipients() {
            var rawRecipients = txtRecipients.Text.Trim().Split(';');
            bool result = true;
            MailItem tmpItem = Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
            foreach (var rawRecip in rawRecipients) {
                var tmpRecip = tmpItem.Recipients.Add(rawRecip.Trim());
                if (!tmpRecip.Resolve()) {
                    MessageBox.Show($"Could not resolve {rawRecip}");
                    result = false;
                }
            }
            tmpItem.Delete();
            return result;
        }

        private bool validate() {
            if (txtName.Text == string.Empty) {
                MessageBox.Show("Please fill out name", "No Name");
                return false;
            } else if (txtSendDay.Text == string.Empty) {
                MessageBox.Show("Please fill out send day", "No Send Day");
                return false;
            } else if (txtRecipients.Text == string.Empty) {
                MessageBox.Show("Please fill out recipients", "No Recipients");
                return false;
            } else if (!validateRecipients()) {
                return false;
            } else if(txtSubject.Text == string.Empty) {
                MessageBox.Show("Please fill out subject", "No Subject");
                return false;
            } else if (txtBody.Text == string.Empty) {
                MessageBox.Show("Please fill out body", "No Body");
                return false;
            }

            return true;
        }

        private void txtSendDay_TextChanged(object sender, EventArgs e) {
            int tmp;
            if(int.TryParse(txtSendDay.Text.Trim(), out tmp)){
                if (tmp < 1) txtSendDay.Text = "1";
                if (tmp > 30) txtSendDay.Text = "31"; // i.e. end of month
            } else { 
                txtSendDay.Text = DEFAULT_SEND_DAY;
            }
        }
    }
}
