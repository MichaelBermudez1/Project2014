using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class DTOGestorColaboradores
    {
        public int IdColaborador { get; set; }

        public int IdProveedor { get; set; }

        public string ColaboradoresNombres { get; set; } = null!;

        public string ColaboradoresApellidosPat { get; set; } = null!;

        public string ColaboradoresApellidosMat { get; set; } = null!;

        public string ColaboradoresDireccion { get; set; } = null!;

        public string ColaboradoresTipoDoc { get; set; } = null!;

        public int ColaboresNumDoc { get; set; }

        public string ColaboradoresNacionalidad { get; set; } = null!;

        public string ColaboradoresPuestoTrabajo { get; set; } = null!;

        public string? ColaboradoresSexo { get; set; }

        public bool ColaiEstadoTrab { get; set; }

        public virtual ICollection<DTOGestorDocColaboradores> DTOGestorDocColaboradores { get; set; } = new List<DTOGestorDocColaboradores>();

        public virtual GestorProveedor Provi { get; set; } = null!;
    }
}
