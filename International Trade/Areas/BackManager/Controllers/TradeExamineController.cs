using International_Trade.Filters;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Method;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Areas.BackManager.Controllers
{
    [RoleAuthorization(Message = 3)]
    public class TradeExamineController : Controller
    {
        //
        // GET: /BackManager/TraderExamine/

        public ActionResult TradeExamineIndex()
        {
            return View();
        }

        public ActionResult TradeExamineIndex1(string searchString, string Year, int? page)
        {
            ITradeExamine IT = new TradeExamineMethod();
            return Json(IT.Index(searchString, Year, page), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TradeExamineDetail()
        {
            return View();
        }

        public ActionResult TradeExamineDetail1(string id)
        {
            ITradeExamine IT = new TradeExamineMethod();
            return Json(IT.TradeInfoDetail(id), JsonRequestBehavior.AllowGet);
        }

        public void Pass(Array arr)
        {
            var str = arr.GetValue(0).ToString();
            var getArr = str.Split(',');
            ITradeExamine IE = new TradeExamineMethod();
            IE.Pass(getArr);
        }

        public void NoPass(Array arr)
        {
            var str = arr.GetValue(0).ToString();
            var getArr = str.Split(',');
            ITradeExamine IE = new TradeExamineMethod();
            IE.NoPass(getArr);
        }

        public ActionResult Confirm(string id)
        {
            ITradeExamine IT = new TradeExamineMethod();
            IT.Confirm(id);
            return Json("反馈成功");
        }

        public ActionResult CheckConfirm(string id)
        {
            ITradeExamine IT = new TradeExamineMethod();
            return Json(IT.TradeExamineDetail(id));
        }

        public ActionResult VisaAdd(TradeExamineViewPage1 VisaAdd)
        {
            ITradeExamine IT = new TradeExamineMethod();
            return Json(IT.Add(VisaAdd));
        }

        //public ActionResult Finish(string id)
        //{
        //    ITradeExamine IT = new TradeExamineMethod();
        //    IT.Finish(id);
        //    return Json("申请完成");
        //}
    }
}
