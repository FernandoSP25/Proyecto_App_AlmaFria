using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class DetalleIngrediente
{
    public int IdDetallesIngredientes { get; set; }

    public int IdDetallePreparacion { get; set; }

    public int? IdInsumo { get; set; }

    public int? Cantidad { get; set; }

    public string? Detalles { get; set; }

    public virtual DetallePreparacion IdDetallePreparacionNavigation { get; set; } = null!;

    public virtual Insumo? IdInsumoNavigation { get; set; }
}
