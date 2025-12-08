using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Areas.Identity.Data.Interface
{
    public interface ProductoIDA
    {
        public IEnumerable<Producto> GetProducto();
    }
}
