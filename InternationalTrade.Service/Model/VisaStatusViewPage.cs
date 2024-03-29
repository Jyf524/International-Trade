﻿using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class VisaStatusViewPage
    {
        public IEnumerable<Visa> aa { get; set; }//显示列表
        public string VisaID { get; set; }
        public string CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ItemNum { get; set; }
        public string VisaName { get; set; }
        public string VisaType { get; set; }
        public VisaState1 VisaState { get; set; }
        public Nullable<System.DateTime> VisaTime { get; set; }
    }
}
