using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp.Model;

namespace ContactsApp.View
{
    public partial class MainForm : Form
    {
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();

            for (int i = 0; i < _project.ContactsCount; ++i)
            {
                ContactsListBox.Items.Add(_project.Contacts[i].FullName);
            }
        }

        private void AddContact()
        {
            Random random = new Random();
            string[] fullNames = { "John Smith", "Jane Bond", "Bob Ros", "Alice Wand", "Mike Takeover" };
            string[] phoneNumbers = { "21324124", "214124124", "14124121", "4211242", "121245232" };
            string[] emailDomains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "icloud.com" };
            string[] idVk = { "2312314", "423423", "15235233", "312415", "34423243256" };
            DateTime[] dateOfBirth = { DateTime.Today };

            string randomFullName = fullNames[random.Next(fullNames.Length)];
            string randomPhoneNumber = phoneNumbers[random.Next(phoneNumbers.Length)];
            string randomEmail = emailDomains[random.Next(emailDomains.Length)];
            string randomIdVk = idVk[random.Next(idVk.Length)];
            DateTime randomOfBirth = dateOfBirth[random.Next(dateOfBirth.Length)];

            Contact newContact = new Contact(randomFullName, randomEmail,randomPhoneNumber,
                randomOfBirth, randomIdVk);

            _project.Contacts.Add(newContact);
            ContactsListBox.Items.Add(newContact.FullName);
        }

        private void RemoveContact(int index)
        {
 
            if (MessageBox.Show($"Do you really want to remove{index}?", "Attention", MessageBoxButtons.YesNo) 
                == DialogResult.Yes)
            {
                if (index >= 0 && index < _project.ContactsCount)
                {
                    _project.Contacts.RemoveAt(index);
                    //UpdateListBox();
                }
            }
        }

        //private void Select

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RemoveContactButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32;
            RemoveContactButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
        }

        private void RemoveContactButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_gray;
            RemoveContactButton.BackColor = Color.White;
        }

        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void DateOfBirthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void VkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            BirthdayPanel.Hide();
        }

        private void EditContactButton_MouseEnter(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32;
            EditContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        private void EditContactButton_MouseLeave(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32_gray;
            EditContactButton.BackColor = Color.White;
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                var form = new AboutForm();
                form.ShowDialog();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AddContactButton_Click_1(object sender, EventArgs e)
        {
            //var form = new ContactForm();
            //form.ShowDialog();
            UpdateListBox();
            AddContact();
        }

        private void AddContactButton_MouseEnter(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32;
            AddContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        private void AddContactButton_MouseLeave(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32_gray;
            AddContactButton.BackColor = Color.White;
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            UpdateListBox();
        }
    }
}
