using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IVisaManage
    {
        VisaManageViewPage Index(string searchString, VisaState1 State, int? page);//数据显示以及查询

        VisaManageViewPage VisaDetail(string id);//详细功能 

        String CheckPass(string id);//审核通过功能

        //String Finish(string id);//使馆认证完成功能
    }
}
