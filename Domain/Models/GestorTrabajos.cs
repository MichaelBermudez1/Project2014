using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorTrabajos
{
    public int TrabiId { get; set; }

    public int ProviId { get; set; }

    public string TrabvDescripcion { get; set; } = null!;

    public DateOnly TrabdFechaInicio { get; set; }

    public DateOnly? TrabdFechaFin { get; set; }

    public string TrabvEstado { get; set; } = null!;

    public virtual ICollection<GestorDocTrabajos> GestorDocTrabajos { get; set; } = new List<GestorDocTrabajos>();

    public virtual GestorProveedor Provi { get; set; } = null!;
}
