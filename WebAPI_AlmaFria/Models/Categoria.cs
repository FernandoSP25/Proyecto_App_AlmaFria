using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Imageurlc { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
