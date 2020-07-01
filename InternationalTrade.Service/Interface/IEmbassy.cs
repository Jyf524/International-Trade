using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IEmbassy
    {
            EmbassyViewPage Index(string searchString, EmbassyState1 State, int? page);//数据显示以及查询

            String CheckEmbassyInfo(EmbassyViewPage CheckEmbassyInfo);//判断条件

            void Add(EmbassyViewPage EmbassyAdd);//添加功能

            String Delivery(string id);//送外办功能

            String Finish(string id);//使馆认证完成功能

            UserManagerViewPage ListDown();//添加下拉数据添加
    }
}
