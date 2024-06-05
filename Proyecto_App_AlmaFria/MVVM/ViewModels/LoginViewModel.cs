using Proyecto_App_AlmaFria.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{

		public UsuarioModel usuario { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;

		public LoginViewModel()
		{ 
			usuario = new UsuarioModel
			{
				email = "MVVM",
				password = "123"
			};
		}

		public void btnLoginClick()
		{
			Application.Current.MainPage = new AppShell();
		}


		public void btnCrearCuenta()
		{

		}
	}
}
