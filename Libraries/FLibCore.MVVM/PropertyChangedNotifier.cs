using System;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;

namespace FLibCore.MVVM
{
	public class PropertyChangedNotifier : INotifyPropertyChanged
	{
		private PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value)) { _propertyChanged += value; } }
			remove { if (_propertyChanged != null && _propertyChanged.GetInvocationList().Contains(value)) { _propertyChanged -= value; } }
		}

		protected void InvokePropertyChangedEvent(string propertyName)
		{
			Debug.Assert(!string.IsNullOrWhiteSpace(propertyName));
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
