using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class GestorDocProveedor
{
    public int DocproviId { get; set; }

    public int ProviId { get; set; }

    public string? DocprovvDescripcion { get; set; }

    public DateTime DocprovdFechaReg { get; set; }

    public string? DocprovvRuta { get; set; }

    public virtual GestorProveedor Provi { get; set; } = null!;
}
