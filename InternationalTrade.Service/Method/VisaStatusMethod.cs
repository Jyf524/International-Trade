using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class VisaStatusMethod : BaseRepository,IVisaStatus
    {
        public VisaStatusViewPage Index(string id)
        {
            VisaStatusViewPage xx = new VisaStatusViewPage();
            var CompanyInfo = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();
            var Visa = db.Visa.Where(a => a.CompanyName == CompanyInfo.CompanyName).ToList();
            int ItemNum = Visa.Count();
            xx.aa = Visa;
            xx.ItemNum = ItemNum.ToString();
            return xx;
        }
    }
}
