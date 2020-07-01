using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalTrade.Service.Interface
{
    public interface IExamine
    {
        ExamineViewPage Index(string searchString,string Year, int? page);//数据显示以及查询

        ExamineViewPage ExamineDetail(string id);//查看年审材料详细功能

        void Pass(Array arr);//年审材料通过功能

        void NoPass(Array arr);//年审材料不通过功能

        void Pass1(string id);//年审材料通过功能

        void NoPass1(string id);//年审材料不通过功能

        void Add(ExamineViewPage ExamineAdd, string id);//添加年审
    }
}
