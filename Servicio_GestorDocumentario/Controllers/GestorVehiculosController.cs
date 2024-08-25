using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_GestorDocumentario.HelperRequest;

namespace Servicio_GestorDocumentario.Controllers
{
    
  
    public class GestorVehiculosController : Controller
    {
        private readonly IGestorVehiculosService _vehiculosService;
        public GestorVehiculosController(IGestorVehiculosService vehiculosservice)
        {
            _vehiculosService = vehiculosservice;
        }

        [HttpGet("GetAllVehiculos/{IdProveedor}")]
        public async Task<IActionResult> GetAllVehiculos(int IdProveedor)
        {
            var vehiculos = await _vehiculosService.GetAllVehiculosAsync(IdProveedor);
            return Ok(vehiculos);
        }

        [HttpGet("GetAllDocVehiculos/{IdVehiculo}/{IdProveedor}")]
        public async Task<IActionResult> GetAllDocVehiculos(int IdVehiculo,int IdProveedor)
        {
            var vehiculos = await _vehiculosService.GetDocVehiculosAsync(IdVehiculo,IdProveedor);
            return Ok(vehiculos);
        }

        // GET: GestorVehiculosController/Details/5

        // POST: GestorVehiculosController/Create
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

        [HttpPost("add-vehiculo")]
        public async Task<IActionResult> AddVehiculo([FromBody] VehiculoConDocumentosRequest request)
        {
            if (request.Vehiculo == null)
            {
                return BadRequest("El vehículo no puede estar vacío.");
            }

            if (request.Documentos == null || !request.Documentos.Any())
            {
                return BadRequest("La lista de documentos no puede estar vacía.");
            }

            var response = await _vehiculosService.AddVehiculos(request.Vehiculo, request.Documentos);

            if (response.Codigo == "1")
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, response);
            }
        }

        // GET: GestorVehiculosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GestorVehiculosController/Edit/5
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

        // GET: GestorVehiculosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestorVehiculosController/Delete/5
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
