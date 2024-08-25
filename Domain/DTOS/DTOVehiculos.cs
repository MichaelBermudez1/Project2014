using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOS
{
    public class DTOVehiculos
    {
        public int IdVehiculo { get; set; }

        public int IdProveedor { get; set; }

        public string VehiculoMarca { get; set; } = string.Empty;

        public string VehiculoModelo { get; set; }= string.Empty;

        public int VehiculoAnio { get; set; }

        public string VehiculoPlaca { get; set; } = string.Empty;
        public virtual ICollection<DTODocVehiculos> DTODocVehiculos { get; set; } = new List<DTODocVehiculos>();


    }
}
