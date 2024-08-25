using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GestorTrabajosService : IGestorTrabajosService
    {
        private readonly IGestorTrabajosRepository _trabajosRepository;
        public GestorTrabajosService(IGestorTrabajosRepository trabajosRepository)
        {
            _trabajosRepository = trabajosRepository;
        }

        public async Task<IEnumerable<GestorTrabajos>> GetAllTrabajosAsync()
        {
            return await _trabajosRepository.GetAllTrabajosAsync();
        }
    }
}
