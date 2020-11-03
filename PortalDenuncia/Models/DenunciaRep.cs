using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class DenunciaRep
    {
        int codigo { get; set; }
        String detalle { get; set; }
        String direccion { get; set; }
        String tipod { get; set; }
        String distrrito { get; set; }
        String estado { get; set; }
        String veracidad { get; set; }

        public DenunciaRep(int codigo, String detalle, String direccion, String tipod, String distrrito, 
            String estado, String veracidad)
        {
            this.codigo = codigo;
            this.detalle = detalle;
            this.direccion = direccion;
            this.tipod = tipod;
            this.distrrito = distrrito;
            this.estado = estado;
            this.veracidad = veracidad;
        }
    }
}