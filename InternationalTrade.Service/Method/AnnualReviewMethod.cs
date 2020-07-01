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
    public class AnnualReviewMethod : BaseRepository,IAnnualReview
    {
        public AnnualReviewViewPage Index(string id)
        {
            AnnualReviewViewPage xx = new AnnualReviewViewPage();
            var CompanyInfo = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();
            var Examine = db.Examine.Where(a => a.CompanyName == CompanyInfo.CompanyName).ToList();
            xx.aa = Examine;
            return xx;
        }

        public AnnualReviewViewPage AnnualReviewDetail(string id)
        { 
            AnnualReviewViewPage xx = new AnnualReviewViewPage();
            var ExamineInfo = db.Examine.Find(id);
            xx.ExamineID = ExamineInfo.ExamineID;
            xx.CompanyName = ExamineInfo.CompanyName;
            xx.ExamineName = ExamineInfo.ExamineName;
            xx.PayCard = ExamineInfo.PayCard;
            xx.BusinessCard = ExamineInfo.BusinessCard;
            xx.ExamineState = ExamineInfo.ExamineState;
            xx.ExamineTime = ExamineInfo.ExamineTime;
            return xx;
        }

        public String AnnualReviewUpload(AnnualReviewViewPage AnnualReviewAdd, string idd)
        {
            Examine ExamineInfo = new Examine();

            var UserInfo = db.UsersInfo.Where(a => a.UserName == idd).FirstOrDefault();


            ExamineInfo.ExamineID = DateTime.Now.ToString("yyyyMMddHHmmss");
            ExamineInfo.CompanyName = UserInfo.CompanyName;
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(AnnualReviewAdd.ExamineName))
            {
                return "请输入正确格式";
            }
            ExamineInfo.ExamineName = AnnualReviewAdd.ExamineName;
            ExamineInfo.PayCard = AnnualReviewAdd.PayCard;
            ExamineInfo.BusinessCard = AnnualReviewAdd.BusinessCard;
            ExamineInfo.ExamineState = ExamineState1.ExamineAccept;
            ExamineInfo.ExamineTime = DateTime.Now;
            db.Examine.Add(ExamineInfo);
            db.SaveChanges();
            return "申请成功";
        }
    }
}
