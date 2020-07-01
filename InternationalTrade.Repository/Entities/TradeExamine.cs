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
    [Table("TradeExamine")]
    public class TradeExamine
    {
        [Key]
        public string TradeExamineID { get; set; }
        public string UserID { get; set; }
        public string TradeID { get; set; }
        public string TradeArea { get; set; }
        public string TradeDocument { get; set; }
        public string TradeExamineFeedback { get; set; }
        public TradeExamineState1 TradeExamineState { get; set; }
        public Nullable<System.DateTime> TradeExamineTime { get; set; }
    }
}
