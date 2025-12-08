using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MinimarketSantamaria.Data;

public class MinimarketSantamariaContext : IdentityDbContext
{
    public class Usuario : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Edad { get; set; }
        public string Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
    public MinimarketSantamariaContext(DbContextOptions<MinimarketSantamariaContext> options)
        : base(options)
    {
    }

    public MinimarketSantamariaContext()
    {

    }
    public DbSet<MinimarketSantamaria.Models.Entidades.Producto> Producto { get; set; }
    public DbSet<MinimarketSantamaria.Models.Entidades.Sucursal> Sucursal { get; set; }
    public DbSet<MinimarketSantamaria.Models.Entidades.UnidadMedida> UnidadMedida { get; set; }
    public DbSet<MinimarketSantamaria.Models.Entidades.Ventas> Ventas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-6C53PKU;Database=MinimarketSantamaria;" +
            "Password=1234;User Id=sa;MultipleActiveResultSets=True;Encrypt=False");
    }
}
