using InternationalTrade.Repository.Entities;
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
    public class ForeMessageMethod:BaseRepository,IForeMessage
    {
        public String Message(ForeMessageViewPage MessageAdd,string id,string UserID)
        {
            Message MessageInfo = new Message();
            var UserInfo = db.UsersInfo.Where(a => a.UserName == UserID).FirstOrDefault();
            var MessageInfo1 = db.Message.Where(a => a.UserID == UserInfo.UserID).ToList();
            var MessageInfo2 = MessageInfo1.Where(a => a.TradeID == id).ToList();
            if (MessageInfo2.Count > 0)
            {
                return "已留言,请勿重复留言";
            }
            if (MessageAdd.MessageInfo == null)
            {
                return "请填写留言内容";
            }
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (!rxname.IsMatch(MessageAdd.MessageInfo))
            {
                return "请输入正确格式";
            }
            MessageInfo.MessageID = DateTime.Now.ToString("yyyyMMddHHmmss");
            MessageInfo.UserID = UserInfo.UserID;
            MessageInfo.TradeID = id;
            MessageInfo.MessageInfo = MessageAdd.MessageInfo;
            MessageInfo.MessageTime = DateTime.Now;
            db.Message.Add(MessageInfo);
            db.SaveChanges();
            return "留言成功";
        }
    }
}
