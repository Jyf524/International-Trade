using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class TradeExamineViewPage
    {
        public List<TradeExamineViewPage1> aa { get; set; }//显示列表
        public List<Trade> axax { get; set; }
        public int pageNumber;//当前页数
        public int pageNumx;//总页数
        public string ItemNum;
        public string searchString;
        public string Year;

        public string TradeID { get; set; }

        public string TradePeopleNum { get; set; }
    }

    public class TradeExamineViewPage1
    {

        public IEnumerable<TradeExamineViewPage2> bb { get; set; }//显示列表


        public int TradePeopleNum { get; set; }

        public string TradeExamineID { get; set; }
        public string UserID { get; set; }

        public string TradeArea { get; set; }
        public string TradeDocument { get; set; }
        public string TradeExamineFeedback { get; set; }
        public TradeExamineState1 TradeExamineState { get; set; }
        public Nullable<System.DateTime> TradeExamineTime { get; set; }

        public string TradeID { get; set; }
        public string TradeTitle { get; set; }
        public string TradeImg { get; set; }
        public string TradeAddress { get; set; }
        public TradeState1 TradeState { get; set; }
        public string TradeIntroduction { get; set; }
        public string TradeContact { get; set; }
        public string Fax { get; set; }
        public string ContactPhone { get; set; }
        public string TradeInfo { get; set; }
        public Nullable<System.DateTime> TradeTime { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPassword2 { get; set; }
        public string UserRole { get; set; }
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

    public class TradeExamineViewPage2
    {
        public string CompanyName { get; set; }

        public string TradeArea { get; set; }

        public string TradeExamineTime { get; set; }
    }
}
