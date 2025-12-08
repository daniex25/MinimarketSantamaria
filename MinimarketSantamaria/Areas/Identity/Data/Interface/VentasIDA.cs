using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Areas.Identity.Data.Interface
{
    public interface VentasIDA
    {
        public IEnumerable<Ventas> GetVenta();
        public int InsertVenta(Ventas entidad);
        public Ventas GetIdVentas(int id);
        public Boolean UpdateVentas(Ventas entity);
        public Boolean DeleteVentas(int id);
    }
}
