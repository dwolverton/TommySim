using System;
namespace TommySim
{
    public abstract class Messages
    {
		public abstract void Message(string message);

		public void Resource(string name, int amount) {
			Message($"You went to gather {name} and got {amount}.");
		}

		public void Build(string name) {
			Message($"You built a {name}.");
		}

		public void InsufficientWood(string name) {
			Message($"You have insufficient wood to build a {name}.");
		}

    }
}
