using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public partial class CreateAccountViewModel: ObservableObject
	{
		public CreateAccountViewModel()
		{
		}

		[RelayCommand]
		async Task Salir() => await Shell.Current.GoToAsync("//LoginPage");
		[RelayCommand]
		async Task CreateAccount() => await Shell.Current.GoToAsync("//MenuPage");

	}
}
