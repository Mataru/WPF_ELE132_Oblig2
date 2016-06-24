using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ELE132_Oblig2.Model;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class LoginEventArgs : EventArgs
	{
		public LoginEventArgs(UserList allUsers, User currentUser)
		{
			this.AllUsers = allUsers;
			this.CurrentUser = currentUser;
		}

		public UserList AllUsers { get; private set; }
		public User CurrentUser { get; private set; }
	}
}
