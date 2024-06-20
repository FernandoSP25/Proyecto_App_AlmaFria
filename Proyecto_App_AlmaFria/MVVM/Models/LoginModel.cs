using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.MVVM.Models
{
	public class LoginModel
	{
		public int LoginId { get; set; }

		public int UserId { get; set; }

		public DateTime LoginTimestamp { get; set; } 

		public DateTime? LogoutTimestamp { get; set; }

		public bool IsConnected { get; set; }

		public string SessionToken { get; set; } = null!;

		public string Ipaddress { get; set; } = null!;

		public string? DeviceInfo { get; set; }

		//public virtual Cliente User { get; set; } = null!;
	}
}
