using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class ExamineViewPage
    {
        public IEnumerable<Examine> aa { get; set; }//显示列表
        public int pageNumber;//当前页数
        public int pageNumx;//总页数
        public string ItemNum;
        public string searchstring;
        public string Year;


        public string ExamineID { get; set; }
        public string CompanyName { get; set; }
        public string ExamineName { get; set; }
        public string PayCard { get; set; }
        public string BusinessCard { get; set; }
        public ExamineState1 ExamineState { get; set; }
        public Nullable<System.DateTime> ExamineTime { get; set; }
    }
}
