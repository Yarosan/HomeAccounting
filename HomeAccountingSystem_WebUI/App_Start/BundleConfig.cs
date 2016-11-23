﻿using System.Web.Optimization;


namespace HomeAccountingSystem_WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ajax").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval-ajax").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/bootstrap-datetimepicker*"));

            bundles.Add(new ScriptBundle("~/bundles/datetime-datepicker").Include(
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/locales/bootstrap-datepicker.ru.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/material-kit").Include(
                "~/Scripts/material.min.js",
                "~/Scripts/material-kit.js"));

            //Use the development version of Modernizr to develop with and learn from. Then, when you're
            //ready for production, use the build tool at http://modernizr.com to pick only the tests you need.


            bundles.Add(new StyleBundle("~/bundles/bootstrap-datetimepicker/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/ErrorStyles.css")
                );

            bundles.Add(new StyleBundle("~/bundles/bootstrap-datepicker/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-datepicker.css",
                "~/Content/ErrorStyles.css")
                );

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/ErrorStyles.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-site/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/bundles/material-kit/css").Include(
                "~/Content/material-kit.css"));
        }
    }
}