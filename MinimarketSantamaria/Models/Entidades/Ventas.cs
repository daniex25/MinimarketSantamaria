using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimarketSantamaria.Models.Entidades
{
    public class Ventas
    {
        [Key]
        [Display(Name = "Id")]
        [Required]
        public int IdVentas { get; set; }

        public int IdSucursal { get; set; }
        [ForeignKey("IdSucursal")]
        [JsonIgnore]
        public virtual Sucursal? Sucursal { get; set; }

        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        [JsonIgnore]
        public virtual Producto? Producto { get; set; }

        public int IdUnidadMedida { get; set; }
        [ForeignKey("IdUnidadMedida")]
        [JsonIgnore]
        public virtual UnidadMedida? UnidadMedida { get; set;}

        [Display(Name ="Fecha Venta")]
        [Required]
        public DateTime Registro {  get; set; }

        [Display(Name = "Fecha Modificacion")]
        [Required]
        public DateTime FechaModificacion { get; set; }
    }
}
