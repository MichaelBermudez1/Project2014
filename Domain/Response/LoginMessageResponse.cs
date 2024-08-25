using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Response
{
    public class LoginMessageResponse
    {
        public string? Codigo { get; set; }

        public string? Mensaje { get; set; }

        public string? Descripcion { get; set; }

        public string? IdUsu { get; set; }

    }
}
