using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string NombreInsumo { get; set; } = null!;

    public int UnidadMedida { get; set; }

    public decimal PrecioCosto { get; set; }

    public int StockActual { get; set; }

    public int StockMinimo { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<ComprarInsumo> ComprarInsumos { get; set; } = new List<ComprarInsumo>();

    public virtual ICollection<DetalleIngrediente> DetalleIngredientes { get; set; } = new List<DetalleIngrediente>();

    public virtual UnidadesMedidum UnidadMedidaNavigation { get; set; } = null!;
}
