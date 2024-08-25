using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class GestorGrupoUsuario
{
    public int GruiId { get; set; }

    public string? GruvNombre { get; set; }

    public virtual ICollection<GestorUsuario> GestorUsuarios { get; set; } = new List<GestorUsuario>();
}
