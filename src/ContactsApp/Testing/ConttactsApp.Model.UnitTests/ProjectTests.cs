using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using ContactsApp.Model;

namespace ConttactsApp.Model.UnitTests
{
    [TestFixture]
    public class ProjectTests
    {
        [Test(Description = "Позитивный тест геттера Contacts")]
        public void Contacts_GetContacts_ReturnsContacts()
        {
            Project project = new Project();

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
            project.Contacts.Add(firstContact);
            project.Contacts.Add(secondContact);

            var actualContacts = project.Contacts;

            // Assert
            Assert.AreEqual(expectedContacts, actualContacts);
        }

        [Test(Description = "Позитивный тест метода SortContacts")]
        public void SortContacts_SortContacts_ReturnsSortedListContacts()
        {
            Project project = new Project();

            // Arrange
            List<Contact> alreadySortedContacts = new List<Contact>();

            Contact firstContact = new Contact("Артем Артемович", "Attem@mail.ru", "+7 902(054)-21-33",
               new DateTime(1999, 6, 1), "id32859429");
            Contact secondContact = new Contact("Василий Васильевич", "Vasya@mail.ru", "+7 934(834)-11-22",
               new DateTime(1988, 4, 5), "id423645");
            Contact thirdContact = new Contact("Елена Петровна", "Elena@mail.ru", "+7 (777)-777-77-77",
               new DateTime(2002, 9, 9), "id231312415");

            alreadySortedContacts.Add(firstContact);
            alreadySortedContacts.Add(secondContact);
            alreadySortedContacts.Add(thirdContact);

            var expectedSortContacts = alreadySortedContacts;

            // Act
            List<Contact> contacts = new List<Contact>();
            contacts.Add(thirdContact);
            contacts.Add(secondContact);
            contacts.Add(firstContact);

            var actualSortContacts = project.SortContacts(contacts);

            // Assert
            Assert.AreEqual(expectedSortContacts, actualSortContacts);
        }

        [Test(Description = "Позитивный тест метода SearchContacts")]
        public void SearchContacts_SearchContacts_ReturnsListSearchedContacts()
        {
            Project project = new Project();

            // Arrange
            List<Contact> searchContacts = new List<Contact>();

            Contact newContact = new Contact("Алексей Михайлович", "Alex@mail.ru", "+7 999(321)-11-33",
               new DateTime(1991, 6, 1), "id32423123");

            searchContacts.Add(newContact);

            var expectedSearchContacts = searchContacts;

            // Act
            project.Contacts.Add(newContact);
            string substring = "Алексей";
            var actualSearchContacts = project.SearchContacts(substring);

            // Assert
            Assert.AreEqual(expectedSearchContacts, actualSearchContacts);
        }

        [Test(Description = "Негативный тест метода SearchContacts")]
        public void SearchContacts_UncorrectedSearchContacts_ReturnsUncorrectingListSearchedContacts()
        {
            Project project = new Project();

            // Arrange
            List<Contact> emptySeacrhContacts = new List<Contact>();

            var expectedSearchContacts = emptySeacrhContacts;

            // Act
            string substring = "Никита";
            emptySeacrhContacts = project.SearchContacts(substring);
            var actualSearchContacts = emptySeacrhContacts;

            // Assert
            Assert.AreEqual(expectedSearchContacts, actualSearchContacts);
        }

        [Test(Description = "Позитивный тест метода SeachBirthDayContact")]
        public void SeachBirthDayContact_SearchContacts_ReturnsListSearchedContacts()
        {
            Project project = new Project();

            // Arrange
            List<Contact> searchBirthdayContacts = new List<Contact>();

            Contact setupContact = new Contact("Никита Семенович", "nikitos@mail.ru", "+7 321(377)-66-33",
               new DateTime(2001, 4, 3), "id31245123");

            searchBirthdayContacts.Add(setupContact);
            var expectedSearchContacts = searchBirthdayContacts;

            // Act
            project.Contacts.Add(setupContact);
            var searchDate = new DateTime(2001, 4, 3);
            var actualSearchContacts = project.SeachBirthdayContact(searchDate);

            // Assert
            Assert.AreEqual(expectedSearchContacts, actualSearchContacts);
        }
    }
}
