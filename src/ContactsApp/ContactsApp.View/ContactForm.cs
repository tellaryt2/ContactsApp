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
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Объект класса Contact
        /// </summary>
        private Contact _contact = new Contact("John Smith", "qwer@gmail.com", "+7(103)-211-22-11",
            DateTime.Today, "2312314");

        /// <summary>
        /// Строка содержащая текст ошибки для полного имени
        /// </summary>
        private string fullNameError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для Email
        /// </summary>
        private string emailError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для телефонного номера
        /// </summary>
        private string phoneNumberError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для Id вконтакте
        /// </summary>
        private string idVkError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для даты рождения
        /// </summary>
        private string dateOfBirthError = "";

        /// <summary>
        /// Конструктор формы по умолчанию
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            _contact.FullName = "john skoth";
            _contact.PhoneNumber = "+7(103)-211-22-22";
            _contact.Email = "sadsaffa@gmail.com";
            _contact.DateOfBirth = DateTime.Today;
            _contact.IdVk = "6567563";
            UpdateForm();
        }

        /// <summary>
        /// Обновление полей формы
        /// </summary>
        void UpdateForm()
        {
            FullNameTextBox.Text = _contact.FullName;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            EmailTextBox.Text = _contact.Email;
            VkTextBox.Text = _contact.IdVk;
            DateTimePicker.Value = _contact.DateOfBirth;
        }

        /// <summary>
        /// Редактирование поля для полного имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FullNameTextBox.BackColor = Color.White;
                _contact.FullName = FullNameTextBox.Text;
                fullNameError = "";
            }
            catch (ArgumentException error)
            {
                FullNameTextBox.BackColor = Color.LightPink;
                fullNameError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EmailTextBox.BackColor = Color.White;
                _contact.Email = EmailTextBox.Text;
                emailError = "";
            }
            catch (ArgumentException error)
            {
                EmailTextBox.BackColor = Color.LightPink;
                emailError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для телефонного номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PhoneNumberTextBox.BackColor = Color.White;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                phoneNumberError = "";
            }
            catch (ArgumentException error)
            {
                PhoneNumberTextBox.BackColor = Color.LightPink;
                phoneNumberError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для Id вконтакте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                VkTextBox.BackColor = Color.White;
                _contact.IdVk = VkTextBox.Text;
                idVkError = "";
            }
            catch (ArgumentException error)
            {
                VkTextBox.BackColor = Color.LightPink;
                idVkError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker.CalendarMonthBackground = Color.White;
                _contact.DateOfBirth = DateTimePicker.Value;
                dateOfBirthError = "";
            }
            catch (ArgumentException error)
            {
                DateTimePicker.CalendarMonthBackground = Color.LightPink;
                dateOfBirthError = error.Message;
            }
        }

        /// <summary>
        /// Проверка для текста ошибок
        /// </summary>
        /// <returns></returns>
        private bool CheckFormOnErrors()
        {
            string fullStringError = ""; 
            if (fullNameError != "")
            {
                fullStringError += fullNameError + "\n";
            }
            if (phoneNumberError != "")
            {
                fullStringError += phoneNumberError + "\n";
            }
            if (emailError != "")
            {
                fullStringError += emailError + "\n";
            }
            if (dateOfBirthError != "")
            {
                fullStringError += dateOfBirthError + "\n";
            }
            if (idVkError != "")
            {
                fullStringError += idVkError + "\n";
            }

            if (fullStringError != "")
            {
                MessageBox.Show(fullStringError, "Attention");
                return false;
            }
            else
            {
                UpdateContact();
                return true;
            }
        }

        /// <summary>
        /// Обновить объект класса Contact актуальными данными
        /// </summary>
        private void UpdateContact()
        {
            FullNameTextBox.Text = _contact.FullName;
            PhoneNumberTextBox.Text = _contact.PhoneNumber;
            EmailTextBox.Text = _contact.Email;
            VkTextBox.Text = _contact.IdVk;
            DateTimePicker.Value = _contact.DateOfBirth;
        }

        /// <summary>
        /// Реализация кнопки OK для подтверждения изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckFormOnErrors())
            {
                this.Close();
            }
        }

        /// <summary>
        /// Реализация кнопки Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Изменение иконок при наведении мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPhotoButton_MouseEnter(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32;
            AddPhotoButton.BackColor = ColorTranslator.FromHtml("#F5F5FF");
        }

        /// <summary>
        /// Изменение иконок при отвода мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPhotoButton_MouseLeave(object sender, EventArgs e)
        {
            AddPhotoButton.Image = Properties.Resources.add_photo_32x32_gray;
            AddPhotoButton.BackColor = Color.White;
        }


    }
}
