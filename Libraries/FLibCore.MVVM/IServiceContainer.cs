using System;

namespace FLibCore.MVVM
{
	public interface IServiceContainer
	{
		void Add<T>(object service);
		T Get<T>();
	}
}
