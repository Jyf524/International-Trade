using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IUserManagerService
    {
        String CheckUserInfo(UserManagerViewPage CheckUserInfo);//判断条件

        String CheckUserInfoSave(UserManagerViewPage CheckUserInfo,string id);//判断条件

        UserManagerViewPage Index(string searchString, UsersRole Role, int? page);

        void Add(UserManagerViewPage BookAdd);//添加功能

        String Delete(string id);//删除功能

        UserManagerViewPage UserDetail(string id);//详细功能

        void Save(UserManagerViewPage UserSave, string id);//保存功能
    }
}
