using InternationalTrade.Service.Interface;
using InternationalTrade.Service.Method;
using InternationalTrade.Service.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Controllers
{
    public class ForeExhibitionController : Controller
    {
        //
        // GET: /ForeManage/

        public ActionResult ForeExhibitionIndex()
        {
            return View();
        }

        public ActionResult ForeExhibitionIndex1(int? page)
        {
            IForeExhibition IU = new ForeExhibitionMethod();

            var page1 = page * 10;

            return Json(IU.Index(page1), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForeExhibitionDetail()
        {
            return View();
        }

        public ActionResult ForeExhibitionDetail1(string id)
        {
            IForeExhibitionDetail IE = new ForeExhibitionDetailMethod();
            return Json(IE.TradeDetail(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ForeExhibitionApplication()
        {
            return View();
        }

        int count = 0;
        public ActionResult ForeExhibitionApplication1(ForeExhibitionApplicationViewPage ExhibitionApplicationAdd, string idd)
        {

            IForeExhibitionApplication IF = new ForeExhibitionApplicationMethod();
            string UserID = System.Web.HttpContext.Current.Session["UserName"].ToString();
            string fileSave = Server.MapPath("~/upload/");

            try
            {
                HttpFileCollectionBase file = Request.Files;
                if (file.Count != 0)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        if (file.AllKeys[i] == "TradeDocument")
                        {
                            HttpPostedFileBase file1 = file[i];
                            string extName = Path.GetExtension(file1.FileName);
                            string newName = Guid.NewGuid().ToString() + extName;
                            file1.SaveAs(Path.Combine(fileSave, newName));
                            ExhibitionApplicationAdd.TradeDocument = "../upload/" + newName;
                        }
                    }
                }
            }
            catch
            {
                return Json("文件过大", JsonRequestBehavior.AllowGet);
            }
            return Json(IF.Add(ExhibitionApplicationAdd, idd, UserID), JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult ForeOtherApplication()
        {
            return View();
        }

        public ActionResult ForeOtherApplication1(string id)
        {
            IForeExhibitionDetail IF = new ForeExhibitionDetailMethod();
            return Json(IF.ForeOtherApplication(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Message(ForeMessageViewPage MessageAdd, string id)
        {
            IForeMessage IF = new ForeMessageMethod();
            string UserID = "0";
            try
            {
                UserID = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IF.Message(MessageAdd,id,UserID));
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login1(string UserName, string PassWord, string Code)
        {
            ILogin Lo = new LoginMethod();
            string checkcode = Session["CheckCode"].ToString().ToLower();

            string check = Lo.GetLogin(UserName, PassWord, Code);
            if (check == "登录成功")
            {
                if (checkcode != Code.ToString().ToLower())
                {
                    return Json("验证码错误！");
                }
                System.Web.HttpContext.Current.Session["UserName"] = UserName;
            }
            if (check == "系统管理员登录成功")
            {
                System.Web.HttpContext.Current.Session["UserName2"] = UserName;

                System.Web.HttpContext.Current.Session["UserName"] = "";
                System.Web.HttpContext.Current.Session["UserName3"] = "";
                System.Web.HttpContext.Current.Session["UserName4"] = "";
                return Json(check);
            }
            if (check == "出认证处管理员登录成功")
            {
                System.Web.HttpContext.Current.Session["UserName3"] = UserName;

                System.Web.HttpContext.Current.Session["UserName"] = "";
                System.Web.HttpContext.Current.Session["UserName2"] = "";
                System.Web.HttpContext.Current.Session["UserName4"] = "";
                return Json(check);
            }
            if (check == "国际展览部管理员登录成功")
            {
                System.Web.HttpContext.Current.Session["UserName4"] = UserName;

                System.Web.HttpContext.Current.Session["UserName"] = "";
                System.Web.HttpContext.Current.Session["UserName2"] = "";
                System.Web.HttpContext.Current.Session["UserName3"] = "";
                return Json(check);
            }
            return Json(check);

        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Register1(RegisterViewpage register, string Code)
        {
            IRegister Ir = new RegisterMethod();
            string message = Ir.CheckRegister(register);
            string checkcode = Session["CheckCode"].ToString().ToLower();
            if (message == "注册成功")
            {
                if (checkcode != Code.ToString().ToLower())
                {
                    return Json("验证码错误！");
                }
                else
                {
                    Ir.Add(register);
                }
            }
            
            return Json(message);

        }


    }
}
