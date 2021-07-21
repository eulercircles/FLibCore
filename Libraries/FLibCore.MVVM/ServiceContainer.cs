using System;
using System.Collections.Generic;

namespace FLibCore.MVVM
{
	public class ServiceContainer : IServiceContainer
	{
		private readonly Dictionary<Type, object> _registry = new();

		public void Add<T>(object service)
		{
			if (service.GetType().IsSubclassOf(typeof(T))) { throw new ArgumentException(""); }
			if (_registry.ContainsKey(typeof(T))) { throw new Exception(""); }

			_registry.Add(typeof(T), service);
		}

		public T Get<T>()
		{
			return (T)_registry[typeof(T)];
		}
	}
}
