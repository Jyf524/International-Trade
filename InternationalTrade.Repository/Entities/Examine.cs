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
    [Table("Examine")]
    public class Examine
    {
        [Key]
        public string ExamineID { get; set; }
        public string CompanyName { get; set; }
        public string PayCard { get; set; }
        public string BusinessCard { get; set; }
        public string ExamineName { get; set; }
        public ExamineState1 ExamineState { get; set; }
        public Nullable<System.DateTime> ExamineTime { get; set; }
    }
}
