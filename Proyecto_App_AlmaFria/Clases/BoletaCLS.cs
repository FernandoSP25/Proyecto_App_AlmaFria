using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.Clases
{
	public class BoletaCLS
	{
		public int ID_Boleta { get; set; }

		public int ID_Pedido { get; set; }

		public string DNI { get; set; }

		public string Nombre { get; set; }

		public string Hora { get; set; }

		public string Serie { get; set; }

		public string NumeroCorrelativo { get; set; }

		public string Status { get; set; }
		public string DocumentId { get; set; }
		public string Xml { get; set; }

		public int IGV { get; set; }

		public float SubTotal { get; set; }

		public float Total { get; set; }

	}
}
