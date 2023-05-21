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

        /// <summary>
        /// Конструктор
        /// </summary>
        public Project()
        {
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// Поиск контакта по дню рождения
        /// </summary>
        /// <returns></returns>
        public List<Contact> SeachBirthdayContact(DateTime date)
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
            List <Contact> result = new List<Contact>();
            foreach(Contact contact in Contacts)
            {
                if (contact.FullName.Contains(searchText) ||
                    contact.PhoneNumber.Contains(searchText) ||
                    contact.Email.Contains(searchText) ||
                    contact.IdVk.Contains(searchText)
                    )
                {
                    result.Add(contact);
                }
            }
            return result;
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
