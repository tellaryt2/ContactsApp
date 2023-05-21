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
        private Contact _contact = new Contact();

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
            // Assert
            Assert.Throws<ArgumentException>(() => { _contact.FullName = wrongFullName; }, message);
        }

        [Test(Description = "Позитивный тест сеттера FullName")]
        public void FullName_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctFullName = "Евгений Иванов Петрович";
            var expected = correctFullName;

            // Act
            _contact.FullName = correctFullName;
            var actual = _contact.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
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
            // Assert
            Assert.Throws<ArgumentException>(() => { _contact.Email = wrongEmail; }, message);
        }

        [Test(Description = "Позитивный тест сеттера Email")]
        public void Email_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctEmail = "testemailtusur@gmail.com";
            var expected = correctEmail;

            // Act
            _contact.Email = correctEmail;
            var actual = _contact.Email;

            // Assert
            Assert.AreEqual(expected, actual);
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
            // Assert
            Assert.Throws<ArgumentException>(() => { _contact.PhoneNumber = wrongPhoneNumber; }, message);
        }

        [Test(Description = "Позитивный тест сеттера PhoneNumber")]
        public void PhoneNumber_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctPhoneNumber = "+7 (903)-047-85-79";
            var expected = correctPhoneNumber;

            // Act
            _contact.PhoneNumber = correctPhoneNumber;
            var actual = _contact.PhoneNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Негативный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetUncorrectValueLaterToday_ReturnsSameValue()
        {
            var uncorrectDateOfBirth = new DateTime(2077, 1, 1);
            string message = "Присвоение неправильной даты рождения (позднее сегодняшней)";

            Assert.Throws<ArgumentException>(() => { _contact.DateOfBirth = uncorrectDateOfBirth; }, message);
        }

        [Test(Description = "Негативный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetUncorrectValueOldDate_ReturnsSameValue()
        {
            var uncorrectDateOfBirth = new DateTime(1899, 12, 30);
            string message = "Присвоение неправильной даты рождения (раньше 1900 года)";

            Assert.Throws<ArgumentException>(() => { _contact.DateOfBirth = uncorrectDateOfBirth; }, message);
        }

        [Test(Description = "Позитивный тест сеттера DateOfBirth")]
        public void DateOfBirth_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctDateOfBirth = new DateTime(1995, 2, 14);
            var expected = correctDateOfBirth;

            // Act
            _contact.DateOfBirth = correctDateOfBirth;
            var actual = _contact.DateOfBirth;

            // Assert
            Assert.AreEqual(expected, actual);
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
            // Assert
            Assert.Throws<ArgumentException>(() => { _contact.IdVk = wrongIdVk; }, message);
        }

        [Test(Description = "Позитивный тест сеттера IdVk")]
        public void IdVk_SetCorrectValue_ReturnsSameValue()
        {
            // Arrange
            var correctIdVk = "id328921849";
            var expected = correctIdVk;

            // Act
            _contact.IdVk = correctIdVk;
            var actual = _contact.IdVk;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест метода Clone()")]
        public void Clone_SetCorrectObject_ReturnsSameObject()
        {
            // Arrange
            Contact cloneContact = new Contact("Vladimir Petrov", "Vlad@mail.ru", "+7 902(054)-21-33",
                new DateTime(1932, 4, 5), "id32859429");
            var expected = cloneContact;

            // Act
            Contact newContact = (Contact)cloneContact.Clone();
            var actual = newContact;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expected.FullName, actual.FullName);
                    Assert.AreEqual(expected.Email, actual.Email);
                    Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
                    Assert.AreEqual(expected.DateOfBirth, actual.DateOfBirth);
                    Assert.AreEqual(expected.IdVk, actual.IdVk);
                }
                );
        }
    }
}
