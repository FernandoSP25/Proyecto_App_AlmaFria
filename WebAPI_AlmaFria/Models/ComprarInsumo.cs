using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class ComprarInsumo
{
    public int IdCompraInsumos { get; set; }

    public int IdProveedor { get; set; }

    public int IdInsumo { get; set; }

    public DateOnly Fecha { get; set; }

    public string Hora { get; set; } = null!;

    public int Cantidad { get; set; }

    public string Estatus { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}
