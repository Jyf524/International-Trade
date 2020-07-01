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
    public class PersonalMethod : BaseRepository, IPersonal
    {
        public PersonalViewPage Index(string id)
        {
            PersonalViewPage xx = new PersonalViewPage();
            var UserInfo = db.UsersInfo.Where(a => a.UserName == id).ToList();
            xx.aa = UserInfo;
            return xx;
        }

        public PersonalViewPage PersonalInfoDetail(string id)
        {
            UserInfo User = new UserInfo();
            PersonalViewPage xx = new PersonalViewPage();
            User = db.UsersInfo.Find(id);
            xx.CompanyName = User.CompanyName;
            xx.CompanyContact = User.CompanyContact;
            xx.CompanyQQ = User.CompanyQQ;
            xx.ContactType = User.ContactType;
            xx.ContactAddress = User.ContactAddress;
            xx.Email = User.Email;
            xx.Zip = User.Zip;
            return xx;
        }

        public String ChangePersonalInfo(PersonalViewPage PersonalInfoChange, string id)
        {
            var UserInfo = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();
            UserInfo User = db.UsersInfo.Find(UserInfo.UserID);//寻找当前id的数据s
            User.EnglishName = PersonalInfoChange.EnglishName;
            User.CompanyName = PersonalInfoChange.CompanyName;
            User.CompanyContact = PersonalInfoChange.CompanyContact;
            User.CompanyQQ = PersonalInfoChange.CompanyQQ;
            User.ContactType = PersonalInfoChange.ContactType;
            User.ContactAddress = PersonalInfoChange.ContactAddress;
            User.Email = PersonalInfoChange.Email;
            User.Zip = PersonalInfoChange.Zip;
            db.SaveChanges();

            return "修改成功";
        }

        public String CheckChangePassWord(PersonalViewPage PersonalPassWordChange,string id)
        {

            var UserInfo1 = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();

            var UserInfo = (from b1 in db.UsersInfo
                            where b1.UserID == UserInfo1.UserID
                              select b1.UserPassword).FirstOrDefault();
            if (String.IsNullOrEmpty(PersonalPassWordChange.OldUserPassword))
            {
                return " 原密码不为空";
            }

            if (String.IsNullOrEmpty(PersonalPassWordChange.UserPassword))
            {
                return " 密码不为空";
            }
            if (UserInfo != PersonalPassWordChange.OldUserPassword)
            {
                return "原密码错误";
            }
            if (PersonalPassWordChange.UserPassword.Count()<6)
            {
                return " 密码不得小于6位";
            }
            if (String.IsNullOrEmpty(PersonalPassWordChange.UserPassword2))
            {
                return "确认密码不为空";
            }
            if (PersonalPassWordChange.UserPassword != PersonalPassWordChange.UserPassword2)
            {
                return "两次密码输入不一致";
            }
            if (PersonalPassWordChange.OldUserPassword == PersonalPassWordChange.UserPassword)
            {
                return "新密码不能与旧密码相同";
            }

            return "修改成功!";
        }

        public String ChangePassWord(PersonalViewPage PersonalPassWordChange,string id)
        {
            var UserInfo1 = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();

            UserInfo User = db.UsersInfo.Find(UserInfo1.UserID);//寻找当前id的数据
            User.UserPassword = PersonalPassWordChange.UserPassword;
            db.SaveChanges();
            return "修改成功";
        }
    }
}
