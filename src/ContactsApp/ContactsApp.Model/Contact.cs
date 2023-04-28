using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ContactsApp.Model
{
    /// <summary>
    /// Класс Contact
    /// </summary>
    public class Contact : ICloneable
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
        /// Констурктор класса Contact
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="email"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="idVk"></param>
        public Contact(string fullName, string email, string phoneNumber, DateTime dateOfBirth, string idVk)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            IdVk = idVk;
        }


        /// <summary>
        /// возвращает и задает полное имя контакта
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty full name.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException($"The full name text must be less than {_maxTextLength} characters.");
                }
                string currentFullName = "";
                string fullNameString = value;
                string[] fullName = fullNameString.Split(' ');
                foreach (string word in fullName)
                {
                    currentFullName += char.ToUpper(word[0]) + word.Substring(1) + ' ';
                }
                _fullName = currentFullName;
            }
        }

        /// <summary>
        /// задает и возвращает почту email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set 
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty email.");
                }
                if (value.Length > _maxTextLength)
                {
                    throw new ArgumentException($"The email must be less than {_maxTextLength} characters.");
                }
                _email = value; 
            }
        }

        /// <summary>
        /// Задает и возвращает номер телефона
        /// </summary>
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            {
                string symbol = "+-() ";
                foreach (char c in value)
                {
                    for (int i = 0; i < symbol.Length; i++)
                    {
                        if (!char.IsDigit(c) && c!= symbol[i])
                            throw new ArgumentException("Invalid character in phone number.");
                    }
                }
                _phoneNumber = value; 
            }
        }

        /// <summary>
        /// Задает и возвращает дату рождения
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
        /// Задает и возвращает Id вконтакте
        /// </summary>
        public string IdVk
        {
            get { return _idVk; }
            set 
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty IdVk.");
                }
                if (value.Length > _maxTextIdLength)
                {
                    throw new ArgumentException($"The {nameof(IdVk)} must be less than {_maxTextIdLength} characters.");
                }
                _idVk = value; 
            }
        }

        /// <summary>
        /// Интерфейс для клонирования контактов
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(_fullName, _email, _phoneNumber, _dateOfBirth, _idVk);
        }
    }
}
