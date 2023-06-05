﻿using EMS.Core.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTO.Employee
{
    [DataContract]
    public class CreateEmployeeDto
    {
        [DataMember]
        [Required(ErrorMessage =SystemMessages.FirstNameRequired)]
        [RegularExpression(RegularExpression.FirstName, ErrorMessage =SystemMessages.FirstNameValid)]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        [Required(ErrorMessage = SystemMessages.LastNameRequired)]
        [RegularExpression(RegularExpression.FirstName, ErrorMessage = SystemMessages.LastNameValid)]
        public string? LastName { get; set; } = string.Empty;
        [DataMember]
        [Required(ErrorMessage = SystemMessages.EmailRequired)]
        [RegularExpression(RegularExpression.Email, ErrorMessage = SystemMessages.EmailValidation)]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        [Required(ErrorMessage = SystemMessages.PasswordRequired)]
        [RegularExpression(RegularExpression.Password, ErrorMessage = SystemMessages.PasswordValidation)]
        public string Password { get; set; } = String.Empty;
        [Required(ErrorMessage = SystemMessages.ConfirmPasswordRequired)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = String.Empty;
        [DataMember]
        [Required(ErrorMessage = SystemMessages.DOB)]
        public DateTime? DOB { get; set; }
        [DataMember]
        [Required(ErrorMessage = SystemMessages.GenderRequired)]
        public byte Gender { get; set; } = (byte)EMS.Core.Enums.Gender.Male;
    }
}
