using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class GraficosController : Controller
    {
        private DBDenunciaEntities db = new DBDenunciaEntities();
        // GET: Graficos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VistaDistritos()
        {
            return View();
        }

        public ActionResult getData()
        {
            DenunciaCount denuncian = new DenunciaCount();
            denuncian.alerta = db.TBDENUNCIAS.Where(x => x.idtipo == 1).Count();
            denuncian.denuncia = db.TBDENUNCIAS.Where(x => x.idtipo == 2).Count();

            return Json(denuncian, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DatosDistrito()
        {
            List<GDistritos> listagd = new List<GDistritos>();
            int d = db.TBDISTRITOS.Count() + 1;

            
            for(int i=1; i<d; i++)
            {
                
                var tbdistritos = db.TBDISTRITOS.Where(t => t.iddistrito == i).First();
                int valdenuncias = db.TBDENUNCIAS.Where(u => u.iddistrito == i).Count();

                listagd.Insert(i-1, new GDistritos(tbdistritos.nombre, valdenuncias));

            }
            

            return Json(listagd, JsonRequestBehavior.AllowGet);
        }

    }
}