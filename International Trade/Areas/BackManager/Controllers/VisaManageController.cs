using International_Trade.Filters;
using InternationalTrade.Repository.Enums;
using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Areas.BackManager.Controllers
{
    [RoleAuthorization(Message = 3)]
    public class VisaManageController : Controller
    {
        //
        // GET: /BackManager/VisaManage/

        public ActionResult VisaManageIndex()
        {
            return View();
        }

        public ActionResult VisaManageIndex1(string searchString, VisaState1 State, int? page)
        {
            IVisaManage IV = new VisaManageMethod();
            return Json(IV.Index(searchString, State, page), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(string id = null)
        {
            IVisaManage IV = new VisaManageMethod();
            return Json(IV.VisaDetail(id));
        }

        public ActionResult CheckPass(string id)
        {
            IVisaManage IV = new VisaManageMethod();
            IV.CheckPass(id);
            return Json("已审核！");
        }


    }
}
