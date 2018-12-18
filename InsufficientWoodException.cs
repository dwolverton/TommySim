using System;
namespace TommySim
{
	public class InsufficientWoodException : Exception
    {
		private string item;
		public string Item {
			get => item;
		}

		public InsufficientWoodException(string item)
        {
			this.item = item;
        }
    }
}
