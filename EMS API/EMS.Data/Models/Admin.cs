using EMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Data.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public long AdminId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime? DOB { get; set; }
        public byte Gender { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime? Deleted_AT { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool Status { get; set; } = true;
        public string? UserName { get; set; } = String.Empty;
        public int? Exp_Days { get; set; } = (int?)LoginManagement.Exp_days;
        public DateTime? Password_Updated_At { get; set; } = DateTime.Now;
    }
}
