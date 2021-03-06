using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FLibCore.Common
{
	public static class NumericExtensions
	{
		public static int? ToInt(this string value) => int.TryParse(value, out int parsedValue) ? (int?)parsedValue : null;

		public static decimal? ToDecimal(this string value) => decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal parsedValue) ? (decimal?)parsedValue : null;

		public static string ToCurrencyString(this decimal value) => value.ToString("C", CultureInfo.CurrentCulture);

		public static bool IsNegative(this double value) => value < 0;

		public static bool IsGreaterThanZero(this string stringValue) => double.TryParse(stringValue, out double numericalValue) ? (numericalValue > 0) : false;

		public static bool IsInRange<T>(this T value, T lowerLimit, T upperLimit) where T : IComparable<T> => (value.CompareTo(lowerLimit) >= 0 && value.CompareTo(upperLimit) <= 0);


		public static bool IsIntegerValue(this string valueString) => (double.TryParse(valueString, out double parsedValue)) ? (parsedValue - Math.Truncate(parsedValue) == 0) : false;


		public static bool IsNumericValue(this string valueString) => double.TryParse(valueString, out double parsedValue);
	}

	public static class StringExtensions
	{
		public static bool IsEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool IsWhiteSpace(this string value)
		{
			return string.IsNullOrWhiteSpace(value); // item can't be null, so the only possibility if this returns true is that it's white space.
		}

		public static string NormalizeSpacing(this string value)
		{
			return Regex.Replace(value, @"\s+", " ");
		}

		public static string TrailingLetters(this string input, int count)
		{
			List<char> chars = new List<char>();
			for (int i = input.Length - 1; i > input.Length - count - 1; i--)
			{
				if (char.IsLetter(input[i]))
				{
					chars.Insert(0, input[i]);
				}
			}
			return new string(chars.ToArray());
		}

		public static string GetLeadingNumerical(this string input)
		{
			return new string(input.TakeWhile(c => char.IsNumber(c) || char.IsPunctuation(c)).ToArray());
		}
	}

	public static class DateTimeExtensions
	{
		public static DateTime BeginningOfWeek(this DateTime value)
		{
			while (value.DayOfWeek != DayOfWeek.Sunday)
			{
				value = value.AddDays(-1.0f);
			}

			return new DateTime(value.Year, value.Month, value.Day);
		}

		public static DateTime EndOfWeek(this DateTime value)
		{
			while (value.DayOfWeek != DayOfWeek.Saturday)
			{
				value = value.AddDays(1.0f);
			}

			return new DateTime(value.Year, value.Month, value.Day);
		}

		public static DateTime BeginningOfMonth(this DateTime value) => new DateTime(value.Year, value.Month, 1);

		public static DateTime EndOfMonth(this DateTime value) => new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));

		public static bool IsHoliday(this DateTime value)
		{
			return
					value.IsNewYearsDay()
			 || value.IsNewYearsEve()
			 || value.IsThanksgivingDay()
			 || value.IsDayAfterThanksgiving()
			 || value.IsChristmasEve()
			 || value.IsChristmasDay()
			 || value.IsFourthOfJuly()
			 || value.IsLaborDay()
			 || value.IsMemorialDay();
		}

		public static bool IsNewYearsDay(this DateTime date) => date.DayOfYear == AdjustForWeekendHoliday(new DateTime(date.Year, 1, 1)).DayOfYear;

		public static bool IsNewYearsEve(this DateTime date) => date.DayOfYear == AdjustForWeekendHoliday(new DateTime(date.Year, 12, 31)).DayOfYear;

		public static bool IsChristmasEve(this DateTime date) => date.DayOfYear == AdjustForWeekendHoliday(new DateTime(date.Year, 12, 24)).DayOfYear;

		public static bool IsChristmasDay(this DateTime date) => date.DayOfYear == AdjustForWeekendHoliday(new DateTime(date.Year, 12, 25)).DayOfYear;

		public static bool IsFourthOfJuly(this DateTime date) => date.DayOfYear == AdjustForWeekendHoliday(new DateTime(date.Year, 7, 4)).DayOfYear;

		public static bool IsLaborDay(this DateTime date)
		{
			// First Monday in September
			DateTime laborDay = new DateTime(date.Year, 9, 1);
			DayOfWeek dayOfWeek = laborDay.DayOfWeek;
			while (dayOfWeek != DayOfWeek.Monday)
			{
				laborDay = laborDay.AddDays(1);
				dayOfWeek = laborDay.DayOfWeek;
			}
			return date.DayOfYear == laborDay.DayOfYear;
		}

		public static bool IsMemorialDay(this DateTime date)
		{
			//Last Monday in May
			DateTime memorialDay = new DateTime(date.Year, 5, 31);
			DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
			while (dayOfWeek != DayOfWeek.Monday)
			{
				memorialDay = memorialDay.AddDays(-1);
				dayOfWeek = memorialDay.DayOfWeek;
			}
			return date.DayOfYear == memorialDay.DayOfYear;
		}

		public static bool IsThanksgivingDay(this DateTime date)
		{
			//4th Thursday in November
			var thanksgiving = (from day in Enumerable.Range(1, 30)
													where new DateTime(date.Year, 11, day).DayOfWeek == DayOfWeek.Thursday
													select day).ElementAt(3);
			DateTime thanksgivingDay = new DateTime(date.Year, 11, thanksgiving);
			return date.DayOfYear == thanksgivingDay.DayOfYear;
		}

		public static bool IsDayAfterThanksgiving(this DateTime date)
		{
			var thanksgiving = (from day in Enumerable.Range(1, 30)
													where new DateTime(date.Year, 11, day).DayOfWeek == DayOfWeek.Thursday
													select day).ElementAt(3);
			DateTime thanksgivingDay = new DateTime(date.Year, 11, thanksgiving + 1);
			return date.DayOfYear == thanksgivingDay.DayOfYear;
		}

		private static DateTime AdjustForWeekendHoliday(DateTime value)
		{
			switch (value.DayOfWeek)
			{
				case DayOfWeek.Saturday: return value.AddDays(-1);
				case DayOfWeek.Sunday: return value.AddDays(1);
				default: return value;
			}
		}
	}

	public static class EnumerationExtensions
	{
		/// <summary>
		/// Gets the value of the Description attribute of a single enum member.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Description(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
		}
	}
}
