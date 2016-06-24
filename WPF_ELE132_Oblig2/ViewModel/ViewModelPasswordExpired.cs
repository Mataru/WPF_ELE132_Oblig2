using System;
using WPF_ELE132_Oblig2.Model;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public class ViewModelPasswordExpired : ViewModelBase
	{
		private string currentPasswordEntry,
					   passwordEntry1, 
					   passwordEntry2;

		public event EventHandler<PasswordChangeAttemptedArgs> PasswordChangeAttempted;

		public ViewModelPasswordExpired(EventArgs e)
		{
			this.CurrentUser = (e as LoginEventArgs).CurrentUser;
			this.AttemptCreatePassword = new Command(createNewPassword, checkCreateCanExecute);
		}

		public Command AttemptCreatePassword { get; private set; }

		public string CurrentPassword
		{
			get { return currentPasswordEntry; }
			set
			{
				currentPasswordEntry = value;
				AttemptCreatePassword.OnCanExecuteChanged();
			}
		}

		public string NewPasswordEntry1
		{
			get { return passwordEntry1; }
			set
			{
				passwordEntry1 = value;
				AttemptCreatePassword.OnCanExecuteChanged();
			}
		}

		public string NewPasswordEntry2
		{
			get { return passwordEntry2; }
			set
			{
				passwordEntry2 = value;
				AttemptCreatePassword.OnCanExecuteChanged();
			}
		}

		public User CurrentUser { get; private set; }

		private void createNewPassword()
		{
			bool passwordChangeSuccessful = false;
			if (CurrentUser.IsPasswordMatch(CurrentPassword) && NewPasswordEntry1 == NewPasswordEntry2)
			{
				CurrentUser.Password = NewPasswordEntry2;
				passwordChangeSuccessful = true;
			}
			PasswordChangeAttempted(this, new PasswordChangeAttemptedArgs(passwordChangeSuccessful));
		}

		private bool checkCreateCanExecute()
		{
			return !(String.IsNullOrEmpty(CurrentPassword) || String.IsNullOrEmpty(NewPasswordEntry1) || String.IsNullOrEmpty(NewPasswordEntry2));
		}
	}
}
