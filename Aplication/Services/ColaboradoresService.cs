using Domain.DTOS;
using Domain.Interfaces;
using Domain.Models;
using Domain.Response;
using Infraestructure.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ColaboradoresService : IColaboradoresService
    {
        private readonly IColaboradoresRepository _colaboradorRepository;
        public ColaboradoresService(IColaboradoresRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public async Task<IEnumerable<DTOGestorColaboradores>> GetColaboradoresAsync(int IdProveedor)
        {
            IEnumerable<GestorColaboradores> colab = await _colaboradorRepository.GetColaboradoresAsync(IdProveedor);
            var dtoColaboradores = colab.Adapt<IEnumerable<DTOGestorColaboradores>>();
            return dtoColaboradores;
        }

        public async Task<AddMessageResponse> AddColaboradores(DTOGestorColaboradores colDTO, List<DTOGestorDocColaboradores> doccolDTO)
        {
            AddMessageResponse response = new AddMessageResponse();

            try
            {
                if (colDTO == null)
                    throw new ArgumentNullException(nameof(colDTO), "El colaborador  no puede estar vacío.");

                if (doccolDTO == null || !doccolDTO.Any())
                    throw new ArgumentNullException(nameof(doccolDTO), "La lista de documentos no puede estar vacía.");

                // Convertir DTO a entidad usando AutoMapper
                var vehiculo = colDTO.Adapt<GestorColaboradores>();

                // Convertir lista de DTOs a entidades usando AutoMapper
                var documentos = doccolDTO.Select(d => d.Adapt<GestorDocColaboradores>()).ToList();

                // Llamar al repositorio para agregar el vehículo y los documentos
                var result = await _colaboradorRepository.AddColaboradores(vehiculo, documentos);

                if (result.Codigo == "1")
                {
                    response.Mensaje = "Se registraron correctamente el colaborador y sus documentos";
                    response.Descripcion = "Registro Correcto";
                    response.Codigo = "1";
                }
                else
                {
                    response.Mensaje = "Ocurrió un error al registrar el colaborador y/o sus documentos";
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

        public async Task<IEnumerable<DTOGestorDocColaboradores>> GetDocColaboradoresAsync(int Idcolaborador, int IdProveedor)
        {
            IEnumerable<GestorDocColaboradores> colab = await _colaboradorRepository.GetDocColaboradoresAsync(Idcolaborador, IdProveedor);
            var dtoDocColaboradores = colab.Adapt<IEnumerable<DTOGestorDocColaboradores>>();
            return dtoDocColaboradores;

        }
    }
}
