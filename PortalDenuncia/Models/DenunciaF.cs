using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class DenunciaF
    {
        [Display(Name ="Descripcion")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name ="Direccion")]
        public string direccion { get; set; }
        [Display(Name ="Fecha")]
        public System.DateTime fecha { get; set; }
        [Display(Name ="Denunciante")]
        public Nullable<int> idusuario { get; set; }
        [Display(Name ="Tipo de denuncia")]
        public int idtipo { get; set; }
        [Display(Name ="Distrito")]
        public int iddistrito { get; set; }
        [Display(Name ="Efectivo encargado")]
        public Nullable<int> idpolicia { get; set; }
        [Display(Name ="Comisaria")]
        public Nullable<int> idcomisaria { get; set; }
        [Display(Name ="Estado")]
        public int idestado { get; set; }
        [Display(Name ="Verazidad")]
        public Nullable<int> idverazidad { get; set; }
        public Nullable<int> iddelegado { get; set; }
    }

    [MetadataType(typeof(DenunciaF))]
    public partial class TBDENUNCIA
    {

    }
}