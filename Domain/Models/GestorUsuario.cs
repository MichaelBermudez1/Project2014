using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class GestorUsuario
{
    public int UsuaiId { get; set; }

    public int? GruiId { get; set; }

    public int? RoliId { get; set; }

    public string? UsuavNom { get; set; }

    public string? UsuavPass { get; set; }

    public string? UsuavNombre { get; set; }

    public string? UsuavApellido { get; set; }

    public string? UsuavEmail { get; set; }

    //public string? userName { get; set; }

    public virtual ICollection<GestorProveedor> GestorProveedors { get; set; } = new List<GestorProveedor>();

    public virtual ICollection<GestorUsuariosAcceso> GestorUsuariosAccesos { get; set; } = new List<GestorUsuariosAcceso>();

    public virtual GestorGrupoUsuario? Grui { get; set; }

    public virtual GestorRole? Roli { get; set; }
}
