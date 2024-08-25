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
    public interface IGestorVehiculosService
    {
        Task<IEnumerable<DTOVehiculos>> GetAllVehiculosAsync(int IdProveedor);
        Task<AddMessageResponse> AddVehiculos(DTOVehiculos vehi,List<DTODocVehiculos> docvehiculo);

        Task<IEnumerable<GestorDocVehiculos>> GetDocVehiculosAsync(int IdVehiculo, int IdProveedor);
    }
}
