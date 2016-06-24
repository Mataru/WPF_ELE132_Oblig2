using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using WPF_ELE132_Oblig2.Model;
using CryptographyClass;
using System.IO;

namespace WPF_ELE132_Oblig2.ViewModel
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void onPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected virtual void saveList(UserList list, string filePath)
		{
			Crypto crypt = new Crypto();
			
			if(File.Exists(filePath))
			{
				FileManager<List<User>, User>.AppendFile(filePath, list.ToList());
			}
			
		}
	}
}
