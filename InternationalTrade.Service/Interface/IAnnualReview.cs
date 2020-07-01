using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IAnnualReview
    {
        AnnualReviewViewPage Index(string id);//前台年审

        AnnualReviewViewPage AnnualReviewDetail(string id);//详细年审

        String AnnualReviewUpload(AnnualReviewViewPage AnnualReviewAdd,string idd);//年审上传
    }
}
