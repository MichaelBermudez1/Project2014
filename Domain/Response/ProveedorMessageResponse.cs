using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public  class ProveedorMessageResponse
    {
         public int IdProv { get; set; }

        public string NomProv { get; set; } = null!;

        public string? Codigo { get; set; }

        public string? Mensaje { get; set; }

        public string? Descripcion { get; set; }


    }
}
