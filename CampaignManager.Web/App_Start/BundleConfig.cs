﻿using System.Web;
using System.Web.Optimization;

namespace CampaignManager.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap/bootstrap.css"));
        }
    }
}