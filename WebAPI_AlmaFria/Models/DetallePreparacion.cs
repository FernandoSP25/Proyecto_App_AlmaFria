using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class DetallePreparacion
{
    public int IdDetallePreparacion { get; set; }

    public int IdProducto { get; set; }

    public int? TiempoDuracion { get; set; }

    public string? Detalles { get; set; }

    public virtual ICollection<DetalleIngrediente> DetalleIngredientes { get; set; } = new List<DetalleIngrediente>();

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
