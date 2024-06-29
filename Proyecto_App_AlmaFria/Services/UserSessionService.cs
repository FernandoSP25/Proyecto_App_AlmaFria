using Proyecto_App_AlmaFria.MVVM.Models;


namespace Proyecto_App_AlmaFria.Services
{
	public class UserSessionService
	{

		private const string UserIdKey = "UserId";
		private const string UserNameKey = "UserName";
		private const string UserApellidoKey = "UserApellido";
		private const string UserCorreoElectronicoKey = "UserCorreoElectronico";
		// Añadir más claves según sea necesario

		private ClientModel _currentUser;

		public ClientModel CurrentUser
		{
			get => _currentUser;
			set
			{
				_currentUser = value;
				if (value != null)
				{
					Preferences.Set(UserIdKey, value.IdCliente);
					Preferences.Set(UserNameKey, value.Nombre);
					Preferences.Set(UserApellidoKey, value.Apellido);
					Preferences.Set(UserCorreoElectronicoKey, value.CorreoElectronico);
					// Añadir más valores según sea necesario
				}
				else
				{
					Preferences.Remove(UserIdKey);
					Preferences.Remove(UserNameKey);
					Preferences.Remove(UserApellidoKey);
					Preferences.Remove(UserCorreoElectronicoKey);
					// Remover más claves según sea necesario
				}
			}
		}

		public bool IsUserLoggedIn => Preferences.ContainsKey(UserIdKey);

		public void ClearSession()
		{
			_currentUser = null;
			Preferences.Remove(UserIdKey);
			Preferences.Remove(UserNameKey);
			Preferences.Remove(UserApellidoKey);
			Preferences.Remove(UserCorreoElectronicoKey);
			// Remover más claves según sea necesario
		}

		public void LoadUserFromPreferences()
		{
			if (IsUserLoggedIn)
			{
				_currentUser = new ClientModel
				{
					IdCliente = Preferences.Get(UserIdKey, 0),
					Nombre = Preferences.Get(UserNameKey, string.Empty),
					Apellido = Preferences.Get(UserApellidoKey, string.Empty),
					CorreoElectronico = Preferences.Get(UserCorreoElectronicoKey, string.Empty),
					// Cargar más propiedades según sea necesario
				};
			}
		}
	}
}
