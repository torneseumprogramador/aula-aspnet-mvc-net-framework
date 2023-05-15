using LabWebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class LogadoController : Controller
    {
        public bool Logado()
        {
            if (Session["usuario_logado"] == null)
            {
                Response.Redirect("/login");
                return false;
            }

            return true;
        }
    }
}