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
        /// Конструктор класса Contact
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
        /// Конструктор по умолчанию
        /// </summary>
        public Contact()
        {
            FullName = "Unknown";
            Email = "any@gmail.com";
            PhoneNumber = "+7 (777)-777-77-77";
            DateOfBirth = DateTime.Today;
            IdVk = "11111111";
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
                if (value[value.Length - 1] == ' ')
                {
                    value = value.Remove(value.Length - 1);
                }
                string fullNameString = value;
                string[] words = fullNameString.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    var oneWord = words[i];
                    words[i] = oneWord.Substring(0, 1).ToUpper() + oneWord.Substring(1);
                }

                _fullName = String.Join(" ", words);
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
                if (value.Length <= 0)
                {
                    throw new ArgumentException($"You entered an empty phone number.");
                }
                const string allowedChars = "1234567890+()- ";
                for (int i = 0; i < value.Length; i++)
                {
                    for (int j = 0; j < allowedChars.Length; j++)
                    {
                        if (value[i] != allowedChars[j])
                        {
                            if (j == allowedChars.Length - 1)
                            {
                                throw new ArgumentException($"you entered the wrong " +
                                    $"character in the phone number.");
                            }
                        }
                        else
                            break;
                    }
                }
                _phoneNumber =  new string(value.Where(character => allowedChars.Contains(character)).ToArray());
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
