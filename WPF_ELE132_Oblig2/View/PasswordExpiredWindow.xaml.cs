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
	/// Interaction logic for PasswordExpiredWindow.xaml
	/// </summary>
	public partial class PasswordExpiredWindow : Window
	{
		public PasswordExpiredWindow(EventArgs eArg)
		{
			InitializeComponent();

			this.ViewModel = new ViewModelPasswordExpired(eArg);
			this.DataContext = ViewModel;

			this.ViewModel.PasswordChangeAttempted += (sender, e) =>
			{
				if (e.ChangeSuccessful)
				{
					this.DialogResult = true;
				}
				else
					MessageBox.Show("Password change unsuccessful. Make sure you have entered the same password in both fields.", "Error");
			};
		}

		public ViewModelPasswordExpired ViewModel { get; private set; }

		private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
		{
			textBoxRelay1.Text = (sender as PasswordBox).Password;
		}

		private void passwordBox2_PasswordChanged(object sender, RoutedEventArgs e)
		{
			textBoxRelay2.Text = (sender as PasswordBox).Password;
		}

		private void passwordBox3_PasswordChanged(object sender, RoutedEventArgs e)
		{
			textBoxRelay3.Text = (sender as PasswordBox).Password;
		}
	}
}
