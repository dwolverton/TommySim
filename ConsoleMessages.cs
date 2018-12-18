using System;
namespace TommySim
{
	public class ConsoleMessages : Messages
	{
		public override void Message(string message)
		{
			Console.WriteLine(message);
		}
	}
}
