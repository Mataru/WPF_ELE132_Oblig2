using System;
using System.Windows;
using WPF_ELE132_Oblig2.ViewModel;

namespace WPF_ELE132_Oblig2.View
{
	/// <summary>
	/// Interaction logic for LoginSuccessWindow.xaml
	/// </summary>
	public partial class LoginSuccessWindow : Window
	{
		public LoginSuccessWindow(EventArgs eArg)
		{
			InitializeComponent();
			this.ViewModel = new ViewModelLoginSuccess(eArg);
			this.DataContext = ViewModel;

			// Closes window when the Logout command is triggered in the viewmodel
			this.ViewModel.CloseView += (sender, e) => this.Close();
		}

		public ViewModelLoginSuccess ViewModel { get; private set; }
	}
}
