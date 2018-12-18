using System;
using System.Threading;

namespace TommySim
{
    class Program
    {
		private static Messages messages = new ConsoleMessages();
		private static Game game = new Game(messages);

        static void Main(string[] args)
		{
			Console.WriteLine("-- Welcome to Tommy Sim! --");
			game.PrintInstructions();
			game.PrintStatus();

			while (!game.IsGameOver())
			{
				if (game.IsTurnOver())
				{
					AnimateNextDay();
					game.NextTurn();
					game.PrintStatus();
				}
				else
				{
					Console.WriteLine("What would you like to do? (Type food, water, wood, house, well, or quit.)");
					Console.Write("> ");
					string choice = Console.ReadLine();
					try
					{
						switch (choice)
						{
							case "food":
								game.GatherFood();
								break;
							case "water":
								game.GatherWater();
								break;
							case "wood":
								game.GatherWood();
								break;
							case "house":
								game.BuildHouse();
								break;
							case "well":
								game.BuildWell();
								break;
							case "quit":
								Console.WriteLine("Farewell. Thanks for playing!");
								return;
							default:
								Console.WriteLine("Oops. That's not a valid option. Try again.");
								break;
						}
						game.PrintStatus();
					} catch (InsufficientWoodException e) {
						messages.InsufficientWood(e.Item);
					}
				}
			}

			if (game.IsWin()) {
				Console.Write("Nice village. You win!! Thanks for playing!");
			} else if (game.IsLoss()) {
				Console.Write("All villagers have fled. You lose. Thanks for playing!");
			}
        }

		private static void AnimateNextDay() {
			Console.Write("Day over.    ");
			string animation = "__...ooOOOoo...__ ";
			foreach (char c in animation)
			{
                Console.Write("\b\b");
				Console.Write(c);
				Console.Write(' ');
				Thread.Sleep(50);
			}
            Console.WriteLine();
            Console.WriteLine();
		}
    }
}
