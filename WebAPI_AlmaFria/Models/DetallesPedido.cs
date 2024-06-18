using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class DetallesPedido
{
    public int IdDetallesPedidos { get; set; }

    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public string Observaciones { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
