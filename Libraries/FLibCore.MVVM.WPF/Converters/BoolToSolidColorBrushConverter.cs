using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using System.Windows.Media;

using static FLibCore.Common.Messages;

namespace FLibCore.MVVM.WPF.Converters
{
	public class BoolToSolidColorBrushConverter : DependencyObject, IValueConverter
	{
		#region Dependency Properties
		private static readonly DependencyProperty _trueColorProperty
			= DependencyProperty.Register(nameof(TrueColor), typeof(SolidColorBrush), typeof(BoolToSolidColorBrushConverter));
		public SolidColorBrush TrueColor
		{
			get => (SolidColorBrush)GetValue(_trueColorProperty);
			set => SetValue(_trueColorProperty, value);
		}

		private static readonly DependencyProperty _falseColorProperty
			= DependencyProperty.Register(nameof(FalseColor), typeof(SolidColorBrush), typeof(BoolToSolidColorBrushConverter));
		public SolidColorBrush FalseColor
		{
			get => (SolidColorBrush)GetValue(_falseColorProperty);
			set => SetValue(_falseColorProperty, value);
		}
		#endregion Dependency Properties

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool)) { throw new ArgumentException(message: string.Format(fParameterIsNotAValidType, typeof(bool), value.GetType())); }
			return ((bool)value) ? TrueColor : FalseColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
