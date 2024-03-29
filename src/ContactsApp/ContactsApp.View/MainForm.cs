﻿using System;
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
        /// Создает объект проекта, хранящий в себе контакты
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Список отображаемых контактов
        /// </summary>
        List<Contact> _displayContact;

        /// <summary>
        /// Создает объект, реализующий сериализацию
        /// </summary>
        private ProjectManager _projectManager = new ProjectManager();

        /// <summary>
        /// Конструктор формы по умолчанию.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _project = _projectManager.LoadProject();
            UpdateListBox();
        }

        /// <summary>
        /// Обновление списка контактов
        /// </summary>
        private void UpdateListBox()
        {
            ContactsListBox.Items.Clear();

            _project.SortContacts(_project.Contacts);

            if (FindTextBox.Text != "")
            {
                _displayContact = _project.FindContacts(FindTextBox.Text);
            }
            else
            {
                _displayContact = _project.Contacts;
            }
            foreach (var item in _displayContact)
            {
                ContactsListBox.Items.Add(item.FullName);
            }
        }

        /// <summary>
        /// Добавить новый контакт
        /// </summary>
        private void AddContact()
        {
            var addForm = new ContactForm();
            DialogResult result = addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var newContact = addForm.Contact;
                _project.Contacts.Add(newContact);
                _projectManager.SaveProject(_project);
            }
        }

        /// <summary>
        /// Редактировать выбранный контакт
        /// </summary>
        /// <param name="index">Индекс выбранного контакта</param>
        private void EditContact(int index)
        {   
            var editForm = new ContactForm();
            var newContact = _displayContact[ContactsListBox.SelectedIndex].Clone();
            editForm.Contact = (Contact)newContact;
            DialogResult result = editForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                _project.Contacts.Remove(_displayContact[index]);
                _project.Contacts.Add(editForm.Contact);
                UpdateSelectedContactsField(editForm.Contact);
                _projectManager.SaveProject(_project);
            }
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
                        $"{ _displayContact[index].FullName}?", "Attention", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
            {
                _project.Contacts.Remove(_displayContact[index]);
                _projectManager.SaveProject(_project);
            }
        }

        /// <summary>
        /// Отображение данных контакта на правой панели
        /// </summary>
        /// <param name="index">Индекс контакта</param>
        private void UpdateSelectedContacts(int index)
        {
            //UpdateSelectedContactsField(_project.Contacts[index]);
            UpdateSelectedContactsField(_displayContact[index]);
        }

        /// <summary>
        /// Запись данных контакта в поля на правой панели
        /// </summary>
        /// <param name="contact">Необходимый контакт</param>
        private void UpdateSelectedContactsField(Contact contact)
        {
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
            AddContact();
            UpdateListBox();
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
        /// Открытие формы изменения окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            if (ContactsListBox.SelectedIndex != -1)
            {
                EditContact(ContactsListBox.SelectedIndex);
                UpdateListBox();
                ContactsListBox.SetSelected(index, true);
            }
        }

        /// <summary>
        /// Поиск контакта по подстроке в поле find
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        /// <summary>
        /// Вызов предупреждающего окна при закрытии приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel = MessageBox.Show("do you really want to close the program?",
                    "Attention", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                _projectManager.SaveProject(_project);
            }
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
