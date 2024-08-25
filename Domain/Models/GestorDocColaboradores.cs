using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class GestorDocColaboradores
{
    public int DoccolaiId { get; set; }

    public int? ColaiId { get; set; }

    public int? ProviId { get; set; }

    public string? DoccolavDescripcion { get; set; }

    public DateTime DoccoladFechaReg { get; set; }

    public string? DoccolavRuta { get; set; }

    public string? DocIdDocumentoStorage { get; set; }

    public virtual GestorColaboradores? Colai { get; set; }

    public virtual GestorProveedor? Provi { get; set; }
}
