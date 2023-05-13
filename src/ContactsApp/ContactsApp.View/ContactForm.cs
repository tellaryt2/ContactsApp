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
        private string _fullNameError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для Email
        /// </summary>
        private string _emailError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для телефонного номера
        /// </summary>
        private string _phoneNumberError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для Id вконтакте
        /// </summary>
        private string _idVkError = "";

        /// <summary>
        /// Строка содержащая текст ошибки для даты рождения
        /// </summary>
        private string _dateOfBirthError = "";

        /// <summary>
        /// Белый цвет
        /// </summary>
        private Color _whiteColor = Color.White;

        /// <summary>
        /// Светло-розовый цвет
        /// </summary>
        private Color _lightPinkColor = Color.LightPink;

        /// <summary>
        /// Возвращает и задает контакт
        /// </summary>
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                if (_contact != null)
                {
                    UpdateForm();
                }
            }
        }

        /// <summary>
        /// Конструктор формы по умолчанию
        /// </summary>
        public ContactForm()
        {
            InitializeComponent();
            CheckСorrectnessFullName();
            CheckСorrectnessEmail();
            CheckСorrectnessPhoneNumber();
            CheckСorrectnessIdVk();
            CheckСorrectnessDateOfBirth();
        }

        /// <summary>
        /// Обновление полей формы
        /// </summary>
        private void UpdateForm()
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
            CheckСorrectnessFullName();
        }

        /// <summary>
        /// Проверка на правильность введенного полного имени
        /// </summary>
        private void CheckСorrectnessFullName()
        {
            try
            {
                FullNameTextBox.BackColor = _whiteColor;
                _contact.FullName = FullNameTextBox.Text;
                _fullNameError = "";
            }
            catch (ArgumentException error)
            {
                FullNameTextBox.BackColor = _lightPinkColor;
                _fullNameError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectnessEmail();
        }

        /// <summary>
        /// Проверка на правильность введенного Email
        /// </summary>
        private void CheckСorrectnessEmail()
        {
            try
            {
                EmailTextBox.BackColor = _whiteColor;
                _contact.Email = EmailTextBox.Text;
                _emailError = "";
            }
            catch (ArgumentException error)
            {
                EmailTextBox.BackColor = _lightPinkColor;
                _emailError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для телефонного номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectnessPhoneNumber();
        }

        /// <summary>
        /// Проверка на правильность введенного номера телефона
        /// </summary>
        private void CheckСorrectnessPhoneNumber()
        {
            try
            {
                PhoneNumberTextBox.BackColor = _whiteColor;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                _phoneNumberError = "";
            }
            catch (ArgumentException error)
            {
                PhoneNumberTextBox.BackColor = _lightPinkColor;
                _phoneNumberError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для Id вконтакте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VkTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckСorrectnessIdVk();
        }

        /// <summary>
        /// Проверка на правильность введенного Id вконтакте
        /// </summary>
        private void CheckСorrectnessIdVk()
        {
            try
            {
                VkTextBox.BackColor = _whiteColor;
                _contact.IdVk = VkTextBox.Text;
                _idVkError = "";
            }
            catch (ArgumentException error)
            {
                VkTextBox.BackColor = _lightPinkColor;
                _idVkError = error.Message;
            }
        }

        /// <summary>
        /// Редактирование поля для даты рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            CheckСorrectnessDateOfBirth();
        }

        /// <summary>
        /// Проверка на правильность введенной даты рождения
        /// </summary>
        private void CheckСorrectnessDateOfBirth()
        {
            try
            {
                DateTimePicker.CalendarMonthBackground = _whiteColor;
                _contact.DateOfBirth = DateTimePicker.Value;
                _dateOfBirthError = "";
            }
            catch (ArgumentException error)
            {
                DateTimePicker.CalendarMonthBackground = _lightPinkColor;
                _dateOfBirthError = error.Message;
            }
        }

        /// <summary>
        /// Проверка для текста ошибок
        /// </summary>
        /// <returns></returns>
        private bool CheckFormOnErrors()
        {
            string fullStringError = ""; 
            if (_fullNameError != "")
            {
                fullStringError += _fullNameError + "\n";
            }
            if (_phoneNumberError != "")
            {
                fullStringError += _phoneNumberError + "\n";
            }
            if (_emailError != "")
            {
                fullStringError += _emailError + "\n";
            }
            if (_dateOfBirthError != "")
            {
                fullStringError += _dateOfBirthError + "\n";
            }
            if (_idVkError != "")
            {
                fullStringError += _idVkError + "\n";
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
            _contact.FullName = FullNameTextBox.Text;
            _contact.PhoneNumber = PhoneNumberTextBox.Text;
            _contact.Email = EmailTextBox.Text;
            _contact.IdVk = VkTextBox.Text;
            _contact.DateOfBirth = DateTimePicker.Value;
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
                this.DialogResult = DialogResult.OK;
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
            _contact = null;

            this.DialogResult = DialogResult.Cancel;
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
