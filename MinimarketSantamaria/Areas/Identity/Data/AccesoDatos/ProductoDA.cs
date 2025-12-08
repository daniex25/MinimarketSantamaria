using MinimarketSantamaria.Areas.Identity.Data.Interface;
using MinimarketSantamaria.Data;
using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Areas.Identity.Data.AccesoDatos
{
    public class ProductoDA : ProductoIDA
    {
        public IEnumerable<Producto> GetProducto()
        {
            var listado = new List<Producto>();
            using(var db = new MinimarketSantamariaContext())
            {
                listado = db.Producto.ToList();
            }
            return listado;
        }
    }
}
