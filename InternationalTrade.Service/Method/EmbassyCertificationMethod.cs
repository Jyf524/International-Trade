using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class EmbassyCertificationMethod : BaseRepository, IEmbassyCertification
    {
        public EmbassyCertificationViewPage Index(string id)
        {
            EmbassyCertificationViewPage xx = new EmbassyCertificationViewPage();

            var CompanyInfo = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();
            
            var EmbassyInfo = db.Embassy.Where(a=>a.CompanyName == CompanyInfo.CompanyName).ToList();
            int ItemNum = EmbassyInfo.Count();
            xx.aa = EmbassyInfo;
            xx.ItemNum = ItemNum.ToString();
            return xx;
        }
    }
}
