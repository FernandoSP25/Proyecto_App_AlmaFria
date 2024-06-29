using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Boletum
{
    public int IdBoleta { get; set; }

    public int IdPedido { get; set; }

    public string Dni { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public string Hora { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string NumeroCorrelativo { get; set; } = null!;

    public int Igv { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Total { get; set; }

    public string? BoletaEstado { get; set; }

    public string? DocumentId { get; set; }

    public string? Xml { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
