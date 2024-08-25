using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorDocTrabajos
{
    public int DoctrabiId { get; set; }

    public int? TrabiId { get; set; }

    public int? ProviId { get; set; }

    public string? DoctrabvDescripcion { get; set; }

    public DateOnly? DoctrabdFechaReg { get; set; }

    public string? DoctrabvRuta { get; set; }

    public virtual GestorProveedor? Provi { get; set; }

    public virtual GestorTrabajos? Trabi { get; set; }
}
