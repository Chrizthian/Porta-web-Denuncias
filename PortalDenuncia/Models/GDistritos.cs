using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class GDistritos
    {
        public string nombre { get; set; }
        public int cantidad { get; set; }

        public GDistritos (string nombre, int cantidad)
        {
            this.nombre = nombre;
            this.cantidad = cantidad;
        }
    }
}