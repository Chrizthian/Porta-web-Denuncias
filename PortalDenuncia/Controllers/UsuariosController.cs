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
    public class UsuariosController : Controller
    {
        private DBDenunciaEntities db = new DBDenunciaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tBUSUARIOS = db.TBUSUARIOS.Include(t => t.TBTIPODOCUMan);
            return View(tBUSUARIOS.ToList());
        }

        

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idtipdocu = new SelectList(db.TBTIPODOCUMEN, "idtipdocu", "tipo");
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TBUSUARIO tBUSUARIO)
        {
            if (ModelState.IsValid)
            {
                if (tBUSUARIO.ValidarUsuario(tBUSUARIO.numdocu) == true)
                {
                    db.TBUSUARIOS.Add(tBUSUARIO);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("numdocu", "Ya existe un usuario con este numero de documento");
                    
                    ViewBag.idtipdocu = new SelectList(db.TBTIPODOCUMEN, "idtipdocu", "tipo", tBUSUARIO.idtipdocu);
                    return View(tBUSUARIO);
                }
                
            }

            ViewBag.idtipdocu = new SelectList(db.TBTIPODOCUMEN, "idtipdocu", "tipo", tBUSUARIO.idtipdocu);
            return View(tBUSUARIO);
        }

        

        

        

        

        // GET: Usuarios/Create
        public ActionResult CrearDenuncia()
        {
            ViewBag.idcomisaria = new SelectList(db.TBCOMISARIAS, "idcomisaria", "nombre");
            ViewBag.iddistrito = new SelectList(db.TBDISTRITOS, "iddistrito", "nombre");
            ViewBag.idtipo = new SelectList(db.TBTIPODENUNCIAS, "idtipo", "tipo");
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearDenuncia(TBDENUNCIA tBDENUNCIA)
        {

            if (ModelState.IsValid)
            {

                TBUSUARIO tbusuario = (TBUSUARIO)Session["usuario"];

                tBDENUNCIA.fecha = DateTime.Now;
                tBDENUNCIA.idusuario = tbusuario.idusuario;
                tBDENUNCIA.iddelegado = 1;
                tBDENUNCIA.idestado = 1;
                tBDENUNCIA.idpolicia = 1;
                tBDENUNCIA.idverazidad = 1;


                db.TBDENUNCIAS.Add(tBDENUNCIA);
                db.SaveChanges();
                return RedirectToAction("ListaDenuncia", "Usuarios");
            }

            ViewBag.idcomisaria = new SelectList(db.TBCOMISARIAS, "idcomisaria", "nombre", tBDENUNCIA.idcomisaria);
            ViewBag.iddistrito = new SelectList(db.TBDISTRITOS, "iddistrito", "nombre", tBDENUNCIA.iddistrito);
            ViewBag.idtipo = new SelectList(db.TBTIPODENUNCIAS, "idtipo", "tipo", tBDENUNCIA.idtipo);
            return View(tBDENUNCIA);
        }

        public ActionResult ListaDenuncia()
        {

            TBUSUARIO tbusuario = (TBUSUARIO)Session["usuario"];

            var tBDENUNCIAS = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBTIPODENUNCIA);
            return View(tBDENUNCIAS.Where(u => u.idusuario==tbusuario.idusuario).ToList());
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
