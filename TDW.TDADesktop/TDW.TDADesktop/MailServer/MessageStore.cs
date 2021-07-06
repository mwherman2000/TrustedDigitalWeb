#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace System.Windows.Forms.Samples
{
	public class MessageStore : INotifyPropertyChanged
	{
		static MessageStore				_store;
		BindingList<MailMessage>		_messages;
		int								_unreadCount = 0;
		int								_draftsCount = 3;
		int								_deletedCount = 16;
		MailMessage						_selectedMessage;
		int								_previous = 0;

		private event PropertyChangedEventHandler _changed;

		#region Private Constructor
		private MessageStore()
		{
			if (null == _messages)
			{
				// Load Messages
				DataSet     ds = new DataSet();
				int         unread = 0;

				// Create the data connector
				_messages = new SortableBindingList<MailMessage>();

				// Load data from Inbox (XML file)
				Assembly        assembly = this.GetType().Assembly;
				DataView        view;
				MailMessage     message;

				// Load into
                string[] res = assembly.GetManifestResourceNames();

                foreach (string rs in res)
                {
                    System.Diagnostics.Debug.WriteLine(rs);
                }

				ds.ReadXml(assembly.GetManifestResourceStream(this.GetType().Namespace + ".Mail.Inbox.xml"));
				view = ds.Tables[0].DefaultView;

				foreach (DataRowView row in view)
				{
					// Creat the message
					message = new MailMessage();
					message.Cc = row["CC"] as string;
					message.From = row["From"] as string;
					message.To = row["To"] as string;
					message.SentDate = (DateTime)row["SentDate"];
					message.Subject = row["Subject"] as string;
					message.Path = row["Path"] as string;
					message.Read = (bool)row["Read"];

					// Add the message
					_messages.Add(message);

					// Update count
					if (!message.Read)
					{
						unread++;
					}
				}

				// Select first message
				this.UnreadCount = unread;
				this.SelectedMessage = (_messages[0] as MailMessage);
			}
		}
		#endregion

		#region Singelton Access
		public static MessageStore GetMessageStore()
		{
			if (null == _store)
			{
				_store = new MessageStore();
			}

			return _store;
		}
		#endregion

		#region Public Properties
		public MailMessage SelectedMessage
		{
			get { return _selectedMessage; }
			set
			{
				if (_selectedMessage != value)
				{
					// Called when the selected item changes
					int pos = _messages.IndexOf(value);

					// See if a new item is selected
					if (_previous != pos)
					{
						// Check Previous (to mark as read)
						if (!value.Read)
						{
							// Mark as read
							value.Read = true;

							// Decrement unread count
							this.UnreadCount--;
						}

						// Set this to previous
						_previous = pos;
					}

					// Update Selected
					_selectedMessage = value;
					OnPropertyChanged("SelectedMessage");
				}
			}
		}

		public int UnreadCount
		{
			get { return _unreadCount; }
			set
			{
				_unreadCount = value;
				OnPropertyChanged("UnreadCount");
			}
		}

		public int DeletedCount
		{
			get { return _deletedCount; }
			set
			{
				_deletedCount = value;
				OnPropertyChanged("DeletedCount");
			}
		}

		public int DraftsCount
		{
			get { return _draftsCount; }
			set
			{
				_draftsCount = value;
				OnPropertyChanged("DraftsCount");
			}
		}

		public BindingList<MailMessage> Messages
		{
			get { return _messages; }
		}

		public void Reset()
		{
			// Force clients to re-read thier data
			OnPropertyChanged(null);
		}
		#endregion

		#region INotifyPropertyChanged Members
		protected void OnPropertyChanged(string prop)
		{
			if (null != _changed)
			{
				_changed(this, new PropertyChangedEventArgs(prop));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _changed += new PropertyChangedEventHandler(value); }
			remove { _changed -= new PropertyChangedEventHandler(value); }
		}
		#endregion
	}

	#region SortableBindingList
	public class SortableBindingList<T> : BindingList<T>
	{
		private bool _isSorted;

		protected override bool SupportsSortingCore
		{
			get { return true; }
		}

		protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
		{
			List<T> items = this.Items as List<T>;

			if (null != items)
			{
				PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
				items.Sort(pc);

				// Set sorted
				_isSorted = true;
			}
			else
			{
				// Set sorted
				_isSorted = false;
			}
		}

		protected override bool IsSortedCore
		{
			get { return _isSorted; }
		}

		protected override void RemoveSortCore()
		{
			_isSorted = false;
		}
	}
	#endregion

	#region PropertyComparar
	public class PropertyComparer<T> : System.Collections.Generic.IComparer<T>
	{

		// The following code contains code implemented by Rockford Lhotka:
		// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnadvnet/html/vbnet01272004.asp

		private PropertyDescriptor _property;
		private ListSortDirection _direction;

		public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
		{
			_property = property;
			_direction = direction;
		}

		public int Compare(T xWord, T yWord)
		{
			// Get property values
			object xValue = GetPropertyValue(xWord, _property.Name);
			object yValue = GetPropertyValue(yWord, _property.Name);

			// Determine sort order
			if (_direction == ListSortDirection.Ascending)
			{
				return CompareAscending(xValue, yValue);
			}
			else
			{
				return CompareDescending(xValue, yValue);
			}
		}

		public bool Equals(T xWord, T yWord)
		{
			return xWord.Equals(yWord);
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}

		// Compare two property values of any type
		private int CompareAscending(object xValue, object yValue)
		{
			int result;

			// If values implement IComparer
			if (xValue is IComparable)
			{
				result = ((IComparable)xValue).CompareTo(yValue);
			}
			// If values don't implement IComparer but are equivalent
			else if (xValue.Equals(yValue))
			{
				result = 0;
			}
			// Values don't implement IComparer and are not equivalent, so compare as string values
			else result = xValue.ToString().CompareTo(yValue.ToString());

			// Return result
			return result;
		}

		private int CompareDescending(object xValue, object yValue)
		{
			// Return result adjusted for ascending or descending sort order ie
			// multiplied by 1 for ascending or -1 for descending
			return CompareAscending(xValue, yValue) * -1;
		}

		private object GetPropertyValue(T value, string property)
		{
			// Get property
			PropertyInfo propertyInfo = value.GetType().GetProperty(property);

			// Return value
			return propertyInfo.GetValue(value, null);
		}
	}
	#endregion
}
