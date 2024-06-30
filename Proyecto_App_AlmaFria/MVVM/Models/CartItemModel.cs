using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class CartItem 
	{
		public int ID { get; set; }

		public string Nombre { get; set; } = null!;

		public decimal Precio { get; set; }

		public int StockActual { get; set; }

		public string? Imageurl { get; set; }

		public int Cantidad { get; set; }

	}
}
