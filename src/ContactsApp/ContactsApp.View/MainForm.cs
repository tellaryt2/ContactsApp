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
        /// <summary>
        /// Создает объект объект проекта, хранящий в себе контакты
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Конструктор формы по умолчанию.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();

            for (int i = 0; i < _project.ContactsCount; ++i)
            {
                ContactsListBox.Items.Add(_project.Contacts[i].FullName);
            }
        }

        /// <summary>
        /// Добавить новый контакт
        /// </summary>
        private void AddContact()
        {
            Random random = new Random();
            string[] fullNames = { "John Smith", "Jane Bond", "Bob Ros", "Alice Wand", "Mike Takeover" };
            string[] phoneNumbers = { "+7(103)-211-22-11", "+7(112)-642-41-76",
                "+7(325)-543-71-42", "+7(103)-444-34-98", "+7(333)-999-55-13" };
            string[] emailDomains = { "qwer@gmail.com", "sadsda@mail.com", "vxcvxcv@hotmail.com",
                "iyttseqwr@outlook.com", "sdasdasfaf@gmail.com" };
            string[] idVk = { "2312314", "423423", "15235233", "312415", "34423243256" };
            DateTime[] dateOfBirth = { DateTime.Today };

            string randomFullName = fullNames[random.Next(fullNames.Length)];
            string randomPhoneNumber = phoneNumbers[random.Next(phoneNumbers.Length)];
            string randomEmail = emailDomains[random.Next(emailDomains.Length)];
            string randomIdVk = idVk[random.Next(idVk.Length)];
            DateTime randomDateOfBirth = dateOfBirth[random.Next(dateOfBirth.Length)];

            Contact newContact = new Contact(randomFullName, randomEmail,randomPhoneNumber,
                randomDateOfBirth, randomIdVk);

            _project.Contacts.Add(newContact);
            ContactsListBox.Items.Add(newContact.FullName);
        }

        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="index">Индекс удаляемого контакта</param>
        private void RemoveContact(int index)
        {
            if (index == -1)
            {
                return;
            }
            if (MessageBox.Show($"Do you really want to remove " +
                        $"index {index}?", "Attention", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
            {
                _project.Contacts.RemoveAt(index);
            }
        }

        /// <summary>
        /// Отображение данных контакта на правой панели
        /// </summary>
        /// <param name="index">Индекс контакта</param>
        private void UpdateSelectedContacts(int index)
        {
            var contact = _project.Contacts[index];
            FullNameTextBox.Text = contact.FullName;
            EmailTextBox.Text = contact.Email;
            PhoneNumberTextBox.Text = contact.PhoneNumber;
            VkTextBox.Text = contact.IdVk;
            DateOfBirthTimePicker.Value = contact.DateOfBirth;
        }

        /// <summary>
        /// Очистка правой панели
        /// </summary>
        private void ClearSelectedContacts()
        {
            FullNameTextBox.Clear();
            EmailTextBox.Clear();
            PhoneNumberTextBox.Clear();
            VkTextBox.Clear();
            DateOfBirthTimePicker.Value = new DateTime(1930, 1, 1);
        }

        /// <summary>
        /// Вызов функции добавления при нажатии на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContactButton_Click_1(object sender, EventArgs e)
        {
            //расскомментировать когда будут связаны формы
            //var form = new ContactForm();
            //form.ShowDialog();
            UpdateListBox();
            AddContact();
        }

        /// <summary>
        /// Вызов функции удаления контакта при нажатии кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact(ContactsListBox.SelectedIndex);
            ClearSelectedContacts();
            UpdateListBox();
        }

        /// <summary>
        /// Функция проверки индекса контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                ClearSelectedContacts();
            }
            else
            {
                UpdateSelectedContacts(ContactsListBox.SelectedIndex);
            }
        }

        /// <summary>
        /// Вызов предупреждающего окна при закрытии приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show("do you really want to close the program?",
                    "Attention", MessageBoxButtons.YesNo) != DialogResult.Yes;
        }

        /// <summary>
        /// Открытие формы изменения окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            var form = new ContactForm();
            form.ShowDialog();
        }

        /// <summary>
        /// Вызов формы при нажатии на клавишу
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                var form = new AboutForm();
                form.ShowDialog();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Закрыть панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            BirthdayPanel.Hide();
        }

         
        /// <summary>
        /// Изменение иконок при наведении мышью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContactButton_MouseEnter(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32;
            RemoveContactButton.BackColor = ColorTranslator.FromHtml("#FAF5F5");
        }

        /// <summary>
        /// Изменение иконок при отводе мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContactButton_MouseLeave(object sender, EventArgs e)
        {
            RemoveContactButton.Image = Properties.Resources.remove_contact_32x32_gray;
            RemoveContactButton.BackColor = Color.White;
        }

        /// <summary>
        /// Запрет на изменение поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Запрет на изменение поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Запрет на изменение поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Запрет на изменение поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VkTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Изменение иконок при наведении мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_MouseEnter(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32;
            EditContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        /// <summary>
        /// Изменение иконок при отводе мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_MouseLeave(object sender, EventArgs e)
        {
            EditContactButton.Image = Properties.Resources.edit_contact_32x32_gray;
            EditContactButton.BackColor = Color.White;
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        /// <summary>
        /// Изменение иконок при наведении мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContactButton_MouseEnter(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32;
            AddContactButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        /// <summary>
        /// Изменение иконок при отводе мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContactButton_MouseLeave(object sender, EventArgs e)
        {
            AddContactButton.Image = Properties.Resources.add_contact_32x32_gray;
            AddContactButton.BackColor = Color.White;
        }



    }
}
