using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    internal class Project
    {
        private List<Contact> _contacts;

        public List<Contact> Contacts
        {
            get { return _contacts; }
            set 
            { 
                _contacts = SortContacts(value); 
            }
        }

        Project(List<Contact> contacts)
        {
            this.Contacts = contacts;
        }

        public List<Contact> FindBirthdayContact()
        {

            List<Contact> birthdayContact;
            DateTime today = DateTime.Today;
            birthdayContact = Contacts.FindAll(contact => contact.DateOfBirth.Date == today);
            return birthdayContact;
        }

        public List<Contact> FindContact(string temp)
        {
            return _contacts.FindAll(contact => (contact.FullName.IndexOf(temp) != -1) ||
            (ToCapitalLettersStyle(contact.FullName).IndexOf(temp) != -1));
        }

        private List<Contact> SortContacts(List<Contact> contacts)
        {
            contacts.Sort((c1,c2) => c1.FullName.CompareTo(c2.FullName));
            return contacts;
        }

        private string ToCapitalLettersStyle(string value)
        {
            return value;
        }
    }
}
