using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.Model.UnitTests
{
    [TestFixture]
    public class ProjectTests
    {
        Project _project = new Project();

        [Test(Description = "Позитивный тест геттера Contacts")]
        public void Contacts_GetContacts_ReturnsContacts()
        {
            // Arrange
            Contact firstContact = new Contact("Евгений Иванов Петрович", "Vlad@mail.ru", "+7 902(054)-21-33",
               new DateTime(1999, 6, 1), "id32859429");
            Contact secondContact = new Contact("Елена Петрова Сергеевна", "Elena@mail.ru", "+7 934(834)-11-22",
               new DateTime(1988, 4, 5), "id423645");
            List<Contact> contacts = new List<Contact>();
            contacts.Add(firstContact);
            contacts.Add(secondContact);
            var expectedContacts = contacts;

            // Act
            _project.Contacts.Add(firstContact);
            _project.Contacts.Add(secondContact);

            var actualContacts = _project.Contacts;

            // Assert
            Assert.AreEqual(expectedContacts, actualContacts);
        }

        [Test(Description = "Позитивный тест метода SortContacts")]
        public void SortContacts_SortContacts_ReturnsSortedListContacts()
        {
            // Arrange
            List<Contact> alreadySortedContacts = new List<Contact>();

            Contact firstContact = new Contact("Артем Артемович", "Attem@mail.ru", "+7 902(054)-21-33",
               new DateTime(1999, 6, 1), "id32859429");
            Contact secondContact = new Contact("Василий Васильевич", "Vasya@mail.ru", "+7 934(834)-11-22",
               new DateTime(1988, 4, 5), "id423645");
            Contact thirdContact = new Contact("Елена Петровна", "Elena@mail.ru", "+7 (777)-777-77-77",
               new DateTime(2002, 9, 9), "id21312415");

            alreadySortedContacts.Add(firstContact);
            alreadySortedContacts.Add(secondContact);
            alreadySortedContacts.Add(thirdContact);

            var expectedSortContacts = alreadySortedContacts;

            // Act
            List<Contact> contacts = new List<Contact>();
            contacts.Add(thirdContact);
            contacts.Add(secondContact);
            contacts.Add(firstContact);
            
            var actualSortContacts = _project.SortContacts(contacts);

            // Assert
            Assert.AreEqual(expectedSortContacts, actualSortContacts);
        }

        [Test(Description = "Позитивный тест метода SearchContacts")]
        public void SearchContacts_SearchContacts_ReturnsListSearchedContacts()
        {
            // Arrange
            List<Contact> SearchContacts = new List<Contact>();

            Contact SetupContact = new Contact("Алексей Михайлович", "Alex@mail.ru", "+7 999(321)-11-33",
               new DateTime(1991, 6, 1), "id32423123");

            SearchContacts.Add(SetupContact);

            var expectedSearchContacts = SearchContacts;

            // Act
            _project.Contacts.Add(SetupContact);
            string substring = "Алексей";
            var actualSearchContacts = _project.SearchContacts(substring);

            // Assert
            Assert.AreEqual(expectedSearchContacts, actualSearchContacts);
        }

        [Test(Description = "Позитивный тест метода SeachBirthDayContact")]
        public void SeachBirthDayContact_SearchContacts_ReturnsListSearchedContacts()
        {
            // Arrange
            List<Contact> SearchBirthdayContacts = new List<Contact>();

            Contact SetupContact = new Contact("Никита Семенович", "nikitos@mail.ru", "+7 321(377)-66-33",
               new DateTime(2001, 4, 3), "id31245123");

            SearchBirthdayContacts.Add(SetupContact);
            var expectedSearchContacts = SearchBirthdayContacts;

            // Act
            _project.Contacts.Add(SetupContact);
            var searchDate = new DateTime(2001, 4, 3);
            var actualSearchContacts = _project.SeachBirthdayContact(searchDate);

            // Assert
            Assert.AreEqual(expectedSearchContacts, actualSearchContacts);
        }
    }
}
