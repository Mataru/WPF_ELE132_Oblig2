using System;
using System.Windows.Input;

namespace WPF_ELE132_Oblig2.ViewModel
{
	// Command class copied from ViewModel project in Visual C# Step by Step chapter 26
	public class Command : ICommand
	{
		private Action methodToExecute = null;
		private Func<bool> methodToDetectCanExecute = null;
		//private DispatcherTimer canExecuteChangedEventTimer = null;

		public event EventHandler CanExecuteChanged;

		public Command(Action methodToExecute, Func<bool> methodToDetectCanExecute)
		{
			this.methodToExecute = methodToExecute;
			this.methodToDetectCanExecute = methodToDetectCanExecute;

			//this.canExecuteChangedEventTimer = new DispatcherTimer();
			//this.canExecuteChangedEventTimer.Tick += canExecuteChangedEventTimer_Tick;
			//this.canExecuteChangedEventTimer.Interval = new TimeSpan(0, 0, 1);
			//this.canExecuteChangedEventTimer.Start();
		}

		public void Execute(object parameter)
		{
			this.methodToExecute();
		}

		public bool CanExecute(object parameter)
		{
			if (this.methodToDetectCanExecute == null)
			{
				return true;
			}
			else
			{
				return this.methodToDetectCanExecute();
			}
		}

		public void OnCanExecuteChanged()
		{
			if (CanExecuteChanged != null)
			{
				CanExecuteChanged(this, EventArgs.Empty);
			}
		}

		//void canExecuteChangedEventTimer_Tick(object sender, object e)
		//{
		//	if (this.CanExecuteChanged != null)
		//	{
		//		this.CanExecuteChanged(this, EventArgs.Empty);
		//	}
		//}
	}
}
