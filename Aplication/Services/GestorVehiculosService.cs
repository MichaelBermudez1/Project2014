using Domain.DTOS;
using Domain.Interfaces;
using Domain.Models;
using Domain.Response;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GestorVehiculosService : IGestorVehiculosService
    {
        private readonly IGestorVehiculosRepository _vehiculosRepository;
        public GestorVehiculosService(IGestorVehiculosRepository vehiculosRepository)
        {
            _vehiculosRepository = vehiculosRepository;
        }

        public async Task<AddMessageResponse> AddVehiculos(DTOVehiculos vehiDTO, List<DTODocVehiculos> docvehiculoDTO)
        {
            AddMessageResponse response = new AddMessageResponse();

            try
            {
                if (vehiDTO == null)
                    throw new ArgumentNullException(nameof(vehiDTO), "El vehículo no puede estar vacío.");

                if (docvehiculoDTO == null || !docvehiculoDTO.Any())
                    throw new ArgumentNullException(nameof(docvehiculoDTO), "La lista de documentos no puede estar vacía.");

                // Convertir DTO a entidad usando AutoMapper
                var vehiculo = vehiDTO.Adapt<GestorVehiculos>();

                // Convertir lista de DTOs a entidades usando AutoMapper
                var documentos = docvehiculoDTO.Select(d => d.Adapt<GestorDocVehiculos>()).ToList();

                // Llamar al repositorio para agregar el vehículo y los documentos
                var result = await _vehiculosRepository.AddVehiculos(vehiculo, documentos);

                if (result.Codigo == "1")
                {
                    response.Mensaje = "Se registraron correctamente el vehículo y sus documentos";
                    response.Descripcion = "Registro Correcto";
                    response.Codigo = "1";
                }
                else
                {
                    response.Mensaje = "Ocurrió un error al registrar el vehículo y/o sus documentos";
                    response.Descripcion = "Error en el servicio";
                    response.Codigo = "0";
                }
            }
            catch (Exception ex)
            {
                response.Descripcion = ex.Message;
                response.Mensaje = "Ocurrió un error al registrar el vehículo y/o sus documentos";
                response.Codigo = "0";
            }

            return response;

        }

        public async Task<IEnumerable<DTOVehiculos>> GetAllVehiculosAsync(int IdProveedor)
        {
            IEnumerable<GestorVehiculos> vehiculos = await _vehiculosRepository.GetAllVehiculosAsync(IdProveedor);
            var dtoVehiculos = vehiculos.Adapt<IEnumerable<DTOVehiculos>>();
            return dtoVehiculos;


        }

        public async Task<IEnumerable<GestorDocVehiculos>> GetDocVehiculosAsync(int IdVehiculo, int IdProveedor)
        {
            return await _vehiculosRepository.GetDocVehiculosAsync(IdVehiculo, IdProveedor);
        }
    }
}
