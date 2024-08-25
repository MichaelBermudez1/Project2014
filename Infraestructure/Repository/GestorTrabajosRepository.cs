using Domain.Interfaces;
using Domain.Models;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class GestorTrabajosRepository:IGestorTrabajosRepository
    {

        private readonly Gestor2Context _context;
        public GestorTrabajosRepository(Gestor2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GestorTrabajos>> GetAllTrabajosAsync()
        {
            return await _context.GestorTrabajos
           .Include(c => c.GestorDocTrabajos)
           .ToListAsync();
        }
    }
}
