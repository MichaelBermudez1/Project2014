using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class DTOGestorDocColaboradores
    {
        public int IdDocColaboradores { get; set; }

        public int? IdColaboradores { get; set; }

        public int? IdProveedor { get; set; }

        public string? DocDecripcionDocumentosColaboradores    { get; set; }

        public DateTime DocFechaRegistroDocColabores { get; set; }

        public string? DocumentoColaboresRuta{ get; set; }

        public string? IdDocumentoStorageColaborador { get; set; }

     
    }
}
