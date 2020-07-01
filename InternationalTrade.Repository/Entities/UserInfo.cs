using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Entities
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserImg { get; set; }
        public string UserPassword { get; set; }
        public UsersRole UserRole { get; set; }
        public string EnglishName { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContact { get; set; }
        public string CompanyQQ { get; set; }
        public string ContactType { get; set; }
        public string ContactAddress { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string UserPermission { get; set; }
        public Nullable<System.DateTime> RegistTime { get; set; }
    }
}
