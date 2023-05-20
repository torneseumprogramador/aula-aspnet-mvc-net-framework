﻿using Execricio.WerbASPNET.Framework.SessionCookie.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Execricio.WerbASPNET.Framework.SessionCookie.Controllers
{
    [AuthenticateSessionFilter]
    //[AuthenticateCookieFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}