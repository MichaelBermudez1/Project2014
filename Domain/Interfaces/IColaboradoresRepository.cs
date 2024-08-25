using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IColaboradoresRepository
    {
        Task<IEnumerable<GestorColaboradores>> GetColaboradoresAsync(int IdProveedor);
        Task<AddMessageResponse> AddColaboradores(GestorColaboradores colaboradores, List<GestorDocColaboradores> doccolaboradores);
        Task<IEnumerable<GestorDocColaboradores>> GetDocColaboradoresAsync(int Idcolaborador, int IdProveedor);
    }
}
