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

        private Color whiteColor = Color.White;

        private Color lightPinkColor = Color.LightPink;
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
                    FullNameTextBox.Text = _contact.FullName;
                    PhoneNumberTextBox.Text = _contact.PhoneNumber;
                    EmailTextBox.Text = _contact.Email;
                    VkTextBox.Text = _contact.IdVk;
                    DateTimePicker.Value = _contact.DateOfBirth;
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
                FullNameTextBox.BackColor = whiteColor;
                _contact.FullName = FullNameTextBox.Text;
                fullNameError = "";
            }
            catch (ArgumentException error)
            {
                FullNameTextBox.BackColor = lightPinkColor;
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
            CheckСorrectnessEmail();
        }

        /// <summary>
        /// Проверка на правильность введенного Email
        /// </summary>
        private void CheckСorrectnessEmail()
        {
            try
            {
                EmailTextBox.BackColor = whiteColor;
                _contact.Email = EmailTextBox.Text;
                emailError = "";
            }
            catch (ArgumentException error)
            {
                EmailTextBox.BackColor = lightPinkColor;
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
            CheckСorrectnessPhoneNumber();
        }

        /// <summary>
        /// Проверка на правильность введенного номера телефона
        /// </summary>
        private void CheckСorrectnessPhoneNumber()
        {
            try
            {
                PhoneNumberTextBox.BackColor = whiteColor;
                _contact.PhoneNumber = PhoneNumberTextBox.Text;
                phoneNumberError = "";
            }
            catch (ArgumentException error)
            {
                PhoneNumberTextBox.BackColor = lightPinkColor;
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
            CheckСorrectnessIdVk();
        }

        /// <summary>
        /// Проверка на правильность введенного Id вконтакте
        /// </summary>
        private void CheckСorrectnessIdVk()
        {
            try
            {
                VkTextBox.BackColor = whiteColor;
                _contact.IdVk = VkTextBox.Text;
                idVkError = "";
            }
            catch (ArgumentException error)
            {
                VkTextBox.BackColor = lightPinkColor;
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
            CheckСorrectnessDateOfBirth();
        }

        /// <summary>
        /// Проверка на правильность введенной даты рождения
        /// </summary>
        private void CheckСorrectnessDateOfBirth()
        {
            try
            {
                DateTimePicker.CalendarMonthBackground = whiteColor;
                _contact.DateOfBirth = DateTimePicker.Value;
                dateOfBirthError = "";
            }
            catch (ArgumentException error)
            {
                DateTimePicker.CalendarMonthBackground = lightPinkColor;
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
