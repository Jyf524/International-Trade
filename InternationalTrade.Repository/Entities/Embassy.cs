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
    [Table("Embassy")]
    public class Embassy
    {
        [Key]
        public string EmbassyID { get; set; }
        public string CompanyName { get; set; }
        public EmbassyState1 EmbassyType { get; set; }
        public Nullable<System.DateTime> EmbassyTime { get; set; }
    }
}
