using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    internal class Contact
    {
        private string _fullName;
        private string _email;
        private string _phoneNumber;
        private string _dateBirth;
        private string _idVk;

        private Contact()
        {
            _fullName = "";
            _email = "";
            _phoneNumber = "";
            _dateBirth = "";
            _idVk = "";
        }

        private void SetFullName(string fullName)
        {
            _fullName = fullName;
        }

        private void SetEmail(string email)
        {
            _email = email;
        }

        private void SetPhoneNumber(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        private void SetDateBirth(string dateBirth)
        {
            _dateBirth = dateBirth;
        }

        private void SetIdVk(string idVk)
        {
            _idVk = idVk;
        }

        private string GetFullName()
        {
            return _fullName;
        }

        private string GetEmail()
        {
            return _email;
        }
        private string GetPhoneNumber()
        {
            return _phoneNumber;
        }
        private string GetDateBirth()
        {
            return _dateBirth;
        }

        private string GetIdVk()
        {
            return _idVk;
        }
    }
}
