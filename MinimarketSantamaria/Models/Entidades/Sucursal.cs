using System.ComponentModel.DataAnnotations;

namespace MinimarketSantamaria.Models.Entidades
{
    public class Sucursal
    {
        [Key]
        [Display(Name = "Id")]
        [Required]
        public int IdSucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [Required]
        public string nombreSucursal { get; set; }

        [Display(Name = "Departamento Sucursal")]
        [Required]
        public string departamentoSucursal { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
