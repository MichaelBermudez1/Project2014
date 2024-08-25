using System;
using System.Collections.Generic;
namespace Domain.Models;

public partial class GestorProveedor
{
    public int ProviId { get; set; }

    public string ProvvNombre { get; set; } = null!;

    public int? UsuaiId { get; set; }

    public int? ProvnCodigo { get; set; }

    public int? ProvnRuc { get; set; }

    public DateOnly? ProvdFechaRegistro { get; set; }

    public string? ProvvRazonSocial { get; set; }

    public string? ProvvActividadEcon { get; set; }

    public string? ProvvDireccion { get; set; }

    public string? ProvvPais { get; set; }

    public string? ProvvProvincia { get; set; }

    public string? ProvvDepartamento { get; set; }

    public string? ProvvDistrito { get; set; }

    public string? ProvvReferencia { get; set; }

    public string? ProvvNombreResp { get; set; }

    public string? ProvvApellidoMatResp { get; set; }

    public string? ProvvApellidoPatResp { get; set; }

    public int? ProvnTelefonoResp { get; set; }

    public string? ProvvCorreoResp { get; set; }

    public virtual ICollection<GestorColaboradores> GestorColaboradores { get; set; } = new List<GestorColaboradores>();

    public virtual ICollection<GestorDocColaboradores> GestorDocColaboradors { get; set; } = new List<GestorDocColaboradores>();

    public virtual ICollection<GestorDocProveedor> GestorDocProveedors { get; set; } = new List<GestorDocProveedor>();

    public virtual ICollection<GestorDocTrabajos> GestorDocTrabajos { get; set; } = new List<GestorDocTrabajos>();

    public virtual ICollection<GestorDocVehiculos> GestorDocVehiculos { get; set; } = new List<GestorDocVehiculos>();

    public virtual ICollection<GestorTrabajos> GestorTrabajos { get; set; } = new List<GestorTrabajos>();

    public virtual ICollection<GestorVehiculos> GestorVehiculos { get; set; } = new List<GestorVehiculos>();

    public virtual GestorUsuario? Usuai { get; set; }
}
