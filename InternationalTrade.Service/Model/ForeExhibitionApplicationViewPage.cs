using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class ForeExhibitionApplicationViewPage
    {
        public IEnumerable<ForeOtherApplicationViewPage1> aa { get; set; }
        public string TradeExamineID { get; set; }
        public string TradeArea { get; set; }
        public string ItemNum { get; set; }
        public string TradeDocument { get; set; }
        public string TradeExamineState { get; set; }
        public string TradeExamineFeedback { get; set; }
        public Nullable<System.DateTime> TradeExamineTime { get; set; }
    }

    public class ForeExhibitionApplicationViewPage1
    {

        public string TradeID { get; set; }
        public string TradeTitle { get; set; }
        public string TradeImg { get; set; }
        public string TradeAddress { get; set; }
        public string TradeIntroduction { get; set; }
        public string TradeContact { get; set; }
        public string Fax { get; set; }
        public string ContactPhone { get; set; }
        public string TradeInfo { get; set; }
        public Nullable<System.DateTime> TradeTime { get; set; }
    }
}
