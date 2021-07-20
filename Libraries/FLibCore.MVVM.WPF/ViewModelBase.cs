using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;

namespace FLibCore.MVVM.WPF
{
	public abstract class ViewModelBase : DependencyObject, INotifyPropertyChanged //, IDisposable
	{
		#region Dependency Properties
		private static readonly DependencyProperty _mediatorProperty
			= DependencyProperty.Register(nameof(Mediator), typeof(IMediator), typeof(ViewModelBase));
		public IMediator Mediator
		{
			get => (IMediator)GetValue(_mediatorProperty);
			set
			{
				SetValue(_mediatorProperty, value);
				OnSetMediator();
			}
		}

		private static readonly DependencyProperty _dialogProviderProperty
			= DependencyProperty.Register(nameof(DialogProvider), typeof(IDialogProvider), typeof(ViewModelBase));
		public IDialogProvider DialogProvider
		{
			get => (IDialogProvider)GetValue(_dialogProviderProperty);
			set
			{
				SetValue(_dialogProviderProperty, value);
				OnSetDialogProvider();
			}
		}
		#endregion Dependency Properties

		public virtual void Initialize() { }

		public virtual void UnInitialize() { }

		protected virtual void OnSetMediator() { }

		protected virtual void OnSetDialogProvider() { }

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
