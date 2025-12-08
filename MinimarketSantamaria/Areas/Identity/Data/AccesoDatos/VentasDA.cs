
using MinimarketSantamaria.Data;
using MinimarketSantamaria.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using MinimarketSantamaria.Areas.Identity.Data.Interface;

namespace MinimarketSantamaria.Areas.Identity.Data.AccesoDatos
{
    public class VentasDA : VentasIDA
    {
        public IEnumerable<Ventas> GetVenta()
        {
            var listado = new List<Ventas>();
            using (var db = new MinimarketSantamariaContext())
            {
                listado = db.Ventas.Include(x => x.Producto).Include(x => x.Sucursal)
                    .Include(x => x.UnidadMedida).ToList();
            }
            return listado;
        }
        public int InsertVenta(Ventas entidad)
        {
            var resultado = 0;
            using (var db = new MinimarketSantamariaContext())
            {
                db.Add(entidad);
                db.SaveChanges();
                resultado = entidad.IdVentas;
            }
            return resultado;
        }

        public Ventas GetIdVentas(int id)
        {
            var resultado = new Ventas();
            using (var db = new MinimarketSantamariaContext())
            {
                resultado = db.Ventas.Where(item => item.IdVentas == id).FirstOrDefault();
            }
            return resultado;
        }

        public Boolean UpdateVentas(Ventas entity)
        {
            var resultado = false;
            using (var db = new MinimarketSantamariaContext())
            {
                db.Ventas.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.Entry(entity).Property(item => item.Registro).IsModified = false;
                resultado = db.SaveChanges() != 0;

            }
            return resultado;
        }

        public Boolean DeleteVentas(int id)
        {
            var resultado = false;
            using (var db = new MinimarketSantamariaContext())
            {
                var entity = new Ventas() { IdVentas = id };
                db.Ventas.Attach(entity);
                db.Ventas.Remove(entity);
                resultado = db.SaveChanges() != 0;
            }
            return resultado;
        }
    }
}

