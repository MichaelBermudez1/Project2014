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
    public class GestorProveedorRepository : IGestorProveedorRepository
    {
        private readonly Gestor2Context _context;
        public GestorProveedorRepository(Gestor2Context context)
        {
            _context = context;

        }
        public async Task<IEnumerable<GestorProveedor>> GetProveedor(int idusu)
        {
           return await _context.GestorProveedors
          .Where(c => c.UsuaiId==idusu)
          .ToListAsync();
        }
    }
}
