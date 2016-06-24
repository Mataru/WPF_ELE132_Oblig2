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
