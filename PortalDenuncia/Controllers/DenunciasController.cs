using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortalDenuncia.Models;

namespace PortalDenuncia.Controllers
{
    public class DenunciasController : Controller
    {
        private DBDenunciaEntities db = new DBDenunciaEntities();

        // GET: Denuncias
        public ActionResult Index()
        {
            var tBDENUNCIAS = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDELEGADO)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBPOLICIA)
                .Include(t => t.TBTIPODENUNCIA)
                .Include(t => t.TBUSUARIO)
                .Include(t => t.TBVERAZIDAD);
            return View(tBDENUNCIAS.ToList());
        }

        

        // GET: Denuncias/Create
        public ActionResult Create()
        {
            ViewBag.idcomisaria = new SelectList(db.TBCOMISARIAS, "idcomisaria", "nombre");
            ViewBag.iddistrito = new SelectList(db.TBDISTRITOS, "iddistrito", "nombre");
            ViewBag.idtipo = new SelectList(db.TBTIPODENUNCIAS, "idtipo", "tipo");
            return View();
        }

        // POST: Denuncias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddenuncia,descripcion,direccion,fecha,idusuario,idtipo,iddistrito,idpolicia,idcomisaria,idestado,idverazidad,iddelegado")] TBDENUNCIA tBDENUNCIA)
        {
            if (ModelState.IsValid)
            {

                tBDENUNCIA.fecha = DateTime.Now;
                tBDENUNCIA.idusuario = 3;
                tBDENUNCIA.iddelegado = 1;
                tBDENUNCIA.idestado = 1;
                tBDENUNCIA.idpolicia = 1;
                tBDENUNCIA.idverazidad = 1;

                db.TBDENUNCIAS.Add(tBDENUNCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcomisaria = new SelectList(db.TBCOMISARIAS, "idcomisaria", "nombre", tBDENUNCIA.idcomisaria);
            ViewBag.iddistrito = new SelectList(db.TBDISTRITOS, "iddistrito", "nombre", tBDENUNCIA.iddistrito);
            ViewBag.idtipo = new SelectList(db.TBTIPODENUNCIAS, "idtipo", "tipo", tBDENUNCIA.idtipo);
            return View(tBDENUNCIA);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
