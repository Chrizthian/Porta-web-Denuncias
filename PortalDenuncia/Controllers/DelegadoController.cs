using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class DelegadoController : Controller
    {
        // GET: Delegado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaDenuncia()
        {
            TBDELEGADO tbusuario = (TBDELEGADO)Session["delegado"];

            var tBDENUNCIAS = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBTIPODENUNCIA);
            return View(tBDENUNCIAS.Where(u => u.idusuario == tbusuario.idusuario).ToList());
        }
    }
}