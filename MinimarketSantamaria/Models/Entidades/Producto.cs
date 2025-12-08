using System.ComponentModel.DataAnnotations;

namespace MinimarketSantamaria.Models.Entidades
{
    public class Producto
    {
        [Key]
        [Display(Name ="Id")]
        [Required]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        [Required]
        public string nombreProducto { get; set; }

        [Display(Name = "Nombre Empresa")]
        [Required]
        public string nombreEmpresa { get; set; }

        [Display(Name ="Precio")]
        [Required]
        public string precio { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
