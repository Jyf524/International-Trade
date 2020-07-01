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
    public class UserManagerMethod : BaseRepository, IUserManagerService
    {
        public UserManagerViewPage Index(string searchString, UsersRole Role, int? page)
        {

            UserManagerViewPage xx = new UserManagerViewPage();
            var Users = db.UsersInfo.Where(s => s.UserRole != UsersRole.SystemManager).ToList();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;

            if (Role == UsersRole.All)
            {
                Users = Users.Where(s => s.UserName.Contains(searchString)).ToList();
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    Users = Users.Where(s => s.UserName.Contains(searchString)).ToList();
                }
                Users = Users.Where(s => s.UserRole == Role).ToList();
            }

            pageSizeNum = 5;//每页显示多少条
            ItemNum = Users.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            Users = Users.OrderBy(x => x.UserID).Skip((pageNumber - 1) * pageSizeNum).Take(pageSizeNum).ToList();
            xx.aa = Users;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            xx.searchstring = searchString;
            xx.Role = Role;
            return xx;
        }

        public String Delete(string id)
        {
            var Users = db.UsersInfo.Where(a => a.UserID == id).ToList();

            UserInfo UserInfo = db.UsersInfo.Find(id);//寻找当前id的数据
            db.UsersInfo.Remove(UserInfo);

            db.SaveChanges();
            return "删除成功";
        }

        public void Add(UserManagerViewPage UserAdd)
        {
            UserInfo UserInfo = new UserInfo();
            UserInfo.UserID = DateTime.Now.ToString("yyyyMMddHHmmss");
            UserInfo.UserPassword = UserAdd.UserPassword;
            UserInfo.UserName = UserAdd.UserName;
            UserInfo.UserImg = "../Content/img/222.png";
            UserInfo.ContactType = UserAdd.ContactType;
            UserInfo.Email = UserAdd.Email;
            UserInfo.ContactAddress = UserAdd.ContactAddress;
            UserInfo.RegistTime = DateTime.Now;
            if (UserAdd.Role == UsersRole.EmbassyManager)
            {
                UserInfo.UserRole = UsersRole.EmbassyManager;
            }
            if (UserAdd.Role == UsersRole.TradeManager)
            {
                UserInfo.UserRole = UsersRole.TradeManager;
            }
            if (UserAdd.Role == UsersRole.EmbassyManager)
            {
                UserInfo.UserPermission = "出认证处管理员";
            }
            if (UserAdd.Role == UsersRole.TradeManager)
            {
                UserInfo.UserPermission = "国际展览部管理员";
            }
            db.UsersInfo.Add(UserInfo);
            db.SaveChanges();
        }

        public String CheckUserInfo(UserManagerViewPage CheckUserInfo)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (String.IsNullOrEmpty(CheckUserInfo.UserName))
            {
                return "用户名不为空";
            }
            if (!rxname.IsMatch(CheckUserInfo.UserName))
            {
                return "用户名格式错误";
            }
            var a = db.UsersInfo.Where(s => s.UserName.Contains(CheckUserInfo.UserName));
            if (a.Count() > 0)
            {
                return "用户名已存在";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.UserPassword))
            {
                return "密码不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.ContactType))
            {
                return "联系方式不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.ContactAddress))
            {
                return "联系地址不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.Email))
            {
                return "邮箱不为空";
            }
            return "添加成功！";
        }

        public String CheckUserInfoSave(UserManagerViewPage CheckUserInfo,string id)
        {
            string name = "^[a-zA-Z0-9\u4e00-\u9fa5]{1,}$";//字母数字汉字
            Regex rxname = new Regex(name);
            if (String.IsNullOrEmpty(CheckUserInfo.UserName))
            {
                return "用户名不为空";
            }
            if (!rxname.IsMatch(CheckUserInfo.UserName))
            {
                return "用户名格式错误";
            }
            var UserInfos = (from a1 in db.UsersInfo
                             where a1.UserID == (from a2 in db.UsersInfo where a2.UserName == CheckUserInfo.UserName select a2.UserID).FirstOrDefault()
                             where a1.UserID != id
                             select a1).Count();
            if (UserInfos > 0)
            {
                return "用户名已存在！";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.UserPassword))
            {
                return "密码不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.ContactType))
            {
                return "联系方式不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.ContactAddress))
            {
                return "联系地址不为空";
            }
            if (String.IsNullOrEmpty(CheckUserInfo.Email))
            {
                return "邮箱不为空";
            }
            return "修改成功！";
        }

        public UserManagerViewPage UserDetail(string id)
        {
            UserInfo UserInfo = db.UsersInfo.Find(id);//寻找当前id的数据
            UserManagerViewPage UserDetail = new UserManagerViewPage();
            UserDetail.UserName = UserInfo.UserName;
            UserDetail.UserPassword = UserInfo.UserPassword;
            UserDetail.ContactType = UserInfo.ContactType;
            UserDetail.Email = UserInfo.Email;
            UserDetail.Role = UserInfo.UserRole;
            UserDetail.UserRole = UserInfo.UserRole;


            if (UserInfo.UserPermission == "出认证处管理员")
            {
                UserDetail.UserPermission = UsersRole.EmbassyManager.ToString();
            }
            if (UserInfo.UserPermission == "国际展览部管理员")
            {
                UserDetail.UserPermission = UsersRole.TradeManager.ToString();
            }


            UserDetail.ContactAddress = UserInfo.ContactAddress;
            return UserDetail;
        }

        public void Save(UserManagerViewPage UserSave, string id)
        {
            UserInfo UserInfo = db.UsersInfo.Find(id);
            UserInfo.UserName = UserSave.UserName;
            UserInfo.UserPassword = UserSave.UserPassword;
            UserInfo.ContactType = UserSave.ContactType;
            UserInfo.Email = UserSave.Email;
            if (UserInfo.UserRole != UsersRole.CompanyUser)
            {
                if (UserSave.Role == UsersRole.EmbassyManager)
                {
                    UserInfo.UserRole = UsersRole.EmbassyManager;
                    UserInfo.UserPermission = "出认证处管理员";
                }
                if (UserSave.Role == UsersRole.TradeManager)
                {
                    UserInfo.UserRole = UsersRole.TradeManager;
                    UserInfo.UserPermission = "国际展览部管理员";
                }
            }
            db.SaveChanges();
        }
    }
}
