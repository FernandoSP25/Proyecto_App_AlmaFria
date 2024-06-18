using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Pedido
{
    public int IdPedidos { get; set; }

    public int Cliente { get; set; }

    public int Vendedor { get; set; }

    public int MetodoPago { get; set; }

    public DateTime FechaHora { get; set; }

    public string EstatusPedido { get; set; } = null!;

    public virtual ICollection<Boletum> Boleta { get; set; } = new List<Boletum>();

    public virtual Cliente ClienteNavigation { get; set; } = null!;

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual MetodosPago MetodoPagoNavigation { get; set; } = null!;

    public virtual Colaboradore VendedorNavigation { get; set; } = null!;
}
