using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Detalles { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
