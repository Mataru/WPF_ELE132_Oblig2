using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF_ELE132_Oblig2.Model
{
	public class User : INotifyPropertyChanged
	{
		#region Fields
		private const string defaultPassword = "password1";
		private const int passwordValidityLength = 6;

		private string username,
					   password;
		private bool isAdmin;
		private DateTime passwordExpirationDate;

		// Event that fires when onPropertyChanged method is called
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Constructors
		public User(string username, bool isAdmin = false)
		{
			this.Username = username;
			this.Password = defaultPassword;
			this.IsAdmin = isAdmin;
			PasswordExpirationDate = DateTime.Now;
		}

		public User(string username, string password, bool isAdmin = false)
		{
			this.Username = username;
			this.Password = password;
			this.IsAdmin = isAdmin;
			PasswordExpirationDate = DateTime.Now;
		}
		#endregion

		#region Properties
		public string Username
		{
			get { return username; }
			set
			{
				username = value;
				onPropertyChanged("Username");
			}
		}

		public string Password
		{
			set
			{
				password = value;

				// Set new expiration date every time password is changed
				PasswordExpirationDate = DateTime.Now.AddMonths(passwordValidityLength);
				onPropertyChanged("Password");
			}
		}

		public bool IsAdmin
		{
			get { return isAdmin; }
			set
			{
				isAdmin = value;
				onPropertyChanged("IsAdmin");
			}
		}

		public DateTime PasswordExpirationDate
		{
			get { return passwordExpirationDate; }
			set 
			{ 
				passwordExpirationDate = value;
				onPropertyChanged("PasswordExpirationDate");
			}
		}

		public bool IsPasswordExpired
		{
			get { return PasswordExpirationDate < DateTime.Now; }
		}
		#endregion

		#region Methods

		// Instead of exposing password through a public property, entities outside of the class can only compare a string to see if it matches the users password
		public bool IsPasswordMatch(string password)
		{
			return this.password == password;
		}

		// Sets password back to default (user must choose a new password at next login)
		public void ResetPassword()
		{
			password = defaultPassword;
			PasswordExpirationDate = DateTime.Now;
		}

		// Method to be called by set accessor whenever a property is changed
		private void onPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public override string ToString()
		{
			return String.Format("{0} {1}", Username, PasswordExpirationDate.ToString("dd/MM/yy"));
		}
		#endregion
	}
}
