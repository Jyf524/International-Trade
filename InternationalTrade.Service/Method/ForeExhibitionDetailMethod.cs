using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class ForeExhibitionDetailMethod : BaseRepository, IForeExhibitionDetail
    {
        public ForeExhibitionDetailViewPage TradeDetail(string id)
        {
            Trade TradeInfo = new Trade();
            ForeExhibitionDetailViewPage xx = new ForeExhibitionDetailViewPage();


            TradeInfo = db.Trade.Find(id);
            if (TradeInfo == null)
            {
                return xx;
            }

            xx.TradeID = TradeInfo.TradeID;
            xx.TradeTitle = TradeInfo.TradeTitle;
            xx.TradeImg = TradeInfo.TradeImg;
            xx.TradeAddress = TradeInfo.TradeAddress;
            xx.TradeIntroduction = TradeInfo.TradeIntroduction;
            xx.TradeContact = TradeInfo.TradeContact;
            xx.Fax = TradeInfo.Fax;
            xx.ContactPhone = TradeInfo.ContactPhone;
            xx.TradeInfo = TradeInfo.TradeInfo;
            xx.TradeTime = TradeInfo.TradeTime;
            return xx;
        }

        public ForeExhibitionDetailViewPage ForeOtherApplication(string id)
        {
            ForeExhibitionDetailViewPage xx = new ForeExhibitionDetailViewPage();

            var ForeOtherApplication1 = (
                from a in db.Trade
                join y in db.TradeExamine
                on a.TradeID equals y.TradeID
                where a.TradeState == TradeState1.Online

                join x in db.UsersInfo
                on y.UserID equals x.UserID
                where y.TradeID == id

                select new ForeExhibitionDetailViewPage1
                {
                    TradeID = a.TradeID,
                    TradePeopleNum = (from b in db.Trade
                                      join c in db.TradeExamine on b.TradeID equals c.TradeID
                                      where b.TradeID == a.TradeID
                                      select b.TradeID).Count(),
                    CompanyName = x.CompanyName,
                    EnglishName = x.EnglishName,
                    TradeArea = y.TradeArea,
                    TradeTitle = a.TradeTitle,
                }).ToList();

            //var TradePeopleNum = ForeOtherApplication1.GroupBy(a => a.TradeID).Count().ToString();
            xx.aa = ForeOtherApplication1;
            return xx;
        }
    }
}
