﻿using System.Web.Optimization;

namespace EventBooking
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            
			bundles.Add(new StyleBundle("~/Content/bootstrap")
				.Include("~/Content/bootstrap.css")
				.Include("~/Content/site.css")
				.Include("~/Content/bootstrap-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/general").Include("~/Scripts/general.js"));
			bundles.Add( new ScriptBundle( "~/bundles/pickadate" ).Include( "~/Scripts/pickadate.js" ) );

        }
    }
}
