using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public partial class CreateAccountViewModel: ObservableObject
	{
		[ObservableProperty]
		private string nombre;

		[ObservableProperty]
		private string apellido;

		[ObservableProperty]
		private string username;

		[ObservableProperty]
		private string correoElectronico;

		[ObservableProperty]
		private string contrasenia;

		[ObservableProperty]
		private string confirmContrasenia;

		[ObservableProperty]
		private string fechaNacimiento;

		[ObservableProperty]
		private string sexo;

		[ObservableProperty]
		private string direccion;

		[ObservableProperty]
		private string tipoDocumento;

		[ObservableProperty]
		private string numeroDocumento;

		[ObservableProperty]
		private string ciudad;

		[ObservableProperty]
		private string codigoPostal;

		[ObservableProperty]
		private string telefono;

		[ObservableProperty]
		private string maximumDate;

		public ObservableCollection<string> SexOptions { get; } = new ObservableCollection<string>
		{
			"Masculino",
			"Femenino",
			"Otro"
		};


		public ObservableCollection<string> DocumentOptions { get; } = new ObservableCollection<string>
		{
			"DNI",
			"CARNET EXT.",
			"Otro"
		};

		public ICommand CreateAccountCommand { get; }

		public CreateAccountViewModel()
		{
			CreateAccountCommand = new AsyncRelayCommand(CreateAccountAsync);
			MaximumDate = DateTime.Now.AddYears(-18).ToString("MM/dd/yyyy");
			FechaNacimiento = DateTime.Now.ToString("dd/MM/yyyy");
		}




		[RelayCommand]
		async Task Salir() => await Shell.Current.GoToAsync("//LoginPage");


		private async Task CreateAccountAsync()
		{
			// Valida los campos necesarios
			if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) || string.IsNullOrWhiteSpace(Username) ||
				string.IsNullOrWhiteSpace(CorreoElectronico) || string.IsNullOrWhiteSpace(Contrasenia) || string.IsNullOrWhiteSpace(ConfirmContrasenia))
			{
				// Mostrar un mensaje de error o notificar al usuario
				return;
			}

			if (Contrasenia != ConfirmContrasenia)
			{
				// Mostrar un mensaje de error o notificar al usuario
				return;
			}

			// Aquí iría la lógica para crear la cuenta en tu base de datos

			// Simulación de un proceso exitoso
			await Shell.Current.GoToAsync("//LoginPage");
		}

	}
}
