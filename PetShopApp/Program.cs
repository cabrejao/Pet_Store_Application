using Microsoft.VisualBasic.FileIO;
using Pet_Store_Application;
using System;
using System.ComponentModel;
using System.Text.Json;
using static Pet_Store_Application.Product;
using static Pet_Store_Application.ProductLogic;




namespace Pet_Store_Application

{


    class Program
    {

        static void Main()
        {
            var productLogic = new ProductLogic();
            var menuOptions = new MenuOptions();
            var userInput = menuOptions.ShowMenuOptions();
            //while loop:
            while (userInput.ToLower() != "exit")
            {

                //if add product:
                if (userInput == "1")
                {
                    //cat food object:
                    CatFood catFood = new CatFood();
                    //user prompt and input lines:
                    Console.WriteLine("Please enter the Cat Food name:");
                    catFood.Name = Console.ReadLine();
                    Console.WriteLine("Added " + catFood.Name + " successfully.");
                    Console.WriteLine("Please enter the product Quantity:");
                    catFood.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Added " + catFood.Quantity + " units of " + catFood.Name + " successfully.");
                    //Add Product
                    productLogic.AddProduct(catFood);
                    Console.WriteLine("Added item successfully.");
                    userInput = menuOptions.ShowMenuOptions();
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Please enter a Cat Food name.");
                    userInput = Console.ReadLine();
                    var catFoodReturn = productLogic.GetCatFoodByName(userInput);
                    if (catFoodReturn != null)
                    {
                        Console.WriteLine("There are " + catFoodReturn.Quantity + " units of " + catFoodReturn.Name + " in stock.");
                    }
                    else
                    {
                        Console.WriteLine("Product " + userInput + " could not be found.");
                    }
                    userInput = menuOptions.ShowMenuOptions();
                }
                else if (userInput == "3")
                {
                    //dog leash object:
                    DogLeash dogLeash = new DogLeash();
                    //user prompt and input lines:
                    Console.WriteLine("Please enter the Dog Leash name:");
                    dogLeash.Name = Console.ReadLine();
                    Console.WriteLine("Added " + dogLeash.Name + " successfully.");
                    Console.WriteLine("Please enter the product Quantity:");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Added " + dogLeash.Quantity + " units of " + dogLeash.Name + " successfully.");
                    //Add Product
                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Added item successfully.");
                    userInput = menuOptions.ShowMenuOptions();

                }
                else if (userInput == "4")
                {
                    Console.WriteLine("Please enter a Dog Leash name.");
                    userInput = Console.ReadLine();
                    var dogLeashesReturn = productLogic.GetDogLeashByName(userInput);
                    if (dogLeashesReturn != null)
                    {
                        Console.WriteLine("There are " + dogLeashesReturn.Quantity + " units of " + dogLeashesReturn.Name + " in stock.");
                    }
                    else
                    {
                        Console.WriteLine("Product " + userInput + " could not be found.");
                    }
                    userInput = menuOptions.ShowMenuOptions();
                }
                else if (userInput == "0")
                {
                    Console.WriteLine("These are your in-stock products: \n");
                    foreach (var product in productLogic.GetOnlyInStockProducts())
                    {
                        Console.WriteLine("\t" + product + "\n");
                    }
                    Console.WriteLine("");

                    userInput = menuOptions.ShowMenuOptions();
                }
                else if (userInput == "5")
                {
                    Console.WriteLine("The total price of all inventory is $" + productLogic.GetTotalPriceOfInventory() + ".");

                    userInput = menuOptions.ShowMenuOptions();
                }
                else
                {
                    Console.WriteLine("Invalid Input.");

                    userInput = menuOptions.ShowMenuOptions();
                }
                }



            }

        }


    }