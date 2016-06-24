using System.Windows;
using System.Windows.Controls;
using WPF_ELE132_Oblig2.ViewModel;

namespace WPF_ELE132_Oblig2.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
			this.ViewModel = new ViewModelLogin();
			this.DataContext = this.ViewModel;

			// Event handler for the LoadNewView event in the viewmodel
			this.ViewModel.LoadNewView += (sender, e) =>
			{
				bool? proceed = true;

				this.Hide();
				if (e.CurrentUser.IsPasswordExpired)
				{
					// proceed will be set to false if user exits the passwordExpired window without changing the password
					proceed = new PasswordExpiredWindow(e).ShowDialog();
				}
				if (proceed == true)
				{
					if (e.CurrentUser.IsAdmin)
						new LoginSuccessAdminWindow(e).ShowDialog();
					else
						new LoginSuccessWindow(e).ShowDialog();
				}
				this.Show();
			};

			// Event handler for the InvalidLogin event in the viewmodel
			this.ViewModel.InvalidLogin += (sender, e) =>
			{
				MessageBox.Show(e.ErrorMessage, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
			};
		}

		public ViewModelLogin ViewModel { get; private set; }

		// Copies the password to a hidden textbox whose text property is bound to the viewmodel
		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			textBoxRelay.Text = (sender as PasswordBox).Password;
		}
	}
}
