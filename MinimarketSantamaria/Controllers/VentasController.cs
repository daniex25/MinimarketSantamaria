using MinimarketSantamaria.Areas.Identity.Data.AccesoDatos;
using MinimarketSantamaria.Areas.Identity.Data.Interface;
using MinimarketSantamaria.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace MinimarketSantamaria.Controllers
{
    [Authorize]
    public class VentasController : Controller
    {
        private readonly ProductoIDA productoDA;
        private readonly SucursalIDA sucursalDA;
        private readonly UnidadMedidaIDA unidadMedidaDA;
        private readonly VentasIDA ventasDA;

        public VentasController(ProductoIDA productoDA, SucursalIDA sucursalDA, UnidadMedidaIDA unidadMedidaDA, VentasIDA ventasDA)
        {
            this.productoDA = productoDA;
            this.sucursalDA = sucursalDA;
            this.unidadMedidaDA = unidadMedidaDA;
            this.ventasDA = ventasDA;
        }

        public IActionResult ListadoVentas(int page=1)
        {
            var pageNumber = page;
            var modelo = ventasDA.GetVenta();
            var informacionDB = modelo.OrderByDescending(x => x.IdProducto).
                ToList().ToPagedList(pageNumber, 6);
            return View(informacionDB);
        }

        public IActionResult Create()
        {
            ViewBag.UnidadMedida = unidadMedidaDA.GetUnidadMedida();
            ViewBag.Producto = productoDA.GetProducto();
            ViewBag.Sucursal = sucursalDA.GetSucursal();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ventas Entidad)
        {
            Entidad.IdVentas = 0;
            Entidad.Registro = DateTime.Now;
            var resultado = ventasDA.InsertVenta(Entidad);
            if (resultado > 0)
            {
                return RedirectToAction("ListadoVentas");
            }
            else
            {
                return View(Entidad);
            }
        }

        public IActionResult Edit(int id)
        {
            ViewBag.UnidadMedida = unidadMedidaDA.GetUnidadMedida();
            ViewBag.Producto = productoDA.GetProducto();
            ViewBag.Sucursal = sucursalDA.GetSucursal();
            var model = ventasDA.GetIdVentas(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Ventas entidad)
        {
            entidad.FechaModificacion = DateTime.Now;
            var resultado = ventasDA.UpdateVentas(entidad);
            if (resultado)
            {
                return RedirectToAction("ListadoVentas");
            }
            else
            {
                return View(entidad);
            }
        }

        public IActionResult Details(int id)
        {
            var model = ventasDA.GetIdVentas(id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var resultado = ventasDA.GetIdVentas(id);
            return View(resultado);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = ventasDA.DeleteVentas(id);
            return RedirectToAction("ListadoVentas");
        }
    }
}
