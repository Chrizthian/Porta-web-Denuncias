using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class AlertaRep
    {
        public int codigo { get; set; }
        public string detalle { get; set; }
        public string direccion { get; set; }
        public string tipod { get; set; }
        public string distrrito { get; set; }
        public string estado { get; set; }
        public string veracidad { get; set; }

        public AlertaRep(int codigo, string detalle, string direccion, string tipod, string distrrito,
            string estado, string veracidad)
        {
            this.codigo = codigo;
            this.detalle = detalle;
            this.direccion = direccion;
            this.tipod = tipod;
            this.distrrito = distrrito;
            this.estado = estado;
            this.veracidad = veracidad;
        }
        public AlertaRep()
        {

        }
    }
}