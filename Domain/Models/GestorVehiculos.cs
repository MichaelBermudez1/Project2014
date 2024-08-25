using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorVehiculos
{
    public int VehiId { get; set; } 

    public int ProviId { get; set; }

    public string VehivMarca { get; set; } = string.Empty;

    public string VehivModelo { get; set; } = string.Empty;

    public int VehinAno { get; set; }

    public string VehicPlaca { get; set; } = string.Empty;

    public virtual ICollection<GestorDocVehiculos> GestorDocVehiculos { get; set; } = new List<GestorDocVehiculos>();

    public virtual GestorProveedor Provi { get; set; } = null!;
}
