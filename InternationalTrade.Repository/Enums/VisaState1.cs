using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Enums
{
    public enum VisaState1
    {
        None = 0,//空

        Reviewing = 1,//正在受理

        Reviewed = 2,//已审核

        All = 4//所有状态
    }
}
