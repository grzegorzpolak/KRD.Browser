﻿using System.Web.Mvc;
using System.Web.Routing;

namespace KRD.RepoBrowser.Web
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("api/{*pathInfo}");
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

      routes.MapRoute(
        name: "Default", 
        url: "{controller}/{action}/{id}", 
        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
    }
  }
}