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
    
    public class UserManagerController : Controller
    {
        //
        // GET: /BackManager/UserManager/
        [RoleAuthorization(Message = 1)]
        public ActionResult UserManagerIndex()
        {
            return View();
        }
        [RoleAuthorization(Message = 1)]
        public ActionResult UserManagerIndex1(string searchString, UsersRole Role, int? page)
        {
            IUserManagerService IU = new UserManagerMethod();
            return Json(IU.Index(searchString, Role, page), JsonRequestBehavior.AllowGet);
        }
        [RoleAuthorization(Message = 1)]
        public ActionResult Delete(string id = null)
        {
            IUserManagerService IU = new UserManagerMethod();
            string message = IU.Delete(id);
            if (message != "删除成功！")
            {
                return Json(message);
            }
            return Json("删除成功！");
        }
        [RoleAuthorization(Message = 1)]
        public ActionResult Add(UserManagerViewPage UserAdd)
        {
            IUserManagerService IU = new UserManagerMethod();
            string message = IU.CheckUserInfo(UserAdd);
            if (message != "添加成功！")
            {
                return Json(message);
            }
            IU.Add(UserAdd);
            return Json("添加成功！");
        }
        [RoleAuthorization(Message = 1)]
        public ActionResult Detail(string id = null)
        {
            IUserManagerService IU = new UserManagerMethod();
            return Json(IU.UserDetail(id));
        }
        [RoleAuthorization(Message = 1)]
        public ActionResult UserDetailSave(UserManagerViewPage UserSave, string id)
        {
            IUserManagerService IU = new UserManagerMethod();
            string message = IU.CheckUserInfoSave(UserSave,id);
            if (message != "修改成功！")
            {
                return Json(message);
            }
            IU.Save(UserSave, id);
            return Json("修改成功！");
        }

        public ActionResult xxx()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["UserName2"].ToString() != "")
                {
                    return Content("1");
                }
                if (System.Web.HttpContext.Current.Session["UserName3"].ToString() != "")
                {
                    return Content("2");
                }
                if (System.Web.HttpContext.Current.Session["UserName4"].ToString() != "")
                {
                    return Content("3");
                }
            }
            catch
            {
                return Content("4");
            }
           return View();
        }

        //public ActionResult PersonalIndex1()
        //{
        //    IPersonal IP = new PersonalMethod();
        //    string idd ="";
        //    try
        //    {
        //        idd = System.Web.HttpContext.Current.Session["UserName2"].ToString();
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            idd = System.Web.HttpContext.Current.Session["UserName3"].ToString();
        //        }
        //        catch
        //        {
        //            try
        //            {
        //                idd = System.Web.HttpContext.Current.Session["UserName4"].ToString();
        //            }
        //            catch
        //            {

        //            }
        //        }
        //    }
            
            
        //    return Json(IP.Index(idd), JsonRequestBehavior.AllowGet);
        //}

    }
}
