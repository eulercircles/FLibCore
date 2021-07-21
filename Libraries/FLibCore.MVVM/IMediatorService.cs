using System;

namespace FLibCore.MVVM
{
	public delegate void MediatorRespondent<T>(T args) where T : MediatorArgs;

	public interface IMediatorService
	{
		void Register<T>(MediatorRespondent<T> respondent) where T : MediatorArgs;
		void Unregister<T>(MediatorRespondent<T> respondent) where T : MediatorArgs;
		void NotifyColleagues<T>(T message) where T : MediatorArgs;
	}
}
