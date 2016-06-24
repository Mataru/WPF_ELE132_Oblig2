using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class ErrorEventArgs : EventArgs
	{
		public ErrorEventArgs(string message)
		{
			this.ErrorMessage = message;
		}

		public string ErrorMessage { get; private set; }
	}
}
