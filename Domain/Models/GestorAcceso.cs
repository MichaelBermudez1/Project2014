using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorAcceso
{
    public int AcciId { get; set; }

    public string? AccvNombre { get; set; }

    public virtual ICollection<GestorUsuariosAcceso> GestorUsuariosAccesos { get; set; } = new List<GestorUsuariosAcceso>();
}
