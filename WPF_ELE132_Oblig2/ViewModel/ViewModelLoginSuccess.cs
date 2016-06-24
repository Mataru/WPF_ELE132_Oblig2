using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class ViewModelLoginSuccess : ViewModelBase
	{
		public event EventHandler CloseView;

		public ViewModelLoginSuccess(EventArgs e)
		{
			this.Username = (e as LoginEventArgs).CurrentUser.Username;
			this.Logout = new Command(close, () => true);
		}

		public Command Logout { get; private set; }

		public string Username { get; private set; }

		private void close()
		{
			CloseView(this, EventArgs.Empty);
		}
	}
}
