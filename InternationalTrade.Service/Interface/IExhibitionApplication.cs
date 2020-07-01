using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IExhibitionApplication
    {
        ForeExhibitionApplicationViewPage Index(string id);

        ForeExhibitionApplicationViewPage ExhibitionApplicatioDetail(string id,string idd);//详细功能 

        String TradeExamineFeedback(ForeExhibitionApplicationViewPage TradeExamineFeedbackAdd,string id,string idd);//反馈
    }
}
