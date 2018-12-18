using System;
namespace TommySim
{
    public class Resource
	{
        private static Random random = new Random();

		private string name;
		private int minCollect;
		private int maxCollect;
		private int amount;
		private Messages messages;

        public int Amount
		{
			get { return amount; }
		}

		public Resource(string name, int amount, int minCollect, int maxCollect, Messages messages)
        {
			this.name = name;
			this.amount = amount;
			this.minCollect = minCollect;
			this.maxCollect = maxCollect;
			this.messages = messages;
        }

		public void Collect() {
			int count = random.Next(minCollect, maxCollect + 1);
			messages.Resource(name, count);
			amount += count;
		}

		public void Increment(int value) {
			amount += value;
		}

		public void Decrement(int value) {
			amount -= value;
			if (amount < 0) {
				amount = 0;
			}
		}
    }
}
