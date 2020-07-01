using International_Trade.Filters;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Areas.BackManager.Controllers
{
    [RoleAuthorization(Message = 2)]
    public class ExamineController : Controller
    {
        //
        // GET: /BackManager/Examine/

        public ActionResult ExamineIndex()
        {
            return View();
        }

        public ActionResult ExamineIndex1(string searchString, string Year, int? page)
        {
            IExamine IE = new ExamineMethod();
            return Json(IE.Index(searchString, Year, page), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExamineDetail()
        {
            return View();
        }

        public ActionResult ExamineDetail1(string id)
        {
            IExamine IE = new ExamineMethod();
            return Json(IE.ExamineDetail(id), JsonRequestBehavior.AllowGet);
        }

        public void Pass(Array arr)
        {
            var str = arr.GetValue(0).ToString();
            var getArr = str.Split(',');
            IExamine IE = new ExamineMethod();
            IE.Pass(getArr);
        }

        public void NoPass(Array arr)
        {
            var str = arr.GetValue(0).ToString();
            var getArr = str.Split(',');
            IExamine IE = new ExamineMethod();
            IE.NoPass(getArr);
        }

        public void Pass1(string id)
        {
            IExamine IE = new ExamineMethod();
            IE.Pass1(id);
        }

        public void NoPass1(string id)
        {
            IExamine IE = new ExamineMethod();
            IE.NoPass1(id);
        }

        

    }
}
