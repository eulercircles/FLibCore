namespace FLibCore.Common
{
	public class Latch
	{
		public bool IsClosed { get; private set; } = false;
		public void Close() => IsClosed = true;
	}
}
