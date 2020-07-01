using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Model
{
    public class EmbassyCertificationViewPage
    {
        public IEnumerable<Embassy> aa { get; set; }//显示列表
        public string EmbassyID { get; set; }
        public string CompanyName { get; set; }
        public string ItemNum { get; set; }
        public EmbassyState1 EmbassyType { get; set; }
        public Nullable<System.DateTime> EmbassyTime { get; set; }
    }
}
