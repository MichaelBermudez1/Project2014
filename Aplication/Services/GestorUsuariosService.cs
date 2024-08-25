using Domain.DTOS;
using Domain.Interfaces;
using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GestorUsuariosService : IGestorUsuariosService
    {
        private readonly IGestorUsuariosRepository _gestorusuariosRepository;
        public GestorUsuariosService(IGestorUsuariosRepository gestorusuarioRepository)
        {
            _gestorusuariosRepository = gestorusuarioRepository;
        }

        public async Task<ProveedorMessageResponse> GetProveedor(DTOUsuario usuDTO)
        {
            if (usuDTO == null)
                throw new ArgumentNullException(nameof(DTOUsuario));

            // Convertir DTO a entidad
            var usuario = new GestorUsuario
            {
                UsuavNom = usuDTO.Nombre,
                UsuavPass = usuDTO.Clave,
                UsuaiId = Convert.ToInt32(usuDTO.UsuId)
                
            };

            return await _gestorusuariosRepository.GetProveedor(usuario);
        }

        public async Task<LoginMessageResponse> Login(DTOUsuario usu)
        {
            if (usu == null)
                throw new ArgumentNullException(nameof(DTOUsuario));

            // Convertir DTO a entidad
            var usuario = new GestorUsuario
            {
                UsuavNom = usu.Nombre,
                UsuavPass = usu.Clave,
              

            };
            return await _gestorusuariosRepository.Login(usuario);
        }
    }
  
}

