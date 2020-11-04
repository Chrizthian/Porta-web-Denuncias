using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class DenunciaCount
    {
        public int alerta { get; set; }
        public int denuncia { get; set; }

        public DenunciaCount()
        {

        }

        public DenunciaCount(int alerta, int denuncia)
        {
            this.alerta = alerta;
            this.denuncia = denuncia;
        }
    }

}

