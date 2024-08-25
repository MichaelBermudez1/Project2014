using Domain.DTOS;
using Domain.Models;
using Infraestructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Servicio_GestorDocumentario.Custom;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Servicio_GestorDocumentario.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Gestor2Context _dbPruebaContext;
        private readonly Utilitarios _utilidades;
        public AuthController(Gestor2Context dbPruebaContext, Utilitarios utilidades)
        {
            _dbPruebaContext = dbPruebaContext;
            _utilidades = utilidades;
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(DTOUsuario objeto)
        {

            var modeloUsuario = new GestorUsuario
            {
                UsuavNombre = objeto.Nombre,
                UsuavEmail = objeto.Correo,
                GruiId = 1,
                RoliId = 1,
                UsuavPass = _utilidades.encriptarSHA256(objeto.Clave)
                
            };

            await _dbPruebaContext.GestorUsuarios.AddAsync(modeloUsuario);
            await _dbPruebaContext.SaveChangesAsync();

            if (modeloUsuario.UsuaiId!= 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(DTOLogin objeto)
        {
            var usuarioEncontrado = await _dbPruebaContext.GestorUsuarios
                                                    .Where(u =>
                                                        u.UsuavEmail == objeto.Correo &&
                                                        u.UsuavPass == _utilidades.encriptarSHA256(objeto.Clave)
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidades.generarJWT(usuarioEncontrado) });
        }

    }
}
