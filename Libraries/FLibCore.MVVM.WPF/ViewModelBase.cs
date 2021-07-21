using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;

namespace FLibCore.MVVM.WPF
{
	public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged
	{
		private static readonly DependencyProperty _serviceContainerProperty
			= DependencyProperty.Register(nameof(ServiceContainer), typeof(IServiceContainer), typeof(ViewModelBase), new PropertyMetadata(null));
		public IServiceContainer ServiceContainer
		{
			get => (IServiceContainer)GetValue(_serviceContainerProperty);
			set => SetValue(_serviceContainerProperty, value);
		}

		public virtual void Initialize() { }

		public virtual void UnInitialize() { }

		#region INotifyPropertyChanged Implementation
		private PropertyChangedEventHandler _propertyChanged;

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value))
				{
					_propertyChanged += value;
				}
			}
			remove { _propertyChanged -= value; }
		}

		protected void TriggerPropertyChangedEvent(string propertyName)
		{
			Debug.Assert(!string.IsNullOrWhiteSpace(propertyName));

			if (!string.IsNullOrWhiteSpace(propertyName))
			{
				_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion // INotifyPropertyChanged Implementation
	}
}
