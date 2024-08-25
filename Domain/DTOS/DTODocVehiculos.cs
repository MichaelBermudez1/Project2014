using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public  class DTODocVehiculos
    {
        public int DocIdVehiculo { get; set; }

        public int IdVehiculo { get; set; }

        public int IdProveedor { get; set; }

        public string? DescrpicionVehiculo { get; set; }

        public DateTime FechaRegistroVehiculo { get; set; }

        public string? DocumentoVehiculoRuta { get; set; }

        public string? IdDocumentoStorage { get; set; }

      
    }
}
