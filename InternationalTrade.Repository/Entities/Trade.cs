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
    [Table("Trade")]
    public class Trade
    {
        [Key]
        public string TradeID { get; set; }
        public string TradeTitle { get; set; }
        public string TradeImg { get; set; }
        public string TradeAddress { get; set; }
        public string TradeIntroduction { get; set; }
        public string TradeContact { get; set; }
        public string Fax { get; set; }
        public string ContactPhone { get; set; }
        public string TradeInfo { get; set; }
        public TradeState1 TradeState { get; set; }
        public Nullable<System.DateTime> TradeTime { get; set; }
    }
}
