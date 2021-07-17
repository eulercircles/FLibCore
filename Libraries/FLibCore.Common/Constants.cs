using System;

namespace FLibCore.Common
{
  public static class Messages
  {
    /// <summary>{0} is the required type and {1} is the passed type.</summary>
    public const string fParameterIsNotAValidType = "Parameter must be of type {0} and not type {}.";
    /// <summary>{0} is the enum member.</summary>
    public const string fUnhandledEnumValue = "The value {0} is unhandled.";
    /// <summary>{0} is the name of the argument, {1} is the lower bound and {2} is the upper bound.</summary>
    public const string fValueMustBeBetween = "The value of {0} must be between {1} and {2}.";
    public const string StringIsEmpty = "The string is empty.";
    public const string StringIsWhiteSpace = "The string is white space.";
    public const string UnhandledEnumValue = "Unhandled enum value: ";
  }

  public static class Formats
  {
    public const string DateTime_YearFirst = "yyyy-MM-dd";
  }
}
