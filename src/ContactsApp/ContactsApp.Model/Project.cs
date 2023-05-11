using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    /// <summary>
    /// Класс Project содержащий список контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Контакты
        /// </summary>
        private List<Contact> _contacts;

        /// <summary>
        /// Возвращает или задает контакты
        /// </summary>
        public List<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
            }
        }

        public Project()
        {
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// Количество контактов
        /// </summary>
        public int ContactsCount
        {
            get { return _contacts.Count; }
        }

        /// <summary>
        /// констуктор класса Contact
        /// </summary>
        /// <param name="contacts"></param>
        public Project(List<Contact> contacts)
        {
            this.Contacts = contacts;
        }

        /// <summary>
        /// Поиск контакта по дню рождения
        /// </summary>
        /// <returns></returns>
        public List<Contact> FindBirthdayContact(DateTime date)
        {
            return _contacts.Where(c => c.DateOfBirth.Day == date.Day 
            && c.DateOfBirth.Month == date.Month).ToList();
        }

        /// <summary>
        /// Поиск контаткт по подстроке
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Contact> SearchContacts(string searchText)
        {
            var options = StringComparison.OrdinalIgnoreCase;
            return _contacts.Where(c =>
                c.FullName.Contains(searchText) ||
                c.Email.Contains(searchText) ||
                c.PhoneNumber.Contains(searchText) ||
                c.IdVk.IndexOf(searchText, options) >= 0).ToList();
        }

        /// <summary>
        /// Сортировка контакта
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public List<Contact> SortContacts(List<Contact> contacts)
        {
            contacts.Sort((c1,c2) => c1.FullName.CompareTo(c2.FullName));
            return contacts;
        }

    }
}
