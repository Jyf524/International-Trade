using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Repository.Enums
{
    public enum TradeExamineState1
    {
        None = 0,//空

        TradeExamineAccept = 1,//审核已受理

        TradeExaminePass = 2,//审核已通过

        TradeExamineNoPass = 3,//审核已驳回

        ConfirmFeedback = 4,//确认反馈

        All = 5,//所有状态

        Finish = 6,//申请完成
    }
}
