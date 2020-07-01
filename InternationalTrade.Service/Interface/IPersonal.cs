using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IPersonal
    {
        PersonalViewPage Index(string id);//显示用户名，头像，用户ID

        PersonalViewPage PersonalInfoDetail(string id);//个人信息显示

        String ChangePersonalInfo(PersonalViewPage PersonalInfoChange, string id);//修改个人信息

        String CheckChangePassWord(PersonalViewPage PersonalPassWordChange, string id);//修改密码判断条件

        String ChangePassWord(PersonalViewPage PersonalPassWordChange, string id);//修改密码
    }
}
