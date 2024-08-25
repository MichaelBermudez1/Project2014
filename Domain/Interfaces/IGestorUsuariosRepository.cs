using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public  interface IGestorUsuariosRepository
    {
        Task<ProveedorMessageResponse> GetProveedor(GestorUsuario usu);
        Task<LoginMessageResponse> Login(GestorUsuario usu);
    }
}
