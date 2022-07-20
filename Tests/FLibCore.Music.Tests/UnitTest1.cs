using NUnit.Framework;

namespace FLibCore.Music.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var note = Note.GetRandom();
			Assert.Pass();
		}
	}
}
