using System;
using System.ComponentModel;

namespace FLibCore.MVVM
{
	public class ReadOnlyBindable<T> : PropertyChangedNotifier
	{
		private readonly Bindable<T> _bindable;

		public T Value => _bindable.Value;

		public ReadOnlyBindable(Bindable<T> bindable)
		{
			_bindable = bindable ?? throw new ArgumentNullException(nameof(bindable));
			_bindable.PropertyChanged += Bindable_PropertyChanged;
		}

		private void Bindable_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			InvokePropertyChangedEvent(nameof(Value));
		}
	}
}
