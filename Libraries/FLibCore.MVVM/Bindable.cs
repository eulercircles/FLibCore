using System;
using System.ComponentModel;

namespace FLibCore.MVVM
{
	public class Bindable<T> : PropertyChangedNotifier
	{
		private T _value;
		public T Value
		{
			get => _value;
			set
			{
				_value = value;
				InvokePropertyChangedEvent(nameof(Value));
			}
		}

		public Bindable(T initialValue = default(T)) => Value = initialValue;

		public void Refresh() => InvokePropertyChangedEvent(nameof(Value));
	}
}
