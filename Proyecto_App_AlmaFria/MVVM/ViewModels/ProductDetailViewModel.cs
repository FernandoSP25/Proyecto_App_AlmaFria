using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Proyecto_App_AlmaFria.MVVM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
    public class ProductDetailViewModel : ObservableObject
    {
        public ICommand AgregarCommand { get; }
        private ProductModel _product;
        private List<ProductModel> _listaCarrito;

        public ProductModel Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public ProductDetailViewModel(ProductModel product)
        {
            Product = product;
            _listaCarrito = CargarCarrito();
            AgregarCommand = new AsyncRelayCommand(Agregar);
        }

        private List<ProductModel> CargarCarrito()
        {
            if (Preferences.Get("carrito", "") == "")
            {
                return new List<ProductModel>();
            }
            else
            {
                string valor = Preferences.Get("carrito", "");
                return JsonConvert.DeserializeObject<List<ProductModel>>(valor);
            }
        }

        private async Task Agregar()
        {
            
     
                int id = Product.IdProductos;
                if(_listaCarrito.Where(p=>p.IdProductos==id).Count()>0) 
                {
					await App.Current.MainPage.DisplayAlert("ADVERTENCIA", $"El producto {Product.NombreProducto} ya fue agregado.", "OK");

					//System.Diagnostics.Debug.WriteLine($"El producto {Product.NombreProducto} ya fue agregado.");
                    return;
                }

                _listaCarrito.Add(Product);
                Preferences.Set("carrito", JsonConvert.SerializeObject(_listaCarrito));
			    await App.Current.MainPage.DisplayAlert("AGREGADO", $"El producto {Product.NombreProducto} ha sido agregado agregado.", "OK");

			//PA VER SI SE GUARDAN JIJI <3
			//System.Diagnostics.Debug.WriteLine($"Producto {Product.NombreProducto} agregado.");
			//System.Diagnostics.Debug.WriteLine($"Lista actual: {string.Join(", ", _listaCarrito.Select(p => p.NombreProducto))}");

		}
    }
}
