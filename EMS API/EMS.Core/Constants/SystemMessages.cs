using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Core.Constants
{
    public static class SystemMessages
    {
        #region Account
        public const string FirstNameRequired = "First name field is required.";
        public const string LastNameRequired = "Last name field is required.";
        public const string EmailRequired = "Email Address is Required.";
        public const string EmailValidation = "Please enter valid email address.";
        public const string PasswordRequired = "Please enter your passowrd.";
        public const string PasswordValidation = "Please Provide Valid Password!";
        public const string DOB = "Please provide your date of birth.";
        public const string EmailExists = "This email address is already exists. Try with different email address.";
        public const string FirstNameValid = "Please enter first name only in alphabets.";
        public const string LastNameValid = "Please enter last name in only alphabets.";
        public const string GenderRequired = "Please select gender.";
        #endregion
    }
}
