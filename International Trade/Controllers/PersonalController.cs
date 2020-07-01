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
    public class PersonalController : Controller
    {
        //
        // GET: /Personal/

        public ActionResult PersonalIndex()
        {
            return View();
        }

        public ActionResult PersonalIndex1()
        {
            IPersonal IP = new PersonalMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IP.Index(idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PersonalInfo()
        {
            return View();
        }

        public ActionResult PersonalInfo1()
        {
            IPersonal IP = new PersonalMethod();
            string idd ="0";
            try
            {
               idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IP.Index(idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PersonalInfoSave(PersonalViewPage PersonalInfoChange)
        { 
            IPersonal IP = new PersonalMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IP.ChangePersonalInfo(PersonalInfoChange,idd), JsonRequestBehavior.AllowGet);
        }
        public ActionResult PersonalPassWordChange()
        {
            return View();
        }

        public ActionResult PersonalPassWordChange1(PersonalViewPage PersonalPassWordChange)
        {
            IPersonal IP = new PersonalMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            string message = IP.CheckChangePassWord(PersonalPassWordChange,idd);
            if (message != "修改成功!")
            {
                return Json(message);
            }
            
            return Json(IP.ChangePassWord(PersonalPassWordChange, idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EmbassyCertificationIndex()
        {
            return View();
        }

        public ActionResult EmbassyCertificationIndex1()
        {
            IEmbassyCertification IE = new EmbassyCertificationMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IE.Index(idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult VisaStatus()
        {
            return View();
        }

        public ActionResult VisaStatus1()
        {
            IVisaStatus IE = new VisaStatusMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IE.Index(idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AnnualReview()
        {
            return View();
        }

        public ActionResult AnnualReview1()
        {
            IAnnualReview IA = new AnnualReviewMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IA.Index(idd), JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult AnnualReviewDetail()
        {
            return View();
        }

        public ActionResult AnnualReviewDetail1(string id)
        {
            IAnnualReview IA = new AnnualReviewMethod();
            return Json(IA.AnnualReviewDetail(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AnnualReviewUpload()
        {
            return View();
        }

        int count =0;
        public ActionResult AnnualReviewUpload1(AnnualReviewViewPage AnnualReviewAdd)
        {
            IAnnualReview IA = new AnnualReviewMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            string fileSave = Server.MapPath("~/upload/");
            try
            {
                HttpFileCollectionBase file = Request.Files;
                if (file.Count != 0)
                {
                    for (int i = 0; i < file.Count; i++)
                    {
                        HttpPostedFileBase file2 = file[i];
                        if (file.AllKeys[i] == "file")
                        {
                            count++;
                            string extName = Path.GetExtension(file2.FileName);
                            string newName = Guid.NewGuid().ToString() + extName;
                            file2.SaveAs(Path.Combine(fileSave, newName));
                            if (count == 1)
                            {
                                AnnualReviewAdd.BusinessCard = "/upload/" + newName;
                            }
                            else
                            {
                               AnnualReviewAdd.BusinessCard += "," + "/upload/" + newName;
                            }

                        }
                        if (file.AllKeys[i] == "PayCard")
                        {
                            string extName = Path.GetExtension(file2.FileName);
                            string newName = Guid.NewGuid().ToString() + extName;
                            file2.SaveAs(Path.Combine(fileSave, newName));
                            AnnualReviewAdd.PayCard = "/upload/" + newName;
                        }
                    }
                }


            }
            catch
            {
                return Json("文件过大", JsonRequestBehavior.AllowGet);
            }
            return Json( IA.AnnualReviewUpload(AnnualReviewAdd, idd),JsonRequestBehavior.AllowGet);
            
        }

      


        public ActionResult ExhibitionApplication()
        {
            return View();
        }

        public ActionResult ExhibitionApplication1()
        {
            IExhibitionApplication IA = new ExhibitionApplicationMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IA.Index(idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExhibitionDetail()
        {
            return View();
        }

        public ActionResult ExhibitionDetail1(string id)
        {
            IExhibitionApplication IA = new ExhibitionApplicationMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IA.ExhibitionApplicatioDetail(id,idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TradeExamineFeedback(string id, ForeExhibitionApplicationViewPage TradeExamineFeedbackAdd)
        {
            IExhibitionApplication IE = new ExhibitionApplicationMethod();
            string idd = "0";
            try
            {
                idd = System.Web.HttpContext.Current.Session["UserName"].ToString();
            }
            catch
            {
                return Json("操作时间过长请重新登录");
            }
            return Json(IE.TradeExamineFeedback(TradeExamineFeedbackAdd,id,idd), JsonRequestBehavior.AllowGet);
        }

        public ActionResult xxx()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["UserName"].ToString() != "")
                {
                    return Content("1");
                }
            }
            catch
            {
                return Content("2");
            }
            return Content("1");
        }

        public ActionResult yyy()
        {
            System.Web.HttpContext.Current.Session["UserName"] = "";

            return Content("1");
        }

    }
}
