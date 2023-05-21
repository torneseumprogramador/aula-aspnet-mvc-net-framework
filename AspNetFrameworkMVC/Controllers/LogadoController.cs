using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class LogadoController : Controller
    {
        public bool Logado()
        {
            if (Session["usuario_logado"] == null)
            {
                Redirect("/login");
                return false;
            }
            return true;
        }
    }
}