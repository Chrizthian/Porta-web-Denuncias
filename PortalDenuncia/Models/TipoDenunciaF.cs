using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{

    public class TipoDenunciaF
    {
        [Display(Name ="ID")]
        public int idtipo { get; set; }
        [Display(Name ="Tipo de denuncia")]
        public string tipo { get; set; }
    }
    public partial class TBTIPODENUNCIA
    {

    }
}