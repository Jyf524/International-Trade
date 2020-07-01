using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IForeExhibitionDetail
    {
        ForeExhibitionDetailViewPage TradeDetail(string id);//显示

        ForeExhibitionDetailViewPage ForeOtherApplication(string id);//展会申请人
    }
}
