using Domain.Interfaces;
using Domain.Models;
using Domain.Response;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class GestorUsuariosRepository : IGestorUsuariosRepository
    {
        private readonly Gestor2Context _context;
        public GestorUsuariosRepository(Gestor2Context context)
        {
            _context = context;
        }

        public async Task<ProveedorMessageResponse> GetProveedor(GestorUsuario usu)
        {
            ProveedorMessageResponse response = new ProveedorMessageResponse();

            try
            {
                // Obtener Id del Usuario
                var IdProveedor = await (
                    from proveedor in _context.GestorProveedors
                    join usuario in _context.GestorUsuarios
                    on proveedor.UsuaiId equals usuario.UsuaiId
                    where usuario.UsuaiId == usu.UsuaiId
                          && usuario.UsuavNom == usu.UsuavNom
                          && usuario.UsuavPass == usu.UsuavPass
                    select proveedor).FirstOrDefaultAsync();

                if (IdProveedor != null && IdProveedor.ProviId != 0)
                {
                    response.Mensaje = "Se encontró el Proveedor";
                    response.Codigo = "1";
                    response.Descripcion = "";
                    response.IdProv = IdProveedor.ProviId;
                    response.NomProv = IdProveedor.ProvvNombre;
                }
                else
                {
                    response.Mensaje = "No se encontró el usuario";
                    response.Codigo = "0";
                    response.Descripcion = "";
                    response.IdProv = 1;
                }
            }
            catch (Exception ex)
            {
                response.Mensaje = "Ocurrió un error";
                response.Codigo = "0";
                response.Descripcion = ex.Message;
                response.IdProv = 0;
            }

            return response;

        }

        public async Task<LoginMessageResponse> Login(GestorUsuario usu)
        {
            LoginMessageResponse response = new LoginMessageResponse();
            // Obtener Id del Usuario
            var IdUsuario = await _context.GestorUsuarios
                .FirstOrDefaultAsync(w => w.UsuavNom == usu.UsuavNom && w.UsuavPass == usu.UsuavPass);

            if (IdUsuario != null && IdUsuario.UsuaiId != 0)
            {
                response.Mensaje = "Se encontró el usuario";
                response.Codigo = "1";
                response.Descripcion = "";
                response.IdUsu = IdUsuario.UsuaiId.ToString();
            }
            else
            {
                response.Mensaje = "No se encontró el usuario";
                response.Codigo = "0";
                response.Descripcion = "";
                response.IdUsu = string.Empty;
            }

            return response;
        }
    }
            
        
    
}
