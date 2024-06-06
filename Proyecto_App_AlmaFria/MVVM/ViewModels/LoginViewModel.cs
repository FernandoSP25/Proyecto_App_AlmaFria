using Proyecto_App_AlmaFria.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System.Windows.Input;
using Proyecto_App_AlmaFria.Views;
using Proyecto_App_AlmaFria.Services;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{

		public UsuarioModel usuario { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		private readonly INavigationService _navigationService;

		public LoginViewModel()
		{ 
			usuario = new UsuarioModel
			{
				email = "MVVM",
				password = "123"
			};
		}

		public ICommand btnLogin_Clicked =>
			new Command(() =>
			Application.Current.MainPage = new AppShell());

		public ICommand btnCreateAccount_Clicked =>
			new Command(async () => await _navigationService.NavigateToCreateAccountPage());
	}
}
