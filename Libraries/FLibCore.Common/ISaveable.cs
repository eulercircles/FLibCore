using System;

namespace FLibCore.Common
{
	public interface ISaveable
	{
		ReadOnlyObservable<bool> IsDirty { get; }

		void Save();
	}
}
