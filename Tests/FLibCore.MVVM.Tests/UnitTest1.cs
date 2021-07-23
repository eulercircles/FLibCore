using NUnit.Framework;

namespace FLibCore.MVVM.Tests
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
			var serviceContainer = new ServiceContainer();
			serviceContainer.Add<IMediatorService>(new MediatorService());
			var mediatorService = serviceContainer.Get<IMediatorService>();

			Assert.Pass();
		}
	}
}
