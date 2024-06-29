using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Colaboradore
{
    public int IdColaborador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int TipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public int Cargo { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public bool Estado { get; set; }

    public string? Observaciones { get; set; }

    public string? ImagenPerfil { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual TipoDocumento TipoDocumentoNavigation { get; set; } = null!;
}
