using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicio_GestorDocumentario.Controllers
{
    public class GestorProveedorController : Controller
    {

        private readonly IGestorProveedorService _proveedorService;

        public GestorProveedorController(IGestorProveedorService service)
        {
            _proveedorService = service;
        }
       [HttpGet("GetProveedor/{id}")]
        public async Task<IActionResult> GetProveedor(int id)
        {
            var colaboradores = await _proveedorService.GetProveedor(id);
            return Ok(colaboradores);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestorProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GestorProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestorProveedorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestorProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
