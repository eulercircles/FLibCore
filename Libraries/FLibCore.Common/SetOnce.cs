namespace FLibCore.Common
{
	public class SetOnce<T>
	{
		private bool _isSet = false;

		private T _value;
		public T Value
		{
			get => _value;
			set
			{
				if (!_isSet)
				{
					_value = value;
					_isSet = true;
				}
			}
		}
	}
}
