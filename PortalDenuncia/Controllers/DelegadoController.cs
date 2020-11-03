using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class DelegadoController : Controller
    {
        private DBDenunciaEntities db = new DBDenunciaEntities();
        // GET: Delegado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaDenuncia()
        {
            TBDELEGADO tbdelegado = (TBDELEGADO)Session["delegado"];

            var tBDENUNCIAS = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBPOLICIA)
                .Include(t => t.TBTIPODENUNCIA)
                .Include(t => t.TBVERAZIDAD);

            return View(tBDENUNCIAS.Where(u => u.iddelegado == tbdelegado.iddelegado).ToList());
        }

        public ActionResult DelegadoDraf1()
        {
            DenunciaCount denuncian = new DenunciaCount();
            denuncian.alerta = db.TBDENUNCIAS.Where(x => x.idtipo == 1).Count();
            denuncian.denuncia = db.TBDENUNCIAS.Where(x => x.idtipo == 2).Count();

            return Json(denuncian, JsonRequestBehavior.AllowGet);
        }

        public void ExportarDelegado1()
        {
            var tBDENUNCIAS = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBPOLICIA)
                .Include(t => t.TBTIPODENUNCIA)
                .Include(t => t.TBVERAZIDAD);
            
            //Colocar la lista
            //Realizar transformacion
        }
    }
}