using System;
using WPF_ELE132_Oblig2.Model;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class ViewModelLogin : ViewModelBase
	{
		private string _username, 
					   _password;

		public event EventHandler<LoginEventArgs> LoadNewView;
		public event EventHandler<ErrorEventArgs> InvalidLogin;

		public ViewModelLogin()
		{
			// Pretend to be fetching list of users from a database
			Users = new UserList(new User("admin", "fotball", true),
					new User("randomdude", false),
					new User("test", false));
			
			AttemptLogin = new Command(login, () => !(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)));
		}

		public Command AttemptLogin { get; private set; }

		public UserList Users { get; protected set; }

		public string Username
		{
			get { return _username; }
			set
			{
				_username = value;
				AttemptLogin.OnCanExecuteChanged();
			}
		}

		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value;
				AttemptLogin.OnCanExecuteChanged();
			}
		}

		private void login()
		{
			User user = checkCredentials();

			if (user == null)
				InvalidLogin(this, new ErrorEventArgs("Either the username does not exist, or the password does not match the username."));
			else
				LoadNewView(this, new LoginEventArgs(Users, user));

		}

		// Returns a user object if it exists, otherwise returns null
		private User checkCredentials()
		{
			if (Users[Username] != null)
			{
				User user = Users[Username];

				if (user.IsPasswordMatch(this.Password))
					return user;
			}
			return null;
		}
	}
}
