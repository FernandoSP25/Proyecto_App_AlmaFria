
namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class ClientModel
	{
		public int IdCliente { get; set; }

		public string Nombre { get; set; } = null!;

		public string Apellido { get; set; } = null!;

		public string Username { get; set; } = null!;

		public string? Direccion { get; set; }

		public int TipoDocumento { get; set; }

		public string NumeroDocumento { get; set; } = null!;

		public string? Ciudad { get; set; }

		public bool Estado { get; set; }

		public string? CodigoPostal { get; set; }

		public string? Telefono { get; set; }

		public string CorreoElectronico { get; set; } = null!;

		public string Contrasenia { get; set; } = null!;

		public DateOnly FechaNacimiento { get; set; }

		public string Sexo { get; set; } = null!;

		//public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

		//public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

		//public virtual TipoDocumento TipoDocumentoNavigation { get; set; } = null!;

	}
}
