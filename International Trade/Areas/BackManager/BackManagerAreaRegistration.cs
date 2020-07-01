using System.Web.Mvc;

namespace International_Trade.Areas.BackManager
{
    public class BackManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BackManager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BackManager_default",
                "BackManager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
