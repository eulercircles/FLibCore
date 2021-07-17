using System;

namespace FLibCore.Common
{
  public class Observable<T>
  {
    private T _value;
    public T Value
    {
      get => _value;
      set
      {
        if (_value == null)
				{
          if (value != null)
					{
            _value = value;
            _valueChanged.Invoke(this, null);
					}
				}
        else
				{
          if (!_value.Equals(value))
					{
            _value = value;
            _valueChanged.Invoke(this, null);
					}
				}
      }
    }

    private readonly SafeEvent<EventArgs> _valueChanged;
    public Event<EventArgs> ValueChanged { get; }

    public Observable() : this(default) { }

    public Observable(T initialValue)
		{
      _valueChanged = new SafeEvent<EventArgs>();
      ValueChanged = new Event<EventArgs>(_valueChanged);

      Value = initialValue;
		}

    public void Refresh() => _valueChanged.Invoke(this, null);
  }
}
