using Application.Services;
using Domain.DTOS;
using Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicio_GestorDocumentario.Controllers
{
    public class GestorUsuariosController : Controller
    {
        private readonly IGestorUsuariosService _usuariosService;
        public GestorUsuariosController(IGestorUsuariosService usuarioservice)
        {
            _usuariosService = usuarioservice;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: GestorUsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost("GetProveedor")]
        public async Task<IActionResult> GetProveedor([FromBody] DTOUsuario Usu)
        {
            var vehiculos = await _usuariosService.GetProveedor(Usu);
            return Ok(vehiculos);
        }

        [HttpPost("GetLogin")]
        public async Task<IActionResult> GetLogin([FromBody] DTOUsuario Usu)
        {
            LoginMessageResponse response = new LoginMessageResponse();
             response = await _usuariosService.Login(Usu);
            return Ok(response);
        }
    }
}
