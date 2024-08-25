using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorUsuariosAcceso
{
    public int UsuaacciId { get; set; }

    public int? UsuaiId { get; set; }

    public int? AcciId { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public virtual GestorAcceso? Acci { get; set; }

    public virtual GestorUsuario? Usuai { get; set; }
}
