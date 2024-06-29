using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.Generic;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Input;
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


		public ICommand SigninCommand { get; }
		public ICommand SignupCommand { get; }



		public LoginViewModel()
		{
			SigninCommand = new AsyncRelayCommand(Login);
			SignupCommand = new AsyncRelayCommand(Signup);
		}


		private async Task Login()
		{
			//if (!IsValidEmail(Email))
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
			//		await Shell.Current.GoToAsync("//MenuPage");
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

			await Shell.Current.GoToAsync("//MenuPage");

		}

		private async Task Signup()
		{
			await Shell.Current.GoToAsync("//CreateAccountPage");
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
		public  bool IsValidEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			try
			{
				// Normalize the domain
				email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
									  RegexOptions.None, TimeSpan.FromMilliseconds(200));

				// Examines the domain part of the email and normalizes it.
				string DomainMapper(Match match)
				{
					// Use IdnMapping class to convert Unicode domain names.
					var idn = new IdnMapping();

					// Pull out and process domain name (throws ArgumentException on invalid)
					string domainName = idn.GetAscii(match.Groups[2].Value);

					return match.Groups[1].Value + domainName;
				}
			}
			catch (RegexMatchTimeoutException e)
			{
				return false;
			}
			catch (ArgumentException e)
			{
				return false;
			}

			try
			{
				return Regex.IsMatch(email,
					@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
					RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
			}
			catch (RegexMatchTimeoutException)
			{
				return false;
			}
		}


	}
}
