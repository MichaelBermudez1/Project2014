using Azure;
using Domain.Interfaces;
using Domain.Models;
using Domain.Response;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class GestorVehiculosRepository : IGestorVehiculosRepository
    {
        private readonly Gestor2Context _context;
        public GestorVehiculosRepository(Gestor2Context context)
        {
            _context = context;
        }

        public async Task<AddMessageResponse> AddVehiculos(GestorVehiculos vehiculo,List<GestorDocVehiculos> docvehiculo)
        {
            AddMessageResponse response = new AddMessageResponse();

            try
            {
                if (vehiculo == null)
                    throw new ArgumentNullException(nameof(vehiculo), "El vehículo no puede estar vacío.");

                if (docvehiculo == null || !docvehiculo.Any())
                    throw new ArgumentNullException(nameof(docvehiculo), "La lista de documentos no puede estar vacía.");

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    // Agregar vehículo
                    _context.GestorVehiculos.Add(vehiculo);
                    await _context.SaveChangesAsync();

                    // Asociar los documentos con el vehículo
                    foreach (var doc in docvehiculo)
                    {
                        doc.VehiId = vehiculo.VehiId; // Suponiendo que tienes una propiedad VehiculoId en GestorDocVehiculos
                    }

                    // Agregar documentos de vehículos
                    _context.GestorDocVehiculos.AddRange(docvehiculo);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    response.Mensaje = "Se registraron correctamente el vehículo y sus documentos";
                    response.Descripcion = "Registro Correcto";
                    response.Codigo = "1";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Descripcion = ex.Message;
                response.Mensaje = "Ocurrió un error al registrar el vehículo y/o sus documentos";
                response.Codigo = "0";
                return response;
            }
        }

        public async Task<IEnumerable<GestorVehiculos>> GetAllVehiculosAsync(int IdProveedor)
        {
              return await _context.GestorVehiculos
             .Include(c => c.GestorDocVehiculos)
             .Where(c=>c.ProviId == IdProveedor)
             .ToListAsync();
        }

        public async Task<IEnumerable<GestorDocVehiculos>> GetDocVehiculosAsync(int IdVehiculo,int IdProveedor)
        {
            return await _context.GestorDocVehiculos
           .Where(c => c.VehiId == IdVehiculo && c.ProviId== IdProveedor)
           .ToListAsync();
        }
    }
}
