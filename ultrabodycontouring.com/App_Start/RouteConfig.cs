﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ultrabodycontouring.com
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("contact",
				"Contact",
				new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
				new { httpMethod = new HttpMethodConstraint("POST") }
			);

			routes.MapRoute("Static",
				"{*path}",
				new { controller = "Static", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

			//routes.MapRoute(
			//	name: "Default",
			//	url: "{controller}/{action}/{id}",
			//	defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			//);
		}
	}
}