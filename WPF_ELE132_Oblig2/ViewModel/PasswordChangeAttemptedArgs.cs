using System;

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
