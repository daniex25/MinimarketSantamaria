using MinimarketSantamaria.Areas.Identity.Data.Interface;
using MinimarketSantamaria.Data;
using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Areas.Identity.Data.AccesoDatos
{
    public class SucursalDA : SucursalIDA
    {
        public IEnumerable<Sucursal> GetSucursal()
        {
            var listado = new List<Sucursal>();
            using(var db = new MinimarketSantamariaContext())
            {
                listado = db.Sucursal.ToList();
            }
            return listado;
        }
    }
}
