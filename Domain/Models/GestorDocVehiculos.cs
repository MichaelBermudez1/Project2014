using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorDocVehiculos
{
    public int DocvehiId { get; set; }

    public int VehiId { get; set; }

    public int ProviId { get; set; }

    public string? DocvehivDescripcion { get; set; }

    public DateTime DocvehidFechaReg { get; set; }

    public string? DocvehivRuta { get; set; }

    public string? DocIdDocumentoStorage { get; set; }

    public virtual GestorProveedor Provi { get; set; } = null!;

    public virtual GestorVehiculos Vehi { get; set; } = null!;
}
