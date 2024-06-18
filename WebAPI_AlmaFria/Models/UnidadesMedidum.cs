using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class UnidadesMedidum
{
    public int IdUnidadMedida { get; set; }

    public string NombreUnidad { get; set; } = null!;

    public string Simbolo { get; set; } = null!;

    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
