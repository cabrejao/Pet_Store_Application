using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet_Store_Application;

namespace Pet_Store_Application
{
	internal class MenuOptions
	{
		public string ShowMenuOptions()
		{
            Console.WriteLine("Press 1 to add a Cat Food product.");
            Console.WriteLine("Press 2 to view an existing Cat Food product.");
            Console.WriteLine("Press 3 to add a Dog Leash product.");
            Console.WriteLine("Press 4 to view an existing Dog Leash product.");
            Console.WriteLine("Press 5 to view the total price of all inventory.");
            Console.WriteLine("Press 0 to view in-stock products.");
            Console.WriteLine("Type 'exit' to quit");
            //user input variable:
            string userInput = Console.ReadLine();
            return userInput;
        }

	}
}
