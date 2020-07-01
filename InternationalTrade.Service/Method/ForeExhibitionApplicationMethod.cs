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
    public class ForeExhibitionApplicationMethod : BaseRepository, IForeExhibitionApplication
    {
        public String Add(ForeExhibitionApplicationViewPage ExhibitionApplicationAdd, string id, string UserID)
        {
            TradeExamine TradeExamineInfo = new TradeExamine();
           
            var UserInfo = db.UsersInfo.Where(a => a.UserName == UserID).FirstOrDefault();

            var TradeExamineInfoxx = db.TradeExamine.Where(a => a.UserID == UserInfo.UserID).ToList();
            var TradeExamineInfoxxx = TradeExamineInfoxx.Where(a => a.TradeID == id).ToList();

            if (TradeExamineInfoxxx.Count() != 0)
            {
                return "您已申请，请勿重新申请";
            }

            TradeExamineInfo.TradeExamineID = DateTime.Now.ToString("yyyyMMddHHmmss");
            TradeExamineInfo.UserID = UserInfo.UserID;
            TradeExamineInfo.TradeID = id;
            if (ExhibitionApplicationAdd.TradeArea == null)
            {
                return "请输入商展面积"; 
            }
            TradeExamineInfo.TradeArea = ExhibitionApplicationAdd.TradeArea;
            if (ExhibitionApplicationAdd.TradeDocument == null)
            {
                return "请上传文件";
            }
            TradeExamineInfo.TradeDocument = ExhibitionApplicationAdd.TradeDocument;
            TradeExamineInfo.TradeExamineState = TradeExamineState1.TradeExamineAccept;
            TradeExamineInfo.TradeExamineTime = DateTime.Now;
            db.TradeExamine.Add(TradeExamineInfo);
            db.SaveChanges();
            return "申请成功";
        }
    }
}
