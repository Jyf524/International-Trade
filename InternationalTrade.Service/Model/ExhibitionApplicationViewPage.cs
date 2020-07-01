using InternationalTrade.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class ExhibitionApplicationViewPage
    {
        public IEnumerable<TradeExamine> aa { get; set; }//显示列表
        public string TradeExamineID { get; set; }
        public string UserID { get; set; }
        public string TradeID { get; set; }
        public string TradeArea { get; set; }
        public string TradeDocument { get; set; }
        public string TradeExamineState { get; set; }
        public Nullable<System.DateTime> TradeExamineTime { get; set; }
    }
}
