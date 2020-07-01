using InternationalTrade.Repository.Entities;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class ForeOtherApplicationMethod : BaseRepository, IForeOtherApplication
    {
        public ForeOtherApplicationViewPage Index()
        {
            ForeOtherApplicationViewPage xx = new ForeOtherApplicationViewPage();
            var ForeOther = (from a in db.Trade
                             join b in db.TradeExamine
                           on a.TradeID equals b.TradeID
                           join c in db.UsersInfo
                           on b.UserID equals c.UserID
                             select new ForeOtherApplicationViewPage1
                           {
                               
                               TradeTitle = a.TradeTitle,
                               UserName = c.UserName,
                               EnglishName = c.EnglishName,
                               TradeArea = b.TradeArea,
                           }).ToList();


            xx.aa = ForeOther;
            return xx;
        }

       
    }
}
