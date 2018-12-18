using System;
namespace TommySim
{
    public class RandomGenerator
    {
		private Random random = new Random();

		public int NextIntBetween(int min, int max) {
			return random.Next(min, max + 1);
		}
    }
}
