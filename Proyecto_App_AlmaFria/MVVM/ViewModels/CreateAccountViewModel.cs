using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using Proyecto_App_AlmaFria.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
		private DateTime fechaNacimiento;

		[ObservableProperty]
		private string sexo;

		[ObservableProperty]
		private string direccion;

		[ObservableProperty]
		private string tipoDocumento;
		[ObservableProperty]
		private DocumentOption selectedTipoDocumento;

		[ObservableProperty]
		private string numeroDocumento;

		[ObservableProperty]
		private string telefono;

		[ObservableProperty]
		private DateTime maximumDate;

		public ObservableCollection<string> SexOptions { get; } = new ObservableCollection<string>
		{
			"Masculino",
			"Femenino",
			"Otro"
		};


		public ObservableCollection<DocumentOption> DocumentOptions { get; } = new ObservableCollection<DocumentOption>
		{
			new DocumentOption(1, "DNI"),
			new DocumentOption(2, "CARNET EXT."),
			new DocumentOption(3, "Otro")
		};

		public ICommand CreateAccountCommand { get; }

		public CreateAccountViewModel()
		{
			CreateAccountCommand = new AsyncRelayCommand(CreateAccountAsync);
			MaximumDate = DateTime.Now.AddYears(-18);
		}
		private bool IsValidDNI(string dni)
		{
			return Regex.IsMatch(dni, @"^\d{8}$");
		}

		private bool IsValidPhoneNumber(string phoneNumber)
		{
			return Regex.IsMatch(phoneNumber, @"^9\d{8}$");
		}
		private bool IsPasswordStrong(string password)
		{
			if (password.Length < 8) return false; // Al menos 8 caracteres
			if (!Regex.IsMatch(password, @"[A-Z]")) return false; // Al menos una letra mayúscula
			if (!Regex.IsMatch(password, @"[a-z]")) return false; // Al menos una letra minúscula
			if (!Regex.IsMatch(password, @"[0-9]")) return false; // Al menos un número
			if (!Regex.IsMatch(password, @"[\W_]")) return false; // Al menos un carácter especial

			return true;
		}
		private async Task<bool> ValidateInputs()
		{
			if (string.IsNullOrWhiteSpace(Nombre))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Nombre es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(Apellido))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Apellido es obligatorio.", "OK");
				return false;
			}
			if (FechaNacimiento == default(DateTime))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Fecha de Nacimiento es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(Sexo))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Sexo es obligatorio.", "OK");
				return false;
			}

			if (SelectedTipoDocumento == null)
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Tipo de Documento es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(NumeroDocumento) || !IsValidDNI(NumeroDocumento))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Número de Documento es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(Telefono) || !IsValidPhoneNumber(Telefono))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Telefono es obligatorio.", "OK");
				return false;
			}

			if (string.IsNullOrWhiteSpace(Username))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Username es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(CorreoElectronico))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Correo Electrónico es obligatorio.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(Contrasenia))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Contraseña es obligatorio.", "OK");
				return false;
			}
			if (!IsPasswordStrong(Contrasenia))
			{
				await App.Current.MainPage.DisplayAlert("Error", "La contraseña debe tener al menos 8 caracteres, incluyendo una letra mayúscula, una letra minúscula, un número y un carácter especial.", "OK");
				return false;
			}
			if (string.IsNullOrWhiteSpace(ConfirmContrasenia))
			{
				await App.Current.MainPage.DisplayAlert("Error", "El campo Confirmar Contraseña es obligatorio.", "OK");
				return false;
			}
			if (Contrasenia != ConfirmContrasenia)
			{
				await App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
				return false;
			}

			return true;
		}



		private async Task CreateAccountAsync()
		{
			if (!await ValidateInputs())
				return;

			var newUser = new ClientModel
			{
				Nombre = Nombre,
				Apellido = Apellido,
				Username = Username,
				CorreoElectronico = CorreoElectronico,
				Contrasenia = Contrasenia,
				FechaNacimiento = new DateOnly(FechaNacimiento.Year, FechaNacimiento.Month, FechaNacimiento.Day),
				Sexo = Sexo,
				Direccion = Direccion,
				TipoDocumento = SelectedTipoDocumento.Key,
				NumeroDocumento = NumeroDocumento,
				Telefono = Telefono,
				Estado = true
			};
			var json = JsonConvert.SerializeObject(newUser);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			try
			{
				var response = await Http.Post("https://almafriaproyect.azurewebsites.net/api/auth/register", content);

				if (response >0)
				{
					await App.Current.MainPage.DisplayAlert("Success", "Account created successfully.", "OK");
					await Shell.Current.GoToAsync("//LoginPage");
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Error", $"Failed to create account", "OK");
				}
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
			}
		}

		[RelayCommand]
		async Task Salir() => await Shell.Current.GoToAsync("//LoginPage");


	}
}
