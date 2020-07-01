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
    public class ExhibitionApplicationMethod : BaseRepository, IExhibitionApplication
    {
        public ForeExhibitionApplicationViewPage Index(string id)
        {
            ForeExhibitionApplicationViewPage xx = new ForeExhibitionApplicationViewPage();

            var UserInfo = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();

            var ExhibitionApplication = (from a in db.Trade
                                         join b in db.TradeExamine
                                         on a.TradeID equals b.TradeID
                                         where b.UserID == UserInfo.UserID
                                         select new ForeOtherApplicationViewPage1
                                         {
                                             TradeID = a.TradeID,
                                             TradeTitle = a.TradeTitle,
                                             TradeExamineTime = b.TradeExamineTime,
                                             TradeAddress = a.TradeAddress,
                                             TradeImg = a.TradeImg,
                                             TradeExamineState = b.TradeExamineState,
                                             TradeContact = a.TradeContact,
                                             ContactPhone = a.ContactPhone,
                                             TradeInfo = a.TradeInfo,
                                         }).ToList();
            int ItemNum = ExhibitionApplication.Count();
            xx.ItemNum = ItemNum.ToString();
            xx.aa = ExhibitionApplication;
            return xx;
        }

        public ForeExhibitionApplicationViewPage ExhibitionApplicatioDetail(string id, string idd)
        {
            ForeExhibitionApplicationViewPage xx = new ForeExhibitionApplicationViewPage();
            var UserInfo = db.UsersInfo.Where(a => a.UserName == idd).FirstOrDefault();
            var ExhibitionApplication = (from a in db.Trade
                                         join b in db.TradeExamine
                                         on a.TradeID equals b.TradeID
                                         where b.TradeID == id && b.UserID == UserInfo.UserID
                                         select new ForeOtherApplicationViewPage1
                                         {
                                             TradeExamineFeedback = b.TradeExamineFeedback,
                                             TradeID = a.TradeID,
                                             TradeTitle = a.TradeTitle,
                                             TradeExamineTime = a.TradeTime,
                                             TradeAddress = a.TradeAddress,
                                             TradeImg = a.TradeImg,
                                             TradeExamineState = b.TradeExamineState,
                                             TradeContact = a.TradeContact,
                                             TradeInfo = a.TradeInfo,
                                             TradeIntroduction = a.TradeIntroduction,
                                         }).ToList();

            xx.aa = ExhibitionApplication;
            return xx;
        }

        public String TradeExamineFeedback(ForeExhibitionApplicationViewPage TradeExamineFeedbackAdd, string id,string idd)
        {
            var UserInfo = db.UsersInfo.Where(a => a.UserName == idd).FirstOrDefault();
            var TradeExamineInfo = db.TradeExamine.Where(a => a.UserID == UserInfo.UserID).ToList();//寻找当前id的数据
            var TradeExamineInfo1 = TradeExamineInfo.Where(a => a.TradeID == id).FirstOrDefault();
            if (TradeExamineFeedbackAdd.TradeExamineFeedback == null)
            {
                return "请输入反馈内容";
            }
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(TradeExamineFeedbackAdd.TradeExamineFeedback))
            {
                return "请输入正确格式";
            }
            TradeExamineInfo1.TradeExamineFeedback = TradeExamineFeedbackAdd.TradeExamineFeedback;
            TradeExamineInfo1.TradeExamineState = TradeExamineState1.ConfirmFeedback;
            db.SaveChanges();
            return "反馈成功";

        }
    }
}
