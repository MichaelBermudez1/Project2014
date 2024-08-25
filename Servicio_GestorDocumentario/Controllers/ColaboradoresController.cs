using Application.Services;
using Domain.DTOS;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicio_GestorDocumentario.HelperRequest;

namespace Servicio_GestorDocumentario.Controllers
{
    public class ColaboradoresController : Controller
    {

        private readonly IColaboradoresService _colaboradorService;
   
        public ColaboradoresController(IColaboradoresService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("GetAllColaboradores/{IdProveedor}")]
        public async Task<IActionResult> GetAllColaboradores(int IdProveedor)
        {
            var colaboradores = await _colaboradorService.GetColaboradoresAsync(IdProveedor);
            return Ok(colaboradores);
        }

        [HttpGet("GetAllDocColaboradores/{IdColaborador}/{IdProveedor}")]
        public async Task<IActionResult> GetAllDocPorColaborador(int IdColaborador, int IdProveedor)
        {
            var doccolaboradores = await _colaboradorService.GetDocColaboradoresAsync(IdColaborador, IdProveedor);
            return Ok(doccolaboradores);

       }

        [HttpPost("add-colaboradores")]
        public async Task<IActionResult> AddColaboradores([FromBody] ColaboradorConDocumentosRequest request)
        {
            if (request.Colaboradores == null)
            {
                return BadRequest("El colaborador no puede estar vacío.");
            }

            if (request.Documentos == null || !request.Documentos.Any())
            {
                return BadRequest("La lista de documentos no puede estar vacía.");
            }

            var response = await _colaboradorService.AddColaboradores(request.Colaboradores, request.Documentos);

            if (response.Codigo == "1")
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(500, response);
            }
        }

     

      
    }
}
