using System;
using System.Collections.Generic;

namespace Domain.Models;
public partial class GestorColaboradores
{
    public int ColaiId { get; set; }

    public int ProviId { get; set; }

    public string ColavNombres { get; set; } = null!;

    public string ColavApellidoPat { get; set; } = null!;

    public string ColavApellidoMat { get; set; } = null!;

    public string ColavDireccion { get; set; } = null!;

    public string ColavTipoDoc { get; set; } = null!;

    public int ColaiNumeroDoc { get; set; }

    public string ColavNacionalidad { get; set; } = null!;

    public string ColavPuestoTrabajo { get; set; } = null!;

    public string? ColavSexo { get; set; }

    public bool ColaiEstadoTrab { get; set; }

    public virtual ICollection<GestorDocColaboradores> GestorDocColaboradores { get; set; } = new List<GestorDocColaboradores>();

    public virtual GestorProveedor Provi { get; set; } = null!;
}
