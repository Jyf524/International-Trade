using InternationalTrade.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class LoginMethod : BaseRepository, ILogin
    {
        public String GetLogin(string UserName, string password, string code)
        {
            if (String.IsNullOrEmpty(UserName))
            {
                return "用户名不为空";
            }
            if (String.IsNullOrEmpty(password))
            {
                return "密码不为空";
            }
            if (String.IsNullOrEmpty(code))
            {
                return "验证码不为空";
            }


            var list = db.UsersInfo.Where(x => x.UserName == UserName).ToList();
            string Role;
            try
            {
                Role = db.UsersInfo.Where(x => x.UserName == UserName).ToList().First().UserRole.ToString();
            }
            catch
            {
                return "用户名不存在！";
            }
            if (list.Count() == 0)
            {
                return "用户名或密码错误！";
            }
            if (list.FirstOrDefault().UserPassword != password)
            {
                return "密码错误！";
            }
            if (Role == "SystemManager")
            {
                return "系统管理员登录成功";
            }
            if (Role == "EmbassyManager")
            {
                return "出认证处管理员登录成功";
            }
            if (Role == "TradeManager")
            {
                return "国际展览部管理员登录成功";
            }
            return "登录成功";
        }
    }
}
