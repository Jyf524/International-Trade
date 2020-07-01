using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class ForeMessageViewPage
    {
        public string MessageID { get; set; }
        public string UserID { get; set; }
        public string TradeID { get; set; }
        public string MessageInfo { get; set; }
        public Nullable<System.DateTime> MessageTime { get; set; }
    }
}
