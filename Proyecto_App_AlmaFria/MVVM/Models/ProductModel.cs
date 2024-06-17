using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class ProductModel
	{
		public int Id { get; set; }
		public string ProductName { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string Image { get; set; }
	}
}
