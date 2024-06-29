using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdPedidos { get; set; }

    public string RucEmisor { get; set; } = null!;

    public string RazonSocialEmisor { get; set; } = null!;

    public string DireccionFiscalEmisor { get; set; } = null!;

    public string RucReceptor { get; set; } = null!;

    public string RazonSocialReceptor { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public string NumeroCorrelativo { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public string Hora { get; set; } = null!;

    public int Igv { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Total { get; set; }

    public string? FacturaEstado { get; set; }

    public string? DocumentId { get; set; }

    public string? Xml { get; set; }

    public virtual Pedido IdPedidosNavigation { get; set; } = null!;
}
