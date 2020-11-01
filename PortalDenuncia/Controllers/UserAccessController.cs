using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class UserAccessController : Controller
    {
        
        // GET: UserAccess
        public ActionResult Entrar()
        {
            return View();
        }

        public ActionResult Index(string user, string password)
        {
            try
            {
                using (DBDenunciaEntities db = new DBDenunciaEntities())
                {
                    var lis = from d in db.TBUSUARIOS
                              where d.correo == user && d.password == password
                              select d;
                    if (lis.Count() > 0)
                    {
                        TBUSUARIO otbusuario = lis.First();
                        Session["usuario"] = otbusuario;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario incorrecto");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error" + ex.Message);
            }
        }
    }
}