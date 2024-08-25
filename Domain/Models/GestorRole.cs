using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorRole
{
    public int RoliId { get; set; }

    public string? RolvNombre { get; set; }

    public virtual ICollection<GestorUsuario> GestorUsuarios { get; set; } = new List<GestorUsuario>();
}
