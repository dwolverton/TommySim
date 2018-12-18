using System;
namespace TommySim
{
    public class Game
	{
        private static int FOOD_RATION = 1;
        private static int WATER_RATION = 2;
		private static int HOUSE_COST = 5;
		private static int WELL_COST = 6;

		private Resource food;
		private Resource water;
		private Resource wood;
		private int villagers = 1;
		private int wells = 0;
		private int actionCount = 0;
		private Messages messages;

		public Game(Messages messages) {
			this.messages = messages;
			food = new Resource("food", 6, 0, 4, messages);
			water = new Resource("water", 6, 1, 5, messages);
			wood = new Resource("wood", 0, 1, 5, messages);
		}

		public void PrintInstructions() {
			Console.WriteLine(@"Each villager gives you one action per turn. Actions are:
- Gather food: Adds a random amount of food between 0 and 4.
- Gather water: Adds a random amount of water between 1 and 5.
- Gather wood: Adds a random amount of wood between 1 and 5.
- Build a house: Costs 5 wood. Adds a villager.
- Build a well: Costs 6 wood. Each well gives one water per day.
At the end of each day, 1 food and 2 water are consumed for each villager. If either hits
zero, a villager is removed (but food and water never go below 0). 
If you have no villagers left, the game is over and you lose.
If you have 5 or more villagers left, you win!
");
		}

        public void PrintStatus()
        {
            Console.WriteLine($"You have {villagers} villagers, {wells} wells, {food.Amount} food, {water.Amount} water, and {wood.Amount} wood.");
        }

		public Boolean IsGameOver() {
			return IsWin() || IsLoss();
		}

		public Boolean IsWin() {
			return villagers >= 5;
		}

		public Boolean IsLoss() {
			return villagers <= 0;
		}

        public Boolean IsTurnOver()
        {
            return actionCount >= villagers;
        }

		public void NextTurn() {
			actionCount = 0;
			food.Decrement(villagers * FOOD_RATION);
			water.Increment(wells);
			water.Decrement(villagers * WATER_RATION);
			if (food.Amount == 0 || water.Amount == 0) {
				villagers--;
			}
		}

		public void GatherFood() {
			Gather(food);
		}

		public void GatherWater() {
			Gather(water);
		}

		public void GatherWood() {
			Gather(wood);
		}

		private void Gather(Resource resource) {
			PerformAction();
			resource.Collect();
		}

		public void BuildHouse() {
			UseWood(HOUSE_COST, "house");
			PerformAction();
            villagers++;
			messages.Build("house");
		}

		public void BuildWell()
        {
			UseWood(WELL_COST, "well");
			PerformAction();
            wells++;
			messages.Build("well");
        }

		private void PerformAction() {
			actionCount++;
		}

		private void UseWood(int amount, string itemToBuild) {
			if (wood.Amount < amount)
            {
				throw new InsufficientWoodException(itemToBuild);
            }
            wood.Decrement(amount);
		}
    }
}
