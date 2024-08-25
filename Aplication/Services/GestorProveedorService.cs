using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GestorProveedorService : IGestorProveedorService
    {
        private readonly IGestorProveedorRepository _gestorproveedorRepository;
        public GestorProveedorService(IGestorProveedorRepository gestorproveedorRepository)
        {
            _gestorproveedorRepository = gestorproveedorRepository;
        }

        public async Task<IEnumerable<GestorProveedor>> GetProveedor(int idusu)
        {
            return await _gestorproveedorRepository.GetProveedor(idusu);
        }
    }
}
