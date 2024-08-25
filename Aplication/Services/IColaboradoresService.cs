using Domain.DTOS;
using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public  interface IColaboradoresService
    {
        Task<IEnumerable<DTOGestorColaboradores>> GetColaboradoresAsync(int IdProveedor);
        //Task RegistrarColaboradorAsync(DTOGestorColaboradores colaboradorDTO);
        Task<AddMessageResponse> AddColaboradores(DTOGestorColaboradores coldto, List<DTOGestorDocColaboradores> doccoladto);

        Task<IEnumerable<DTOGestorDocColaboradores>> GetDocColaboradoresAsync(int Idcolaborador, int IdProveedor);

    }
}
