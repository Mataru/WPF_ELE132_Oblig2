using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_ELE132_Oblig2.ViewModel;

namespace WPF_ELE132_Oblig2.View
{
	/// <summary>
	/// Interaction logic for LoginSuccessAdminWindow.xaml
	/// </summary>
	public partial class LoginSuccessAdminWindow : Window
	{
		public LoginSuccessAdminWindow(EventArgs eArg)
		{
			InitializeComponent();

			this.ViewModel = new ViewModelLoginSuccessAdmin(eArg);
			this.DataContext = ViewModel;

			ViewModel.Error += (sender, e) =>
			{
				MessageBox.Show(e.ErrorMessage, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
			};
		}

		public ViewModelLoginSuccessAdmin ViewModel { get; private set; }

		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			textBoxRelay.Text = (sender as PasswordBox).Password;
		}
	}
}
