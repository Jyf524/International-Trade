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
    public class RegisterMethod : BaseRepository, IRegister
    {
        public String CheckRegister(RegisterViewpage register)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            string password111 = @"^[A-Za-z0-9]+$";
            Regex rxpassword = new Regex(password111);
            string email = @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$";
            Regex rxemail = new Regex(email);
            string phone = "^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\\d{8}$";
            Regex rxphone = new Regex(phone);
            if (String.IsNullOrEmpty(register.UserName))
            {
                return "用户名不为空";
            }
            if (!rxname.IsMatch(register.UserName))
            {
                return "用户名格式错误";
            }
            var a = db.UsersInfo.Where(s => s.UserName.Contains(register.UserName));
            if (a.Count() > 0)
            {
                return "用户名已存在";
            }
            if (String.IsNullOrEmpty(register.UserPassword))
            {
                return "密码不为空";
            }
            if (!rxpassword.IsMatch(register.UserPassword))
            {
                return "密码格式错误";
            }
            if (register.UserPassword.Length < 6)
            {
                return "密码长度小于6位";
            }
            if (String.IsNullOrEmpty(register.UserPassword2))
            {
                return "请确认密码";
            }
            if (register.UserPassword != register.UserPassword2)
            {
                return "两次密码不相同";
            }
            if (String.IsNullOrEmpty(register.CompanyName))
            {
                return "企业名称不为空";
            }
            if (String.IsNullOrEmpty(register.EnglishName))
            {
                return "英文名称不为空";
            }
            if (String.IsNullOrEmpty(register.CompanyContact))
            {
                return "企业联系人不为空";
            }
            if (String.IsNullOrEmpty(register.CompanyQQ))
            {
                return "企业QQ号不为空";
            }
            if (String.IsNullOrEmpty(register.ContactType))
            {
                return "联系方式不为空";
            }
            if (!rxphone.IsMatch(register.ContactType))
            {
                return "请输入正确格式";
            }
            if (String.IsNullOrEmpty(register.ContactAddress))
            {
                return "联系地址不为空";
            }
            if (String.IsNullOrEmpty(register.Email))
            {
                return "邮箱不为空";
            }
            if (!rxemail.IsMatch(register.Email))
            {
                return "邮箱格式错误";
            }
            if (String.IsNullOrEmpty(register.Zip))
            {
                return "邮编不为空";
            }
            return "注册成功";
        }

        public void Add(RegisterViewpage register)
        {
            UserInfo UserInfo1 = new UserInfo();
            UserInfo1.UserImg = "../Content/img/222.png";
            UserInfo1.UserID = DateTime.Now.ToString("yyyyMMddHHmmss");
            UserInfo1.UserName = register.UserName;
            UserInfo1.UserPassword = register.UserPassword;
            UserInfo1.UserRole = UsersRole.CompanyUser;
            UserInfo1.EnglishName = register.EnglishName;
            UserInfo1.CompanyID = DateTime.Now.ToString("yyyyMMddHHmmss");
            UserInfo1.CompanyName = register.CompanyName;
            UserInfo1.CompanyContact = register.CompanyContact;
            UserInfo1.CompanyQQ = register.CompanyQQ;
            UserInfo1.ContactType = register.ContactType;
            UserInfo1.ContactAddress = register.ContactAddress;
            UserInfo1.Email = register.Email;
            UserInfo1.Zip = register.Zip;
            UserInfo1.RegistTime = DateTime.Now;
            UserInfo1.UserPermission = "企业用户";
            db.UsersInfo.Add(UserInfo1);
            db.SaveChanges();

        }
    }
}
