using EMS.Core.Enums;
using EMS.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    [Table("Employees")]
    public class Employee: BaseDomainEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public byte Gender { get; set; } = (byte)EMS.Core.Enums.Gender.Male;
        public int? Attemps { get; set; } = (int)LoginManagement.Attemps;
        public int? Total_Attemps { get; set; } = (int)LoginManagement.Total_Attemps;
        public bool Status { get; set; }
        public bool IsLocked { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public int? Exp_days { get; set; } = (int)LoginManagement.Exp_days;
        public DateTime? Password_Updated_At { get; set; } = DateTime.Now;


    }
}
