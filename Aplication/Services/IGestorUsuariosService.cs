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
    public interface IGestorUsuariosService
    {
       
        Task<ProveedorMessageResponse> GetProveedor(DTOUsuario usu);
        Task<LoginMessageResponse> Login(DTOUsuario usu);
    }
}
