using Domain.Models;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGestorVehiculosRepository
    {
        Task<IEnumerable<GestorVehiculos>> GetAllVehiculosAsync(int IdProveedor);

        Task<AddMessageResponse>AddVehiculos(GestorVehiculos vehi,List<GestorDocVehiculos> docvehiculo);
        Task<IEnumerable<GestorDocVehiculos>> GetDocVehiculosAsync(int IdVehiculo, int IdProveedor);

    }
}
