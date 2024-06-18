using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class MetodosPago
{
    public int IdMetodosPago { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
