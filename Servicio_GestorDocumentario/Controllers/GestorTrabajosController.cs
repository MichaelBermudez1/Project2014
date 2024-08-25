using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicio_GestorDocumentario.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GestorTrabajosController : ControllerBase
    {
        private readonly IGestorTrabajosService _trabajosService;
        public GestorTrabajosController(IGestorTrabajosService trabajosService)
        {
            _trabajosService = trabajosService;
        }

        [HttpGet("GetAllTrabajos")]
        public async Task<IActionResult> GetAllTrabajos()
        {
            var vehiculos = await _trabajosService.GetAllTrabajosAsync();
            return Ok(vehiculos);
        }

       
    }
}
