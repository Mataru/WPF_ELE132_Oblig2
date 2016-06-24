using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ELE132_Oblig2.Model;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class PasswordChangeAttemptedArgs : EventArgs
	{
		public PasswordChangeAttemptedArgs(bool changeSuccessful)
		{
			this.ChangeSuccessful = changeSuccessful;
		}

		public bool ChangeSuccessful { get; private set; }
	}
}
