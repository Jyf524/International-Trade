using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface ITradeInfo
    {
        TradeInfoViewPage Index(string searchString, string Date, string Place, int? page);//数据显示以及查询

        String CheckTradeInfo(TradeInfoViewPage CheckTradeInfo);//判断条件

        String CheckTradeInfoSave(TradeInfoViewPage CheckTradeInfo);//判断条件

        void Add(TradeInfoViewPage TradeInfoAdd);//添加功能

        String Delete(string id);//删除功能

        TradeInfoViewPage TradeInfoDetail(string id);//详细功能

        void Save(TradeInfoViewPage TradeInfoSave, string id);//保存功能

        TradeInfoViewPage1 TradeInfoMessage(string id);//详细功能

        TradeExamineViewPage daochu();//导出
    }
}
