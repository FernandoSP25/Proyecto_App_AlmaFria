using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_App_AlmaFria.Utilities
{
    public class DocumentOption
    {

		public int Key { get; set; }
		public string Value { get; set; }

		public DocumentOption(int key, string value)
		{
			Key = key;
			Value = value;
		}
		public override string ToString()
		{
			return Value; 
		}
	}
}
