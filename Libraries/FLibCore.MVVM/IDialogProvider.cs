using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLibCore.MVVM
{
	public interface IDialogProvider
	{
		void ShowMessageDialog(string message);

		void ShowErrorDialog(string error);

		string GetOpenFilePath();

		string GetSaveFilePath();
	}
}
