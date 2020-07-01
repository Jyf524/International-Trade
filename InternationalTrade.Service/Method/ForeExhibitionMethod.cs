using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Method
{
    public class ForeExhibitionMethod : BaseRepository, IForeExhibition
    {
        public ForeExhibitionViewPage Index(int? page)
        {
            ForeExhibitionViewPage xx = new ForeExhibitionViewPage();
            int pageNumber;
            int pageSizeNum;
            int ItemNum;
            int pageNum;

            var TradeInfo = db.Trade.Where(x => x.TradeState == TradeState1.Online).ToList();

            pageSizeNum = Convert.ToInt32(page);//每页显示多少条
            ItemNum = TradeInfo.Count();//数据总数
            pageNum = (ItemNum % pageSizeNum) == 0 ? (ItemNum / pageSizeNum) : (ItemNum / pageSizeNum) + 1;//总页数
            if (page == 4)
            {
                pageNumber = pageNum;
            }
            else
            {
                pageNumber = page ?? 1;
            }
            TradeInfo = TradeInfo.OrderBy(x => x.TradeID).Take(pageSizeNum).ToList();
            xx.aa = TradeInfo;
            xx.pageNumber = pageNumber;
            xx.pageNumx = pageNum;
            xx.ItemNum = ItemNum.ToString();
            return xx;
        }
    }
}
