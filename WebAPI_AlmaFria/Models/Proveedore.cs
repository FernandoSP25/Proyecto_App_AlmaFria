using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<ComprarInsumo> ComprarInsumos { get; set; } = new List<ComprarInsumo>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
