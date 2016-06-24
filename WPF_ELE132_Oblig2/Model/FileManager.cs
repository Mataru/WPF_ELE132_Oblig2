using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Author: Mathias Angelvik
// Date: 12.11.2015
// Version: 1.0
namespace WPF_ELE132_Oblig2.Model
{
	// Class that handles serializing and deserializing to file for any generic collection class
	public static class FileManager<T1, T2> where T1 : class, ICollection<T2>, new()
	{
		// Creates a new file unless one of that name already exists, in which case it overwrites
		public static void SaveNewFile(string filepath, T1 objectToSave)
		{
			using (FileStream saveStream = File.Open(@filepath, FileMode.Create, FileAccess.Write))
			{
				try
				{
					BinaryFormatter binFormatter = new BinaryFormatter();
					binFormatter.Serialize(saveStream, objectToSave);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.GetBaseException().Message);
				}
			}
		}

		// Appends an existing file
		public static void AppendFile(string filepath, T1 objectToSave)
		{
			T1 tempCollection = ReadFile(filepath);

			using (FileStream appendStream = File.Open(@filepath, FileMode.Create, FileAccess.Write))
			{
				try
				{
					foreach (T2 item in objectToSave)
					{
						tempCollection.Add(item);
					}

					BinaryFormatter binFormatter = new BinaryFormatter();
					binFormatter.Serialize(appendStream, tempCollection);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.GetBaseException().Message);
				}
			}
		}

		// Reads from file
		public static T1 ReadFile(string filepath)
		{
			using (FileStream readStream = File.Open(@filepath, FileMode.Open, FileAccess.Read))
			{
				try
				{
					T1 tempCollection = new T1();
					BinaryFormatter binFormatter = new BinaryFormatter();
					tempCollection = binFormatter.Deserialize(readStream) as T1;

					return tempCollection;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.GetBaseException().Message);
				}
			}
		}

	}
}
