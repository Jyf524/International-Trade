﻿using InternationalTrade.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class MessageViewPage
    {
        public IEnumerable<Message> aa { get; set; }//显示列表
        public string MessageID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string TradeID { get; set; }
        public string MessageInfo { get; set; }
        public Nullable<System.DateTime> MessageTime { get; set; }
    }

    public class TradeInfoViewPage1
    {
        public IEnumerable<MessageViewPage> aa { get; set; }//显示列表
        public int pageNumber;//当前页数
        public int pageNumx;//总页数
        public string ItemNum;
        public string searchstring;


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
