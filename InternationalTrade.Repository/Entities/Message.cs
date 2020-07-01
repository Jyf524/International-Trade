using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Entities
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public string MessageID { get; set; }
        public string UserID { get; set; }
        public string TradeID { get; set; }
        public string MessageInfo { get; set; }
        public Nullable<System.DateTime> MessageTime { get; set; }
    }
}   
