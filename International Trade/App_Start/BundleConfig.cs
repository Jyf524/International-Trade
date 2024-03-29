﻿using System.Web;
using System.Web.Optimization;

namespace International_Trade
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",
                        "~/Scripts/bootstrap.bundle.js",
                        "~/Scripts/bootstrap.bundle.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/front.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/css/bootstrap-grid.css",
                        "~/Content/css/jquery.ui.theme.css",
                        "~/Content/css/bootstrap-grid.min.css",
                        "~/Content/css/bootstrap-reboot.css",
                        "~/Content/css/bootstrap-reboot.min.css",
                        "~/Content/css/bootstrap.css",
                        "~/Content/css/bootstrap.min.css",
                        "~/Content/css/custom.css",
                        "~/Content/css/fontastic.css",
                        "~/Content/css/style.blue.css",
                        "~/Content/css/style.default.css",
                        "~/Content/style.green.css",
                        "~/Content/css/style.pink.css",
                        "~/Content/css/style.red.css",
                        "~/Content/css/style.sea.css",
                        "~/Content/css/style.violet.css",
                        "~/Content/fonts/font-awesome.css",
                        "~/Content/fonts/font-awesome.min.css"));
        }
    }
}