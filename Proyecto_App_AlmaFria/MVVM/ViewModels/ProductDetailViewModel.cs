using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_App_AlmaFria.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
	public class ProductDetailViewModel : ObservableObject
	{
		private ProductModel _product;
		public ProductModel Product
		{
			get => _product;
			set => SetProperty(ref _product, value);
		}


		public ICommand VolverCommand { get; }

		public ProductDetailViewModel(ProductModel product)
		{
			Product = product;
			VolverCommand = new AsyncRelayCommand(Volver);
		}

		private async Task Volver()
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}

}
