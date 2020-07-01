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
    public class TradeExamineMethod : BaseRepository, ITradeExamine
    {
        public TradeExamineViewPage Index(string searchString, string Year, int? page)
        {
            TradeExamineViewPage xx = new TradeExamineViewPage();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;

            var TradeExamine1 = (
                from a in db.Trade
                where a.TradeState == TradeState1.Online
                select new TradeExamineViewPage1
                        {

                            TradeID = a.TradeID,
                            TradePeopleNum = (from b in db.Trade
                                              join c in db.TradeExamine on b.TradeID equals c.TradeID
                                              where b.TradeID == a.TradeID
                                              select b.TradeID).Count(),
                            TradeTitle = a.TradeTitle,
                            TradeTime = a.TradeTime,
                            TradeAddress = a.TradeAddress,
                            TradeImg = a.TradeImg,
                            TradeState = a.TradeState,
                            TradeContact = a.TradeContact,
                            TradeInfo = a.TradeInfo,
                        }).ToList();



            if (!String.IsNullOrEmpty(searchString))
            {
                TradeExamine1 = TradeExamine1.Where(s => s.TradeTitle.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(Year))
            {
                TradeExamine1 = TradeExamine1.Where(s => s.TradeTime.Value.Year.ToString() == Year).ToList();
            }

            var TradePeopleNum = TradeExamine1.GroupBy(a => a.TradeID).Count().ToString();

            pageSizeNum = 5;//每页显示多少条
            ItemNum = TradeExamine1.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            TradeExamine1 = TradeExamine1.OrderBy(x => x.TradeExamineID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = TradeExamine1;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchString = searchString;
            xx.Year = Year;
            return xx;
        }

        public TradeExamineViewPage IndexDetail(int? page)
        {
            TradeExamineViewPage xx = new TradeExamineViewPage();
            return xx;
        }

        public TradeExamineViewPage TradeInfoDetail(string id)
        {
            TradeExamineViewPage xx = new TradeExamineViewPage();
            var TradeExamineDetail1 = (from a in db.Trade
                                       join b in db.TradeExamine
                                       on a.TradeID equals b.TradeID

                                       join c in db.UsersInfo
                                       on b.UserID equals c.UserID
                                       where b.TradeID == id
                                       select new TradeExamineViewPage1
                                       {
                                           TradeID = id,
                                           TradeTitle = a.TradeTitle,
                                           TradeTime = a.TradeTime,
                                           TradeAddress = a.TradeAddress,
                                           TradeIntroduction = a.TradeIntroduction,
                                           TradeInfo = a.TradeInfo,
                                           TradeContact = a.TradeContact,
                                           TradeArea = b.TradeArea,
                                           CompanyID = c.CompanyID,
                                           CompanyName = c.CompanyName,
                                           TradeExamineState = b.TradeExamineState,
                                           TradeExamineTime = b.TradeExamineTime,
                                           TradeExamineID = b.TradeExamineID,
                                           TradeDocument = b.TradeDocument,
                                       }).ToList();

            var TradeInfo = db.Trade.Where(a=>a.TradeID == id).ToList();
            xx.axax = TradeInfo;
            xx.aa = TradeExamineDetail1;
            return xx;
        }

        public void Pass(Array arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var TradeExamineID = arr.GetValue(i);
                TradeExamine TradeExamine1 = db.TradeExamine.Find(TradeExamineID);
                if (TradeExamine1.TradeExamineState == TradeExamineState1.TradeExamineAccept)
                {
                    TradeExamine1.TradeExamineState = TradeExamineState1.TradeExaminePass;
                    db.SaveChanges();
                }
            }
        }

        public void NoPass(Array arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var TradeExamineID = arr.GetValue(i);
                TradeExamine TradeExamine1 = db.TradeExamine.Find(TradeExamineID);
                if (TradeExamine1.TradeExamineState == TradeExamineState1.TradeExamineAccept)
                {
                    TradeExamine1.TradeExamineState = TradeExamineState1.TradeExamineNoPass;
                    db.SaveChanges();
                }
            }
        }

        public String Confirm(string id)
        {
            var TradeExamine = db.TradeExamine.Where(a => a.TradeExamineID == id).ToList();
            TradeExamine TradeExamineInfo = db.TradeExamine.Find(id);//寻找当前id的数据
            TradeExamineInfo.TradeExamineState = TradeExamineState1.ConfirmFeedback;
            db.SaveChanges();
            return "反馈成功";
        }

        public TradeExamineViewPage1 TradeExamineDetail(string id)
        {
            TradeExamine TradeExamineInfo = db.TradeExamine.Find(id);//寻找当前id的数据
            TradeExamineViewPage1 TradeExamineDetail = new TradeExamineViewPage1();
            TradeExamineDetail.TradeExamineFeedback = TradeExamineInfo.TradeExamineFeedback;
            return TradeExamineDetail;
        }

        public String Add(TradeExamineViewPage1 VisaAdd)
        {
            Visa VisaInfo = new Visa();
            var CompanyInfo = db.UsersInfo.Where(a => a.CompanyID == VisaAdd.CompanyID).FirstOrDefault();
            var VisaInfo1 = db.Visa.ToList();
            var VisaInfo2 = VisaInfo1.Where(s => s.CompanyName ==(CompanyInfo.CompanyName)).ToList();

            if (VisaInfo2.Count > 0)
            {
                return "该签证已受理";
            }
            else
            {
                var TradeExamine = db.TradeExamine.Where(a => a.TradeExamineID == VisaAdd.TradeExamineID).ToList();
                TradeExamine TradeExamineInfo = db.TradeExamine.Find(VisaAdd.TradeExamineID);//寻找当前id的数据
                TradeExamineInfo.TradeExamineState = TradeExamineState1.Finish;


                VisaInfo.VisaID = DateTime.Now.ToString("yyyyMMddHHmmss");
                VisaInfo.CompanyID = VisaAdd.CompanyID;
                VisaInfo.CompanyName = CompanyInfo.CompanyName;
                VisaInfo.VisaName = "高职校";
                VisaInfo.VisaType = "中国 ";
                VisaInfo.VisaState = VisaState1.Reviewing;
                VisaInfo.VisaTime = DateTime.Now;
                db.Visa.Add(VisaInfo);
                db.SaveChanges();
            }
            return "签证受理成功";
        }

        //public String Finish(string id)
        //{
        //    var TradeExamine = db.TradeExamine.Where(a => a.TradeExamineID == id).ToList();
        //    TradeExamine TradeExamineInfo = db.TradeExamine.Find(id);//寻找当前id的数据
        //    TradeExamineInfo.TradeExamineState = TradeExamineState1.Finish;
        //    db.SaveChanges();
        //    return "申请完成";
        //}
    }
}
