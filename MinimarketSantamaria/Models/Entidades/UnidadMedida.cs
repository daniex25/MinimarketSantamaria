using System.ComponentModel.DataAnnotations;

namespace MinimarketSantamaria.Models.Entidades
{
    public class UnidadMedida
    {
        [Key]
        [Display(Name = "Id")]
        [Required]
        public int IdUnidadMedida { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
