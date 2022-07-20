using System;

namespace FLibCore.Music
{
	public static class Symbols
	{
		public const char Comma = '\u002C';
		public const char Pipe = '\u007C';
		public const char Sharp = '\u266F';
		public const char Flat = '\u266D';
		public const char Natural = '\u266E';
		public const char Diminished = '\u25CB';
	}

	public static class Values
	{
		public const int PENTATONIC_COUNT = 5;
		public const int HEPTATONIC_COUNT = 7;
		public const int CHROMATIC_COUNT = 12;
	}

	public static class WesternModeNames
	{
		public const string LYDIAN = "Lydian";
		public const string IONIAN = "Ionian";
		public const string MIXOLYDIAN = "Mixolydian";
		public const string DORIAN = "Dorian";
		public const string AEOLIAN = "Aeolian";
		public const string PHRYGIAN = "Phrygian";
		public const string LOCRIAN = "Locrian";
	}
}
