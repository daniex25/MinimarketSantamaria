using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static MinimarketSantamaria.Data.MinimarketSantamariaContext;

namespace MinimarketSantamaria.Data;

public class MinimarketSantamariaContext : IdentityDbContext<Usuario>
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

    //Para roles:
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Usuario>(entityTypeBuilder =>
        {
            entityTypeBuilder.ToTable("AspNetUsers");
            entityTypeBuilder.Property(u => u.UserName)
            .HasMaxLength(100)
            .HasDefaultValue(0);
            entityTypeBuilder.Property(u => u.Nombres)
            .HasMaxLength(60);
            entityTypeBuilder.Property(u => u.Apellidos)
            .HasMaxLength(60);
            entityTypeBuilder.Property(u => u.Dni)
            .HasMaxLength(8);
            entityTypeBuilder.Property(u => u.Edad)
            .HasMaxLength(2);
            //psdt: si se hace cont Int , no tiene HasMaxLength
            entityTypeBuilder.Property(u => u.Direccion)
            .HasMaxLength(120);
            entityTypeBuilder.Property(u => u.FechaNacimiento)
            .HasColumnType("date"); //para fechas
        });

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
