using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WPF_ELE132_Oblig2.Model
{
	public class UserList 
	{
		private ObservableCollection<User> users;

		public UserList()
		{
			users = new ObservableCollection<User>();
		}

		public UserList(params User[] newUsers)
		{
			users = new ObservableCollection<User>(newUsers);
		}

		public UserList(IEnumerable<User> list)
		{
			users = (ObservableCollection<User>)list;
		}

		public User this [string username]
		{
			get
			{
				var query = users.Where(user => user.Username == username);

				if (query != null && query.Count() == 1)
					return query.ToList<User>()[0];
				else
					return null;
					//throw new NullReferenceException("No such username exists.");
			}
		}

		public ObservableCollection<User> this [DateTime expirationDate]
		{
			get
			{
				var query = users.Where(user => user.PasswordExpirationDate == expirationDate);

				if (query != null)
				{
					return new ObservableCollection<User>(query.ToList<User>());
					//List<User> usernames = new List<User>();

					//foreach (User user in query)
					//	usernames.Add(user.Username);

					//return usernames;
				}
				else
					return null;
					//throw new NullReferenceException("No such expiration date exists.");
			}
		}

		public User this [int index]
		{
			get
			{
				return users[index];
			}
		}

		public void Add(User newUser)
		{
			users.Add(newUser);
		}

		public void RemoveAt(int index)
		{
			users.RemoveAt(index);
		}

		public ObservableCollection<User> ToObservableCollection()
		{
			return users;
		}

		public List<User> ToList()
		{
			return users.ToList<User>();
		}
	}
}
