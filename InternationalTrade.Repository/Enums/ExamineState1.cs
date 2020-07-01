using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Enums
{
    public enum ExamineState1
    {
        None = 0,//空

        ExaminePass = 1,//年审通过

        ExamineNoPass = 2,//年审未通过

        ExamineAccept = 3,//文件已受理

        All = 4//所有状态
    }
}
