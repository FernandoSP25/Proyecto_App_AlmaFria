using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Windows.Input;
using Proyecto_App_AlmaFria.Services;
using Proyecto_App_AlmaFria.Utilities;
using Proyecto_App_AlmaFria.Views;
using Newtonsoft.Json;



#if ANDROID
using Android.App;
using Android.Net.Wifi;
using System.Net;
#endif


namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{

	public partial class LoginViewModel : ObservableObject
	{


		[ObservableProperty]
		private string email;

		[ObservableProperty]
		private string password;

		[ObservableProperty]
		private string errorMessage;

		[ObservableProperty]
		private bool isErrorVisible;

		private ClientModel _client;


		public ICommand SigninCommand { get; }
		public ICommand SignupCommand { get; }



		public LoginViewModel()
		{
			SigninCommand = new AsyncRelayCommand(Login);
			SignupCommand = new AsyncRelayCommand(Signup);
		}


		private async Task Login()
		{
			//if (!ValidEmail.IsValidEmail(Email))

			//{
			//	ErrorMessage = "Please enter a valid email address.";
			//	IsErrorVisible = true;
			//	return;
			//}
			//IsErrorVisible = false;

			//string _email = Email;
			//string _password = Password;
			//var response = await Http.Get<ClientModel>("https://almafriaproyect.azurewebsites.net/api/auth/login?email=" + _email + "&password=" + _password);

			//if (response != null)
			//{
			//	var status = await Permissions.RequestAsync<Permissions.NetworkState>();
			//	if (status != PermissionStatus.Granted)
			//	{
			//		ErrorMessage = "Permission to access network state is denied.";
			//		return;
			//	}
			//	// Crear el registro de inicio de sesión
			//	var loginRecord = new LoginModel
			//	{
			//		UserId = response.IdCliente,
			//		SessionToken = GenerateSessionToken(),
			//		LoginTimestamp = DateTime.Now,
			//		IsConnected = true,
			//		Ipaddress = GetDeviceIpAddress(),
			//		DeviceInfo = GetDeviceInfo()
			//	};

			//	var result = await Http.Post("https://almafriaproyect.azurewebsites.net/api/auth/loginrecord", loginRecord);

			//	if (result > 0)
			//	{
			//		// Manejar el éxito del inicio de sesión
			//		_client = response;
			//		Preferences.Set("usuario", JsonConvert.SerializeObject(_client));
			//		App.Current.MainPage = new MenuPage();
			//	}
			//	else if (result == -1)
			//	{
			//		ErrorMessage = "User already logged in on another device.";
			//	}
			//	else
			//	{
			//		ErrorMessage = "Failed to log the session. Please try again.";
			//	}
			//}
			//else
			//{
			//	// Manejar error de autenticación
			//	ErrorMessage = "Invalid credentials. Please try again.";
			//}

			App.Current.MainPage = new MenuPage();


		}

		private async Task Signup()
		{
			await Shell.Current.GoToAsync("CreateAccountPage");
		}

		private string GenerateSessionToken()
		{
			return Guid.NewGuid().ToString();
		}

		private string GetDeviceIpAddress()
		{
			string result = "Unknown";
#if ANDROID
            WifiManager wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Service.WifiService);
            int ipaddress = wifiManager.ConnectionInfo.IpAddress;
            IPAddress ipAddr = new IPAddress(ipaddress);
            result = ipAddr.ToString();
#endif
			return result;
		}

		private string GetDeviceInfo()
		{
			var deviceInfo = $"Model: {DeviceInfo.Model}, Manufacturer: {DeviceInfo.Manufacturer}, Name: {DeviceInfo.Name}, OS: {DeviceInfo.VersionString}";
			return deviceInfo;
		}

	}
}
