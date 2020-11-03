using PortalDenuncia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalDenuncia.Controllers
{
    public class DelegateAccessController : Controller
    {
        // GET: DelegateAccess
        public ActionResult Index(string user, string password)
        {
            try
            {
                using (DBDenunciaEntities db = new DBDenunciaEntities())
                {
                    var lis = from d in db.TBDELEGADOS
                              where d.numdocu == user && d.password == password
                              select d;
                    if (lis.Count() > 0)
                    {
                        TBDELEGADO otbdelegado = lis.First();
                        Session["delegado"] = otbdelegado;
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

        public ActionResult Entrar()
        {
            return View();
        }
    }
}