using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVCAula10_05.Controllers
{
    public class LogadoController : Controller
    {
        // GET: Logado
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