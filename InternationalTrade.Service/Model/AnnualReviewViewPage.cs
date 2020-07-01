using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class AnnualReviewViewPage
    {
        public IEnumerable<Examine> aa { get; set; }//显示列表
        public string ExamineID { get; set; }
        public string CompanyName { get; set; }
        public string PayCard { get; set; }
        public string BusinessCard { get; set; }
        public string ExamineName { get; set; }
        public ExamineState1 ExamineState { get; set; }
        public Nullable<System.DateTime> ExamineTime { get; set; }
    }
}
