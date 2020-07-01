using International_Trade.Filters;
using InternationalTrade.Repository.Enums;
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
    [RoleAuthorization(Message = 2)]
    public class EmbassyController : Controller
    {
        //
        // GET: /BackManager/Embassy/

        public ActionResult EmbassyIndex()
        {
            return View();
        }

        public ActionResult EmbassyIndex1(string searchString, EmbassyState1 State, int? page)
        {
            IEmbassy IU = new EmbassyMethod();
            return Json(IU.Index(searchString, State, page), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(EmbassyViewPage EmbassyAdd)
        {
            IEmbassy IE = new EmbassyMethod();
            string message = IE.CheckEmbassyInfo(EmbassyAdd);
            if (message != "添加成功！")
            {
                return Json(message);
            }
            IE.Add(EmbassyAdd);
            return Json("添加成功！");
        }

        public ActionResult Delivery(string id)
        {
            IEmbassy IE = new EmbassyMethod();
            IE.Delivery(id);
            return Json("送外办完成");
        }

        public ActionResult Finish(string id)
        {
            IEmbassy IE = new EmbassyMethod();
            IE.Finish(id);
            return Json("使馆认证完成");
        }

        public ActionResult TypeShow()
        {
            IEmbassy IE = new EmbassyMethod();
            return Json(IE.ListDown(), JsonRequestBehavior.AllowGet);
        }
    }
}
