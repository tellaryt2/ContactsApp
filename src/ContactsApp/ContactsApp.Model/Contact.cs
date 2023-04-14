using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    internal class Contact
    {
        /// <summary>
        /// Максимальная длина строки для ввода текста
        /// </summary>
        private const int _maxTextLength = 100;

        /// <summary>
        /// Максимальная длина строки для ввода текста ID вконтакте
        /// </summary>
        private const int _maxTextIdLength = 50;

        /// <summary>
        /// Имя и фамилия
        /// </summary>
        private string _fullName;

        /// <summary>
        /// почта email
        /// </summary>
        private string _email;

        /// <summary>
        /// телефонный номер
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// дата рождения
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// ID вконтакте
        /// </summary>
        private string _idVk;

        /// <summary>
        /// Конструктор класса Contact
        /// </summary>
        private Contact(string fullName, string email, string phoneNumber, DateTime dateOfBirth, string idVk)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            IdVk = idVk;
        }

        /// <summary>
        /// Имя и Фамилия
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty string.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException($"The string title must be less than {_maxTextLength} characters.");
                }
                _fullName = value.Substring(0, Math.Min(value.Length, 100));
                string[] fullName = _fullName.Split(' ');
                _fullName = char.ToUpper(fullName[0][0]) + fullName[0].Substring(1)
                    + ' ' + char.ToUpper(fullName[1][0]) + fullName[1].Substring(1);
            }
        }

        /// <summary>
        /// почта email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set 
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty string.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException($"The string title must be less than {_maxTextLength} characters.");
                }
                _email = value; 
            }
        }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            {
                foreach (char c in value)
                {
                    if (!char.IsDigit(c) && c != '+' && c != '(' && c != ')' && c != '-' && c != ' ')
                        throw new ArgumentException("Invalid character in phone number.");
                }
                
                _phoneNumber = value; 
            }
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            { 
                if ((value > new DateTime(1900, 1, 1)) && (value < DateTime.Now))
                {
                    _dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentException("Invalid date of birth.");
                }
            }
        }

        /// <summary>
        /// Id вконтакте
        /// </summary>
        public string IdVk
        {
            get { return _idVk; }
            set 
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty string.");
                }
                if (value.Length > _maxTextIdLength)
                {
                    throw new ArgumentException($"The string title must be less than {_maxTextIdLength} characters.");
                }
                _idVk = value; 
            }
        }

        /// <summary>
        /// Интерфейс для клонирования контактов
        /// </summary>
        /// <returns></returns>
        public object ICloneable()
        {
            return new Contact(_fullName, _email, _phoneNumber, _dateOfBirth, _idVk);
        }
    }
}
