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
    [Table("Visa")]
    public class Visa
    {
        [Key]
        public string VisaID { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string VisaName { get; set; }
        public string VisaType { get; set; }
        public VisaState1 VisaState { get; set; }
        public Nullable<System.DateTime> VisaTime { get; set; }
    }
}
