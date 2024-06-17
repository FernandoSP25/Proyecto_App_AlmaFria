using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Colaboradore> Colaboradores { get; set; } = new List<Colaboradore>();
}
