using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactsApp.Model;

namespace ContactsApp.Model.UnitTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test(Description = "Позитивный тест конструктора Contact")]
        public void Constructor_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctFullName = "Евгений Иванов Петрович";
            var expectedFullName = correctFullName;

            var correctEmail = "testemailtusur@gmail.com";
            var expectedEmail = correctEmail;

            var correctPhoneNumber = "+7 (903)-047-85-79";
            var expectedPhoneNumber = correctPhoneNumber;

            var correctDateOfBirth = new DateTime(1995, 2, 14);
            var expectedDateOfBirth = correctDateOfBirth;

            var correctIdVk = "id328921849";
            var expectedIdVk = correctIdVk;

            //Act
            Contact contact = new Contact(correctFullName, correctEmail, correctPhoneNumber, correctDateOfBirth, correctIdVk);

            var actualFullName = contact.FullName;
            var actualEmail = contact.Email;
            var actualPhoneNumber = contact.PhoneNumber;
            var actualDateOfBirth = contact.DateOfBirth;
            var actualIdVk = contact.IdVk;

            //Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedFullName, actualFullName);
                    Assert.AreEqual(expectedEmail, actualEmail);
                    Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
                    Assert.AreEqual(expectedDateOfBirth, actualDateOfBirth);
                    Assert.AreEqual(expectedIdVk, actualIdVk);
                }
                );
        }

        [Test(Description = "Негативный тест конструктора Contact")]
        public void Constructor_SetUncorrectValue_ArgumentException()
        {
            // Arrange
            var wrongFullName = "Евгений Иванов Петрович Евгений Иванов Петрович Евгений Иванов Петрович" +
                "Евгений Иванов ПетровичЕвгений Иванов ПетровичЕвгений Иванов ПетровичЕвгений Иванов Петрович" +
                "Евгений Иванов ПетровичЕвгений Иванов ПетровичЕвгений Иванов ПетровичЕвгений Иванов Петрович" +
                "Евгений Иванов ПетровичЕвгений Иванов Петровиxч";

            var wrongEmail = "";

            var wrongPhoneNumber = "bfghfhfgh";

            var wrongDateOfBirth = new DateTime(1899, 2, 14);

            var wrongIdVk = "id328921849";

            string message = "Попытка присвоить неправильные данные контакту";

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                Contact contact = new Contact(wrongFullName, wrongEmail, wrongPhoneNumber,
                    wrongDateOfBirth, wrongIdVk);
            },
            message);
        }

        // Arrange
        [TestCase("",
            "Должно возникать исключение, если полное имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве полного имени")]
        // Arrange
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов" +
            "-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов" +
            "-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-Смирнов",
            "Должно возникать исключение, если полное имя длиннее 100 символов",
            TestName = "Присвоение неправильного полного имени больше 100 символов")]
        public void FullName_SetUncorrectValue_ArgumentException(string wrongFullName, string message)
        {
            Contact contact = new Contact();
            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.FullName = wrongFullName; 
            },
            message);
        }

        [Test(Description = "Позитивный тест сеттера FullName")]
        public void FullName_SetCorrectValue_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var correctFullName = "Евгений Иванов Петрович";
            var expectedFullName = correctFullName;

            // Act
            contact.FullName = correctFullName;
            var actualFullName = contact.FullName;

            // Assert
            Assert.AreEqual(expectedFullName, actualFullName);
        }

        // Arrange
        [TestCase("",
            "Должно возникать исключение, если полное email - пустая строка",
            TestName = "Присвоение пустой строки в качестве email")]
        // Arrange
        [TestCase("@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com" +
            "-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com" +
            "-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com-@gmail.com",
            "Должно возникать исключение, если полное email длиннее 100 символов",
            TestName = "Присвоение неправильного email больше 100 символов")]
        public void Email_SetUncorrectValue_ArgumentException(string wrongEmail, string message)
        {
            Contact contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.Email = wrongEmail; 
            }, 
            message);
        }

        [Test(Description = "Позитивный тест сеттера Email")]
        public void Email_SetCorrectValue_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var correctEmail = "testemailtusur@gmail.com";
            var expectedEmail = correctEmail;

            // Act
            contact.Email = correctEmail;
            var actualEmail = contact.Email;

            // Assert
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        // Arrange
        [TestCase("",
            "Должно возникать исключение, если телефонный номер - пустая строка",
            TestName = "Присвоение пустой строки в качестве номера телефона")]
        // Arrange
        [TestCase("eqwjthjtrkj",
            "Должно возникать исключение, если введены неправильные символы для номера телефона",
            TestName = "Присвоение неправильного телефонного номера неправильными символами")]
        public void PhoneNumber_SetUncorrectValue_ArgumentException(string wrongPhoneNumber, string message)
        {
            Contact contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.PhoneNumber = wrongPhoneNumber; 
            }, 
            message);
        }

        [Test(Description = "Позитивный тест сеттера PhoneNumber")]
        public void PhoneNumber_SetCorrectValue_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var correctPhoneNumber = "+7 (903)-047-85-79";
            var expectedPhoneNumber = correctPhoneNumber;

            // Act
            contact.PhoneNumber = correctPhoneNumber;
            var actualPhoneNumber = contact.PhoneNumber;

            // Assert
            Assert.AreEqual(expectedPhoneNumber, actualPhoneNumber);
        }

        [Test(Description = "Негативный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetUncorrectValueLaterToday_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var uncorrectDateOfBirth = new DateTime(2077, 1, 1);
            string message = "Присвоение неправильной даты рождения (позднее сегодняшней)";

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.DateOfBirth = uncorrectDateOfBirth; 
            }, 
            message);
        }

        [Test(Description = "Негативный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetUncorrectValueOldDate_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var uncorrectDateOfBirth = new DateTime(1899, 12, 30);
            string message = "Присвоение неправильной даты рождения (раньше 1900 года)";

            // Assert
            Assert.Throws<ArgumentException>(() => 
            {
                // Act
                contact.DateOfBirth = uncorrectDateOfBirth; 
            }, 
            message);
        }

        [Test(Description = "Позитивный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetCorrectValue_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var correctDateOfBirth = new DateTime(1995, 2, 14);
            var expectedDateOfBirth = correctDateOfBirth;

            // Act
            contact.DateOfBirth = correctDateOfBirth;
            var actuaDateOfBirthl = contact.DateOfBirth;

            // Assert
            Assert.AreEqual(expectedDateOfBirth, actuaDateOfBirthl);
        }

        // Arrange
        [TestCase("",
            "Должно возникать исключение, если полное Id вконтакте - пустая строка",
            TestName = "Присвоение пустой строки в качестве Id вконтакте")]
        // Arrange
        [TestCase("3213213123rtueriotueirotuierotuireutoiertiueritueriotuier" +
            "gfhkfhlkghljgfhjgkljtio34493094kf3049f3490kf3490fk390k390gfgrfgr",
            "Должно возникать исключение, если Id вконтакте длиннее 50 символов",
            TestName = "Присвоение неправильного Id вконтакте более 50 символов")]
        public void IdVk_SetUncorrectValue_ArgumentException(string wrongIdVk, string message)
        {
            Contact contact = new Contact();

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                contact.IdVk = wrongIdVk; 
            }, 
            message);
        }

        [Test(Description = "Позитивный тест сеттера IdVk")]
        public void IdVk_SetCorrectValue_ReturnsSameValue()
        {
            Contact contact = new Contact();

            // Arrange
            var correctIdVk = "id328921849";
            var expectedIdVk = correctIdVk;

            // Act
            contact.IdVk = correctIdVk;
            var actualIdVk = contact.IdVk;

            // Assert
            Assert.AreEqual(expectedIdVk, actualIdVk);
        }

        [Test(Description = "Позитивный тест метода Clone()")]
        public void Clone_SetCorrectObject_ReturnsSameObject()
        {
            // Arrange
            Contact cloneContact = new Contact("Vladimir Petrov", "Vlad@mail.ru", "+7 902(054)-21-33",
                new DateTime(1932, 4, 5), "id32859429");
            var expectedContact = cloneContact;

            // Act
            Contact newContact = (Contact)cloneContact.Clone();
            var actualContact = newContact;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedContact.FullName, actualContact.FullName);
                    Assert.AreEqual(expectedContact.Email, actualContact.Email);
                    Assert.AreEqual(expectedContact.PhoneNumber, actualContact.PhoneNumber);
                    Assert.AreEqual(expectedContact.DateOfBirth, actualContact.DateOfBirth);
                    Assert.AreEqual(expectedContact.IdVk, actualContact.IdVk);
                }
                );
        }
    }
}
