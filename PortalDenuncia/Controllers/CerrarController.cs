using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cerrar()
        {
            Session["usuario"] = null;
            return RedirectToAction("Entrar", "UserAccess");
        }
        public ActionResult Cerrard()
        {
            Session["delegado"] = null;
            return RedirectToAction("Entrar", "DelegateAccess");
        }
    }
}