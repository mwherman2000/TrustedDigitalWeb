#region Using directives

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Reflection;

using System.Windows.Forms;

#endregion

namespace System.Windows.Forms.Samples
{
	public class MailMessage : INotifyPropertyChanged
	{
		private string		_from;
		private string		_cc;
		private string		_to;
		private string		_subject;
		private bool		_read;
		private DateTime	_sentDate;
		private string		_path;

		private event PropertyChangedEventHandler _changed;

		public MailMessage()
		{
		}

		#region Properties
		public string From
		{
			get
			{
				return _from;
			}

			set
			{
				_from = value;
				OnPropertyChanged("From");
			}
		}

		public string To
		{
			get
			{
				return _to;
			}

			set
			{
				_to = value;
				OnPropertyChanged("To");
			}
		}

		public string Cc
		{
			get
			{
				return _cc;
			}

			set
			{
				_cc = value;
				OnPropertyChanged("Cc");
			}
		}

		public string Subject
		{
			get
			{
				return _subject;
			}

			set
			{
				_subject = value;
				OnPropertyChanged("Subject");
			}
		}

		public bool Read
		{
			get
			{
				return _read;
			}

			set
			{
				_read = value;
				OnPropertyChanged("Read");
			}
		}

		public DateTime SentDate
		{
			get
			{
				return _sentDate;
			}

			set
			{
				_sentDate = value;
				OnPropertyChanged("SentDate");
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}

			set
			{
				_path = value;
				OnPropertyChanged("Path");
			}
		}
		#endregion

		#region INotifyPropertyChanged Members
		protected void OnPropertyChanged(string property)
		{
			if (null != _changed)
			{
				_changed(this, new PropertyChangedEventArgs(property));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _changed += new PropertyChangedEventHandler(value); }
			remove { _changed -= new PropertyChangedEventHandler(value); }
		}
		#endregion
	}
}
