using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    internal class Project
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
                _contacts = SortContacts(value); 
            }
        }

        /// <summary>
        /// констуктор класса Contact
        /// </summary>
        /// <param name="contacts"></param>
        Project(List<Contact> contacts)
        {
            this.Contacts = contacts;
        }

        /// <summary>
        /// Поиск контакта по дню рождения
        /// </summary>
        /// <returns></returns>
        public List<Contact> FindBirthdayContact()
        {

            List<Contact> birthdayContact;
            DateTime today = DateTime.Today;
            birthdayContact = Contacts.FindAll(contact => contact.DateOfBirth.Date == today);
            return birthdayContact;
        }

        /// <summary>
        /// Поиск контаткт по подстроке
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Contact> SearchContacts(string query)
        {
            return _contacts.Where(c =>
                c.FullName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Email.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.PhoneNumber.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.IdVk.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        /// <summary>
        /// Сортировка контакта
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        private List<Contact> SortContacts(List<Contact> contacts)
        {
            contacts.Sort((c1,c2) => c1.FullName.CompareTo(c2.FullName));
            return contacts;
        }

    }
}
