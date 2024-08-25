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
    public class ColaboradoresRepository : IColaboradoresRepository
    {
        private readonly Gestor2Context _context;
        public ColaboradoresRepository(Gestor2Context context)
        {
            _context = context;
        }
        public async Task AddColaboradorAsync(GestorColaboradores colaborador)
        {
            if (colaborador == null)
                throw new ArgumentNullException(nameof(colaborador));

            // Agregar colaborador
            _context.GestorColaboradores.Add(colaborador);

            // Agregar documentos asociados
            foreach (var doc in colaborador.GestorDocColaboradores)
            {
                doc.ColaiId = colaborador.ColaiId;
                doc.ProviId = 1;
                _context.GestorDocColaboradores.Add(doc);
            }

            // Guardar cambios en la base de datos
             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<GestorColaboradores>> GetColaboradoresAsync(int IdProveedor)
        {
            return await _context.GestorColaboradores
            .Include(c => c.GestorDocColaboradores)
            .Where(c => c.ProviId == IdProveedor)
            .ToListAsync();
        }

        public async Task<AddMessageResponse> AddColaboradores(GestorColaboradores colaboradores, List<GestorDocColaboradores> doccolaboradores)
        {
            AddMessageResponse response = new AddMessageResponse();

            try
            {
                if (colaboradores == null)
                    throw new ArgumentNullException(nameof(colaboradores), "El colaborador  no puede estar vacío.");

                if (doccolaboradores == null || !doccolaboradores.Any())
                    throw new ArgumentNullException(nameof(doccolaboradores), "La lista de documentos de colaboradores no puede estar vacía.");

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    // Agregar vehículo
                    _context.GestorColaboradores.Add(colaboradores);
                    await _context.SaveChangesAsync();

                    // Asociar los documentos con el colaborador
                    foreach (var doc in doccolaboradores)
                    {
                        doc.ColaiId = colaboradores.ColaiId; // Suponiendo que tienes una propiedad VehiculoId en GestorDocVehiculos
                    }

                    // Agregar documentos de colaboradores
                    _context.GestorDocColaboradores.AddRange(doccolaboradores);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    response.Mensaje = "Se registraron correctamente el colaborador y sus documentos";
                    response.Descripcion = "Registro Correcto";
                    response.Codigo = "1";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.Descripcion = ex.Message;
                response.Mensaje = "Ocurrió un error al registrar el colaborador y/o sus documentos";
                response.Codigo = "0";
                return response;
            }
        }

        public async Task<IEnumerable<GestorDocColaboradores>> GetDocColaboradoresAsync(int Idcolaborador, int IdProveedor)
        {
            return await _context.GestorDocColaboradores
           .Where(c => c.ColaiId == Idcolaborador && c.ProviId == IdProveedor)
           .ToListAsync();
        }

    }
}
