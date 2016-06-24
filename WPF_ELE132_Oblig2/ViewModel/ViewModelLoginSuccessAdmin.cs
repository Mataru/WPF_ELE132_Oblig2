using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_ELE132_Oblig2.Model;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class ViewModelLoginSuccessAdmin : ViewModelBase
	{
		private string usernameEntry,
					   passwordEntry;

		public event EventHandler<ErrorEventArgs> Error;

		public ViewModelLoginSuccessAdmin(EventArgs e)
		{
			this.Users = (e as LoginEventArgs).AllUsers;
			this.CurrentUser = (e as LoginEventArgs).CurrentUser;
			this.ObservableUsers = Users.ToObservableCollection();

			this.DeleteUser = new Command(deleteUser, () => ObservableUsers != null && ObservableUsers.Count > 0);
			this.ResetPassword = new Command(resetPassword, () => ObservableUsers != null && ObservableUsers.Count > 0);
			this.CreateNewUser = new Command(createNewUser, () => !String.IsNullOrEmpty(UsernameEntry));
		}

		public Command DeleteUser { get; private set; }
		public Command ResetPassword { get; private set; }
		public Command CreateNewUser { get; private set; }

		public UserList Users { get; private set; }
		public ObservableCollection<User> ObservableUsers { get; private set; }
		public User SelectedUser { get; set; }
		public User CurrentUser { get; private set; }

		public string UsernameEntry
		{
			get { return usernameEntry; }
			set
			{
				usernameEntry = value;
				CreateNewUser.OnCanExecuteChanged();
			}
		}

		public string PasswordEntry
		{
			get { return passwordEntry; }
			set
			{
				passwordEntry = value;
				CreateNewUser.OnCanExecuteChanged();
			}
		}

		public bool AdminCheck { get; set; }

		private void deleteUser()
		{
			if (SelectedUser != null && SelectedUser != CurrentUser)
				ObservableUsers.Remove(SelectedUser);
			else
				Error(this, new ErrorEventArgs("Error: No user selected, or you do not have permission to delete the selected user."));
		}

		private void resetPassword()
		{
			if (SelectedUser != null)
				Users[SelectedUser.Username].ResetPassword();
			else
				Error(this, new ErrorEventArgs("Error: No user selected, or you do not have permission to reset the password of the selected user."));
		}

		private void createNewUser()
		{
			// if there are no users with this username
			if (Users[UsernameEntry] == null)
			{
				if (String.IsNullOrEmpty(PasswordEntry))
					Users.Add(new User(UsernameEntry, AdminCheck));
				else
					Users.Add(new User(UsernameEntry, PasswordEntry, AdminCheck));
			}
			else
				Error(this, new ErrorEventArgs("There already exists a user with this username. Please select a unique username."));
		}
	}
}
