using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class ExportarDatosController : Controller
    {
        private DBDenunciaEntities db = new DBDenunciaEntities();
        // GET: ExportarDatos
        public ActionResult Index()
        {
            return View();
        }
    }
}