using System;

using FLibCore.Common;

namespace FLibCore.Music
{
	public class Note
	{
		public NoteLetters Letter { get; }
		public Accidentals Accidental { get; internal set; }

		public string Name => $"{Letter}{Accidental.Symbol()}";
		public uint Chroma => ((uint)Letter + (uint)Accidental);

		public Note(NoteLetters letter, Accidentals accidental = Accidentals.Natural)
		{
			Letter = letter;
			Accidental = accidental;
		}

		public static Note GetRandom()
		{
			var random = new Random((int)DateTime.Now.Ticks);
			var letters = Enum.GetValues(typeof(NoteLetters));
			var accidentals = Enum.GetValues(typeof(Accidentals));

			var letter = (NoteLetters)letters.GetValue(random.Next(letters.Length));
			var accidental = (Accidentals)accidentals.GetValue(random.Next(accidentals.Length));

			return new Note(letter, accidental);
		}

		public override string ToString() => Name;
	}
}
