using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace Proyecto_App_AlmaFria.MVVM.ViewModels
{
    public partial class AccountViewModel : ObservableObject
    {
        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        public ICommand EditarCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ToggleThemeCommand { get; }

        public AccountViewModel()
        {
            // Cargar los datos desde Preferences
            LoadUserData();

            // Inicializar comandos
            EditarCommand = new RelayCommand(OnEditar);
            SaveCommand = new RelayCommand(OnSave);
            LogoutCommand = new RelayCommand(OnLogout);
            // Inicializar el estado del tema
        }

        private async void LoadUserData()
        {
            Name = Preferences.Get("UserName", string.Empty);
            Email = Preferences.Get("UserCorreoElectronico", string.Empty);
            Password = await SecureStorage.GetAsync("UserPassword"); // Recuperar la contraseña de forma segura
        }

        private void OnEditar()
        {
            // Lógica para habilitar la edición de los campos (si es necesario)
        }

        private async void OnSave()
        {
            // Guardar los datos editados en Preferences
            Preferences.Set("UserName", Name);
            Preferences.Set("UserCorreoElectronico", Email);
            await SecureStorage.SetAsync("UserPassword", Password); // Almacenar la contraseña de forma segura

            // Mostrar mensaje de éxito
            await App.Current.MainPage.DisplayAlert("Success", "Account details saved successfully.", "OK");
        }

        private async void OnLogout()
        {
            // Limpiar los datos de Preferences y navegar a la página de inicio de sesión
            Preferences.Clear();
            //await Shell.Current.GoToAsync("//LoginPage");
            App.Current.MainPage = new AppShell();
        }
    }
}
