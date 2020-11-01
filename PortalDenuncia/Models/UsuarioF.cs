using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PortalDenuncia.Models
{
    public class UsuarioF
    {
        [Display(Name ="Usuario")]
        public int idusuario { get; set; }
        [Required]
        [Display(Name ="Numero de documento")]
        public string numdocu { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name ="Apellido paterno")]
        public string apellidopa { get; set; }
        [Required]
        [Display(Name ="Apellido materno")]
        public string apellidoma { get; set; }
        [Display(Name ="Celular")]
        public string celular { get; set; }
        [Display(Name ="Correo")]
        [DataType(DataType.EmailAddress)]
        public string correo { get; set; }
        [Required]
        [Display(Name ="Password")]
        public string password { get; set; }
        
        [Display(Name ="Vuelva a ingresar la contraseña")]
        [Compare("password", ErrorMessage ="Los passwords no concuerdan")]
        [NotMapped]
        public String valicontra { get; set; }
        [Required]
        [Display(Name ="Tipo de documento")]
        public int idtipdocu { get; set; }

    }
    [MetadataType(typeof(UsuarioF))]
    public partial class TBUSUARIO
    {
        public String valicontra { get; set; }
    }
}