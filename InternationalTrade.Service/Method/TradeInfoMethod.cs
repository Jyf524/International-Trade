using InternationalTrade.Repository.Entities;
using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class TradeInfoMethod:BaseRepository,ITradeInfo
    {
        public TradeInfoViewPage Index(string searchString, string Date, string Place, int? page)
        {

            TradeInfoViewPage xx = new TradeInfoViewPage();
            var TradeInfo = db.Trade.Where(a=>a.TradeState == TradeState1.Online).ToList();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;
            if (!String.IsNullOrEmpty(searchString))
            {
                TradeInfo = TradeInfo.Where(s => s.TradeTitle.Contains(searchString)).ToList();
            }
            if (!String.IsNullOrEmpty(Date))
            {
                TradeInfo = TradeInfo.Where(s => s.TradeTime == Convert.ToDateTime(Date)).ToList();
            }
            if (!String.IsNullOrEmpty(Place))
            {
                TradeInfo = TradeInfo.Where(s => s.TradeAddress.Contains(Place)).ToList();
            }
            pageSizeNum = 5;//每页显示多少条
            ItemNum = TradeInfo.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            TradeInfo = TradeInfo.OrderBy(x => x.TradeID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = TradeInfo;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchstring = searchString;
            return xx;
        }

        public String Delete(string id)
        {
            var Trade = db.Trade.Where(a => a.TradeID == id).ToList();
            var TradeExamine = db.TradeExamine.Where(a => a.TradeID == id).ToList();
            foreach (var i in TradeExamine)
            {
                if (i.TradeExamineState != TradeExamineState1.Finish)
                {
                    return "删除失败,该商展还有未完成的申请";
                }
            }

            Trade TradeInfo = db.Trade.Find(id);//寻找当前id的数据
            TradeInfo.TradeState = TradeState1.Outline;
            //db.Trade.Remove(TradeInfo);

            //foreach (var i in borrow)
            //{
            //    db.Borrow.Remove(i);
            //}

            db.SaveChanges();
            return "删除成功";
        }

        public void Add(TradeInfoViewPage TradeInfoAdd)
        {
            Trade TradeInfo = new Trade();
            TradeInfo.TradeID = DateTime.Now.ToString("yyyyMMddHHmmss");
            TradeInfo.TradeImg = TradeInfoAdd.TradeImg;
            TradeInfo.TradeTitle = TradeInfoAdd.TradeTitle;
            TradeInfo.TradeAddress = TradeInfoAdd.TradeAddress;
            TradeInfo.TradeIntroduction = TradeInfoAdd.TradeIntroduction;
            TradeInfo.TradeInfo = TradeInfoAdd.TradeInfo;
            TradeInfo.TradeContact = TradeInfoAdd.TradeContact;
            TradeInfo.Fax = TradeInfoAdd.Fax;
            TradeInfo.ContactPhone = TradeInfoAdd.ContactPhone;
            TradeInfo.TradeTime = TradeInfoAdd.TradeTime;
            TradeInfo.TradeState = TradeState1.Online;
            db.Trade.Add(TradeInfo);
            db.SaveChanges();
        }

        public String CheckTradeInfo(TradeInfoViewPage CheckTradeInfo)
        {

            if (String.IsNullOrEmpty(CheckTradeInfo.TradeTitle))
            {
                return "标题不为空";
            }
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(CheckTradeInfo.TradeTitle))
            {
                return "请输入正确格式";
            }
            if (CheckTradeInfo.TradeTime.ToString() == "")
            {
                return "展会时间不为空";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeAddress))
            {
                return "展会地点不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeAddress))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeIntroduction))
            {
                return "展会简介不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeIntroduction))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeInfo))
            {
                return "展会内容不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeInfo))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeContact))
            {
                return "联系人不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeContact))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.Fax))
            {
                return "传真不为空";
            }
            string phone = "^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\\d{8}$";
            Regex rxphone = new Regex(phone);
            if (String.IsNullOrEmpty(CheckTradeInfo.ContactPhone))
            {
                return "联系电话不为空";
            }
            if (!rxphone.IsMatch(CheckTradeInfo.ContactPhone))
            {
                return "请输入正确联系电话格式";
            }
            return "添加成功！";
        }

        public String CheckTradeInfoSave(TradeInfoViewPage CheckTradeInfo)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            string phone = "^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\\d{8}$";
            Regex rxphone = new Regex(phone);
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeTitle))
            {
                return "标题不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeTitle))
            {
                return "请输入正确格式";
            }
            if (CheckTradeInfo.TradeTime.ToString() == "")
            {
                return "展会时间不为空";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeAddress))
            {
                return "展会地点不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeAddress))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeIntroduction))
            {
                return "展会简介不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeIntroduction))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeInfo))
            {
                return "展会内容不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeInfo))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.TradeContact))
            {
                return "联系人不为空";
            }
            if (!rxname.IsMatch(CheckTradeInfo.TradeContact))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.Fax))
            {
                return "传真不为空";
            }
            if (String.IsNullOrEmpty(CheckTradeInfo.ContactPhone))
            {
                return "联系电话不为空";
            }
            if (!rxphone.IsMatch(CheckTradeInfo.ContactPhone))
            {
                return "请输入正确联系电话格式";
            }
            return "修改成功！";
        }

        public TradeInfoViewPage TradeInfoDetail(string id)
        {
            Trade TradeInfo = db.Trade.Find(id);//寻找当前id的数据
            TradeInfoViewPage TradeDetail = new TradeInfoViewPage();
            TradeDetail.TradeTitle = TradeInfo.TradeTitle;
            TradeDetail.TradeTime = TradeInfo.TradeTime;
            TradeDetail.TradeImg = TradeInfo.TradeImg;
            TradeDetail.TradeAddress = TradeInfo.TradeAddress;
            TradeDetail.TradeIntroduction = TradeInfo.TradeIntroduction;
            TradeDetail.TradeInfo = TradeInfo.TradeInfo;
            TradeDetail.TradeContact = TradeInfo.TradeContact;
            TradeDetail.Fax = TradeInfo.Fax;
            TradeDetail.ContactPhone = TradeInfo.ContactPhone;
            return TradeDetail;
        }

        public void Save(TradeInfoViewPage TradeInfoSave, string idd)
        {
            Trade TradeInfo = db.Trade.Find(idd);
            if (TradeInfoSave.TradeImg != "undefined")
            {
                TradeInfo.TradeImg = TradeInfoSave.TradeImg;
            }
            
            TradeInfo.TradeTitle = TradeInfoSave.TradeTitle;
            TradeInfo.TradeTime = TradeInfoSave.TradeTime;
            TradeInfo.TradeAddress = TradeInfoSave.TradeAddress;
            TradeInfo.TradeIntroduction = TradeInfoSave.TradeIntroduction;
            TradeInfo.TradeInfo = TradeInfoSave.TradeInfo;
            TradeInfo.TradeContact = TradeInfoSave.TradeContact;
            TradeInfo.Fax = TradeInfoSave.Fax;
            TradeInfo.ContactPhone = TradeInfoSave.ContactPhone;
            db.SaveChanges();
        }

        public TradeInfoViewPage1 TradeInfoMessage(string id)
        {
            TradeInfoViewPage1 xx = new TradeInfoViewPage1();
            var MessageInfo1 = (from a in db.Message
                           join b in db.Trade
                           on a.TradeID equals b.TradeID
                           where a.TradeID ==id
                           select new MessageViewPage
                           {
                               UserID = a.UserID,
                               UserName = (from x in db.UsersInfo
                                           join c in db.Message on x.UserID equals c.UserID
                                           where x.UserID == a.UserID
                                           select x.UserName).FirstOrDefault(),
                               MessageInfo = a.MessageInfo,
                               MessageTime = a.MessageTime,

                           }).ToList();
            xx.aa = MessageInfo1;
            return xx;
        }

        public TradeExamineViewPage daochu()
        {
            TradeExamineViewPage xx = new TradeExamineViewPage();
            var MessageInfo1 = (from a in db.Trade
                                       join b in db.TradeExamine
                                       on a.TradeID equals b.TradeID

                                       join c in db.UsersInfo
                                       on b.UserID equals c.UserID

                                select new TradeExamineViewPage1
                                {
                                    CompanyName = c.CompanyName,
                                    TradeAddress = a.TradeAddress
                                }).ToList();
            xx.aa = MessageInfo1;
            return xx;
        }
    }

}
