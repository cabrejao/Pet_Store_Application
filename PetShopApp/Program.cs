using Microsoft.VisualBasic.FileIO;
using Pet_Store_Application;
using System;
using System.ComponentModel;
using System.Text.Json;
using static Pet_Store_Application.Product;
using static Pet_Store_Application.ProductLogic;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;




namespace Pet_Store_Application

{


    class Program
    {
        
        private static IServiceProvider CreateServiceCollection() 
        {
            return new ServiceCollection()
                .AddTransient <IProductLogic,ProductLogic>()
                .BuildServiceProvider();
        }
        static void Main()
        {
            var services = CreateServiceCollection();
            var productLogic = services.GetService<IProductLogic>();
            var menuOptions = new MenuOptions();
            var userInput = menuOptions.ShowMenuOptions();
            //while loop:
            while (userInput.ToLower() != "exit")
            {

                //if add product:
                if (userInput == "1")
                {
                    //cat food object:
                    Console.WriteLine("Please enter Cat Food details.");
                    string jsonString = Console.ReadLine();
                    CatFood? catFood = JsonSerializer.Deserialize<CatFood>(jsonString);
                    Console.WriteLine($"Name: {catFood.Name}");
                    Console.WriteLine($"Quantity: {catFood.Quantity}");
                    Console.WriteLine($"Price: {catFood.Price}");
                    Console.WriteLine($"Description: {catFood.Description}");
                    productLogic.AddProduct(catFood);
                    Console.WriteLine("");
                    Console.WriteLine("Added item successfully.");
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