using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
    public class CategoriaModel
    {
		public int IdCategoria { get; set; }

		public string Nombre { get; set; } = null!;

		public string? Imageurlc { get; set; }

	}
}
