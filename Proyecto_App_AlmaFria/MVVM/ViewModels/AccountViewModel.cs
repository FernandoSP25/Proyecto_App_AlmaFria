using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string apellido;

        [ObservableProperty]
        private string telefono;

		[ObservableProperty]
		private string direccion;

		[ObservableProperty]
		private string imagePerfil;

		[ObservableProperty]
		private string email;

		[ObservableProperty]
		private string username;

        public ICommand LogoutCommand { get; }

        public AccountViewModel()
        {
            // Cargar los datos desde Preferences
			_= ObtenerCliente();
            // Inicializar comandos
            LogoutCommand = new AsyncRelayCommand (OnLogout);
            // Inicializar el estado del tema
        }


		private async Task ObtenerCliente()
		{
			string valor = Preferences.Get("usuario", "");
			ClientModel usuario = JsonConvert.DeserializeObject<ClientModel>(valor);

			ImagePerfil = usuario.ImagenPerfil;
			Username = usuario.Username;
			Email = usuario.CorreoElectronico;
		    Nombre = usuario.Nombre;
			Apellido = usuario.Apellido;
			Telefono = usuario.Telefono;
			if(usuario.Direccion != null)
			{
				Direccion = usuario.Direccion;
			}
			else
			{
				Direccion = "No address";
			}
			
		}

		private async Task OnLogout()
		{
			string valor = Preferences.Get("usuario", "");
			ClientModel user = JsonConvert.DeserializeObject<ClientModel>(valor);

			string url = $"https://almafriaproyect.azurewebsites.net/api/auth/logout?id={user.IdCliente}";
			int resultado = await Http.Put(url);

			if (resultado > 0)
			{
				await App.Current.MainPage.DisplayAlert("Success", "You have been logged out successfully.", "OK");
			}
			else
			{
				await App.Current.MainPage.DisplayAlert("Error", "An error occurred while logging out.", "OK");
			}
			// Limpiar los datos de Preferences y navegar a la página de inicio de sesión
			Preferences.Clear();
			//await Shell.Current.GoToAsync("//LoginPage");
			App.Current.MainPage = new AppShell();
		}

	}

}
