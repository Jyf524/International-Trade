using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface ITradeExamine
    {
        TradeExamineViewPage Index(string searchString, string Year, int? page);//数据显示以及查询

        TradeExamineViewPage IndexDetail(int? page);//数据显示以及查询

        TradeExamineViewPage TradeInfoDetail(string id);//详细功能

        void Pass(Array arr);//商展申请审核通过功能

        void NoPass(Array arr);//商展申请审核不通过功能

        String Confirm(string id);//确认反馈功能

        TradeExamineViewPage1 TradeExamineDetail(string id);//查看反馈信息

        String Add(TradeExamineViewPage1 VisaAdd);//签证受理

        //String Finish(string id);//申请完成功能

    }
}
