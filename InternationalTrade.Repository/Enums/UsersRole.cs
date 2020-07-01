using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Enums
{
    public enum UsersRole
    {
        None = 0,//空

        SystemManager=1,//系统管理员

        EmbassyManager=2,//出认证处管理员

        TradeManager=3,//国际展览部管理员

        CompanyUser=4,//企业用户

        All=5//所有用户

    }
}
