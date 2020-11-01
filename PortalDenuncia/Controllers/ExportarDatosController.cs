using OfficeOpenXml;
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

        public void ExportarExcel()
        {
            List<GDistritos> listagd = new List<GDistritos>();
            int d = db.TBDISTRITOS.Count() + 1;


            for (int i = 1; i < d; i++)
            {

                var tbdistritos = db.TBDISTRITOS.Where(t => t.iddistrito == i).First();
                int valdenuncias = db.TBDENUNCIAS.Where(u => u.iddistrito == i).Count();

                listagd.Insert(i - 1, new GDistritos(tbdistritos.nombre, valdenuncias));

            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelpack = new ExcelPackage();
            ExcelWorksheet excelshe = excelpack.Workbook.Worksheets.Add("Report");

            excelshe.Cells["A1"].Value = "Denuncias";
            excelshe.Cells["B1"].Value = "Distritos";

            excelshe.Cells["A2"].Value = "Reporte";
            excelshe.Cells["B2"].Value = "Reporte 1";

            excelshe.Cells["A3"].Value = "Fecha";
            excelshe.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            excelshe.Cells["A6"].Value = "Distrito";
            excelshe.Cells["B6"].Value = "Cantidad de denuncias";

            int rowStart = 7;
            foreach (var item in listagd)
            {
                excelshe.Cells[string.Format("A{0}", rowStart)].Value = item.nombre;
                excelshe.Cells[String.Format("B{0}", rowStart)].Value = item.cantidad;
                rowStart++;
            }
            

            excelshe.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats.officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(excelpack.GetAsByteArray());
            Response.End();
        }
    }
}