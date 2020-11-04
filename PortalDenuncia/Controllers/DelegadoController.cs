using OfficeOpenXml;
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

        public ActionResult Graficos()
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

            return View(tBDENUNCIAS.Where(u => u.iddelegado == tbdelegado.idcomisaria).ToList());
        }

        public ActionResult DelegadoDraf1()
        {
            //conectar con el grafico
            TBDELEGADO otbdelegado = (TBDELEGADO)Session["delegado"];
            //falta la vista
            DenunciaCount count1 = new DenunciaCount
            {
                alerta = db.TBDENUNCIAS.Where(x => x.idtipo == 1 && x.idcomisaria == otbdelegado.idcomisaria).Count(),
                denuncia = db.TBDENUNCIAS.Where(x => x.idtipo == 2 && x.idcomisaria == otbdelegado.idcomisaria).Count()
            };

            return Json(count1, JsonRequestBehavior.AllowGet);
        }

        public void ExportarDelegado1()
        {
            var tbdenuncias = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBPOLICIA)
                .Include(t => t.TBTIPODENUNCIA)
                .Include(t => t.TBVERAZIDAD).Where(x => x.idtipo == 2).ToList();

            //Colocar la lista
            List<DenunciaRep> denunciarep = new List<DenunciaRep>();
            
            foreach (var item in tbdenuncias)
            {
                DenunciaRep modelos = new DenunciaRep();
                modelos.codigo = item.iddenuncia;
                modelos.detalle = item.descripcion;
                modelos.direccion = item.direccion;
                modelos.tipod = item.TBTIPODENUNCIA.tipo;
                modelos.distrrito = item.TBDISTRITO.nombre;
                modelos.estado = item.TBESTADO.nombre;
                modelos.veracidad = item.TBVERAZIDAD.tipo;

                denunciarep.Add(modelos);
            }

            var tbalertas = db.TBDENUNCIAS
                .Include(t => t.TBCOMISARIA)
                .Include(t => t.TBDISTRITO)
                .Include(t => t.TBESTADO)
                .Include(t => t.TBPOLICIA)
                .Include(t => t.TBTIPODENUNCIA)
                .Include(t => t.TBVERAZIDAD).Where(x => x.idtipo == 1).ToList();

            List<DenunciaRep> alertarep = new List<DenunciaRep>();

            foreach (var item in tbalertas)
            {
                DenunciaRep modelos = new DenunciaRep();
                modelos.codigo = item.iddenuncia;
                modelos.detalle = item.descripcion;
                modelos.direccion = item.direccion;
                modelos.tipod = item.TBTIPODENUNCIA.tipo;
                modelos.distrrito = item.TBDISTRITO.nombre;
                modelos.estado = item.TBESTADO.nombre;
                modelos.veracidad = item.TBVERAZIDAD.tipo;

                alertarep.Add(modelos);
            }

            //Realizar transformacion
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelpack = new ExcelPackage();
            ExcelWorksheet excelshed = excelpack.Workbook.Worksheets.Add("Alertas");

            excelshed.Cells["A1"].Value = "Alertas";
            excelshed.Cells["B1"].Value = "Distritos";

            excelshed.Cells["A2"].Value = "Reporte";
            excelshed.Cells["B2"].Value = "Reporte 3";

            excelshed.Cells["A3"].Value = "Fecha";
            excelshed.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            excelshed.Cells["A6"].Value = "Codigo";
            excelshed.Cells["B6"].Value = "Detalle";
            excelshed.Cells["C6"].Value = "Direccion";
            excelshed.Cells["D6"].Value = "Tipo de denuncias";
            excelshed.Cells["E6"].Value = "Distrito";
            excelshed.Cells["F6"].Value = "Estado";
            excelshed.Cells["G6"].Value = "Veracidad";

            int rowStartd = 7;
            foreach (var item in alertarep)
            {
                excelshed.Cells[string.Format("A{0}", rowStartd)].Value = item.codigo;
                excelshed.Cells[String.Format("B{0}", rowStartd)].Value = item.detalle;
                excelshed.Cells[string.Format("C{0}", rowStartd)].Value = item.direccion;
                excelshed.Cells[String.Format("D{0}", rowStartd)].Value = item.tipod;
                excelshed.Cells[string.Format("E{0}", rowStartd)].Value = item.distrrito;
                excelshed.Cells[String.Format("F{0}", rowStartd)].Value = item.estado;
                excelshed.Cells[string.Format("G{0}", rowStartd)].Value = item.veracidad;
                rowStartd++;
            }

            excelshed.Cells["A:AZ"].AutoFitColumns();

            ExcelWorksheet excelshea = excelpack.Workbook.Worksheets.Add("Denuncias");

            excelshea.Cells["A1"].Value = "Denuncias";
            excelshea.Cells["B1"].Value = "Distritos";

            excelshea.Cells["A2"].Value = "Reporte";
            excelshea.Cells["B2"].Value = "Reporte 3";

            excelshea.Cells["A3"].Value = "Fecha";
            excelshea.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            excelshea.Cells["A6"].Value = "Codigo";
            excelshea.Cells["B6"].Value = "Detalle";
            excelshea.Cells["C6"].Value = "Direccion";
            excelshea.Cells["D6"].Value = "Tipo de denuncias";
            excelshea.Cells["E6"].Value = "Distrito";
            excelshea.Cells["F6"].Value = "Estado";
            excelshea.Cells["G6"].Value = "Veracidad";

            int rowStarta = 7;
            foreach (var item in denunciarep)
            {
                excelshea.Cells[string.Format("A{0}", rowStarta)].Value = item.codigo;
                excelshea.Cells[String.Format("B{0}", rowStarta)].Value = item.detalle;
                excelshea.Cells[string.Format("C{0}", rowStarta)].Value = item.direccion;
                excelshea.Cells[String.Format("D{0}", rowStarta)].Value = item.tipod;
                excelshea.Cells[string.Format("E{0}", rowStarta)].Value = item.distrrito;
                excelshea.Cells[String.Format("F{0}", rowStarta)].Value = item.estado;
                excelshea.Cells[string.Format("G{0}", rowStarta)].Value = item.veracidad;
                rowStarta++;
            }

            excelshea.Cells["A:AZ"].AutoFitColumns();

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(excelpack.GetAsByteArray());
            Response.End();
        }
    }
}