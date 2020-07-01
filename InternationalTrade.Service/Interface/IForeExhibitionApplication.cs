using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IForeExhibitionApplication
    {
        String Add( ForeExhibitionApplicationViewPage ExhibitionApplicationAdd, string id, string UserID);//添加功能
    }
}
