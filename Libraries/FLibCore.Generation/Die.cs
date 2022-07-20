using System;

namespace FLibCore.Generation
{
	public class Die
	{
		private readonly int _sides;
		private readonly Random _random;

		public Die(ushort sides = 2)
		{
			_sides = sides > 1 ? sides : throw new ArgumentOutOfRangeException(nameof(sides), $"'{nameof(sides)} must be greater than 1.'");
			_random = new Random((int)DateTime.Now.Ticks);
		}

		public int Roll() => _random.Next(1, _sides);
	}
}
