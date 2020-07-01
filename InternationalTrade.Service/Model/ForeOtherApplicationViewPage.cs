using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class ForeOtherApplicationViewPage
    {
        public IEnumerable<ForeOtherApplicationViewPage1> aa { get; set; }
        public string OtherApplicationNum { get; set; }
        
        
    }

    public class ForeOtherApplicationViewPage1
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


        public string TradeExamineID { get; set; }
        public string TradeArea { get; set; }
        public string TradeDocument { get; set; }
        public string TradeExamineFeedback { get; set; }
        public TradeExamineState1 TradeExamineState { get; set; }
        public Nullable<System.DateTime> TradeExamineTime { get; set; }
        
        

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string EnglishName { get; set; }
    }
}
