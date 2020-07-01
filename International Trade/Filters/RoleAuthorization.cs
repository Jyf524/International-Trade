using InternationalTrade.Repository.Constaint;
using InternationalTrade.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace International_Trade.Filters
{

    public class RoleAuthorization : AuthorizeAttribute
    {
        protected DataContent db = new DataContent();
        public int Message { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //如果运行该下代码进行自带.net Framework定义好的身份验证
            //base.OnAuthorization(filterContext);

            //如果希望跳转另一个页面则需要使用result 而不是使用Response.Redirect(),下面的方法则会停止运行服务器
            //filterContext.Result = new RedirectResult(UrlHelper.GenerateUrl("", "xxx", "UserManager",""));

            //获取路由数据:当前上下文符合规则后，得到一个对象
            //filterContext.RouteData

            //获取上下文
            //filterContext.HttpContext.Response.Write("123");

            if (Message == 1)
            {
                if (System.Web.HttpContext.Current.Session["UserName2"] != "")
                {
                    //base.OnAuthorization(filterContext);
                    var id = System.Web.HttpContext.Current.Session["UserName2"];
                    var UserInfo1 = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();
                    int session = 0;
                    try
                    {
                        session = Convert.ToInt32(UserInfo1.UserRole);
                    }
                    catch
                    {
                        filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    }

                    if (session != Message)
                    {
                        System.Web.HttpContext.Current.Session["UserName2"] = null;
                        //需要跳转到另一个页面用Result
                        if (session == 1)
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        
                        return;
                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Session["UserName2"] = null;
                    filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    return;
                }
            }
            if (Message == 2)
            {

                if (System.Web.HttpContext.Current.Session["UserName3"] != "")
                {
                    //base.OnAuthorization(filterContext);
                    var id = System.Web.HttpContext.Current.Session["UserName3"];
                    var UserInfo1 = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();

                    int session = 0;
                    try
                    {
                        session = Convert.ToInt32(UserInfo1.UserRole);
                    }
                    catch
                    {
                        filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    }
                    if (session != Message)
                    {
                        System.Web.HttpContext.Current.Session["UserName3"] = null;
                        //需要跳转到另一个页面用Result
                        if (session == 1)
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        return;
                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Session["UserName4"] = null;
                    filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    return;
                }
            }

            if (Message == 3)
            {
                if (System.Web.HttpContext.Current.Session["UserName4"] != "")
                {
                    //base.OnAuthorization(filterContext);
                    var id = System.Web.HttpContext.Current.Session["UserName4"];
                    var UserInfo1 = db.UsersInfo.Where(a => a.UserName == id).FirstOrDefault();

                    int session = 0;
                    try
                    {
                        session = Convert.ToInt32(UserInfo1.UserRole);
                    }
                    catch
                    {
                        filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    }

                    if (session != Message)
                    {
                        System.Web.HttpContext.Current.Session["UserName4"] = null;
                        //需要跳转到另一个页面用Result
                        if (session == 1)
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        else
                        {
                            filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                        }
                        return;
                    }
                }
                else
                {
                    System.Web.HttpContext.Current.Session["UserName4"] = null;
                    filterContext.Result = new RedirectResult("../../ForeExhibition/Login");
                    return;
                }
            }

        }
    }
}
