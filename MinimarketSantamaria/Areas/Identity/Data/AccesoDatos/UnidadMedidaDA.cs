using MinimarketSantamaria.Areas.Identity.Data.Interface;
using MinimarketSantamaria.Data;
using MinimarketSantamaria.Models.Entidades;

namespace MinimarketSantamaria.Areas.Identity.Data.AccesoDatos
{
    public class UnidadMedidaDA : UnidadMedidaIDA
    {
        public IEnumerable<UnidadMedida>GetUnidadMedida()
        {
            var listado = new List<UnidadMedida>();
            using (var db = new MinimarketSantamariaContext())
            {
                listado = db.UnidadMedida.ToList();
            }
            return listado;
        }
    }
}
