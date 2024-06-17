using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class ClientModel
	{
		public int ID_Cliente { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Username { get; set; }
		public string Direccion { get; set; }
		public int Tipo_Documento { get; set; }
		public string Numero_Documento { get; set; }
		public string Ciudad { get; set; }
		public bool Estado { get; set; }
		public string Codigo_Postal { get; set; }
		public string Telefono { get; set; }
		public string Correo_Electronico { get; set; }
		public string Contrasenia { get; set; }
		public DateTime Fecha_Nacimiento { get; set; }
		public string Sexo { get; set; }

	}
}
