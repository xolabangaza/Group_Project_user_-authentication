 using System;
namespace Group_Project
{

    class Program
    {
        static void Main(string[] args)
        {
            // User credentials
            string correctUsername = "xola@admin";
            string correctPassword = "12345";
            int attempts = 0;
            bool isAuthenticated = false;

            Console.WriteLine("***** Welcome to Uviwe and Xola's Coffee machine *****");
            // Authentication
            while (attempts < 3 && !isAuthenticated)
            {
                Console.Write("Enter username: ");
                string uName = Console.ReadLine();
                Console.Write("Enter password: ");
                string uPassword = Console.ReadLine();
                Console.Clear();

                if (uName == correctUsername && uPassword == correctPassword)
                {
                    isAuthenticated = true;
                     Console.WriteLine("***** You have been logged in " + correctUsername + " *****");
                }
                else
                {
                    Console.WriteLine("Credentials are not correct.");
                    attempts++;
                }
            }

            if (!isAuthenticated)
            {
                Console.WriteLine("You have been logged out.");
                return;
            }

            List<string> previousOrders = new List<string>();
            bool openning = true;

            while (openning)
            {

                Console.WriteLine("1. Order Coffee");
                Console.WriteLine("2. View Previous Orders");
                Console.WriteLine("3. Logout");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    bool ordering = true;
                    double totalCost = 0.0;

                    while (ordering)
                    {
                        Console.WriteLine("Select coffee type:");
                        Console.WriteLine("1. Espresso - R25.00");
                        Console.WriteLine("2. Latte - R35.00");
                        Console.WriteLine("3. Cappuccino - R40.00");
                        Console.Write("Choose an option: ");
                        string coffeeOption = Console.ReadLine();

                        double basePrice = 0.0;
                        string coffeeType = "";

                        if (coffeeOption == "1")
                        {
                            basePrice = 25.00;
                            coffeeType = "Espresso";
                        }
                        else if (coffeeOption == "2")
                        {
                            basePrice = 35.00;
                            coffeeType = "Latte";
                        }
                        else if (coffeeOption == "3")
                        {
                            basePrice = 40.00;
                            coffeeType = "Cappuccino";
                        }

                        Console.WriteLine("Select size:");
                        Console.WriteLine("1. Small");
                        Console.WriteLine("2. Medium (+R5.00)");
                        Console.WriteLine("3. Large (+R10.00)");
                        Console.Write("Choose an option: ");
                        string sizeOption = Console.ReadLine();

                        double sizeCost = 0.0;
                        string size = "";

                        if (sizeOption == "1")
                        {
                            size = "Small";
                        }
                        else if (sizeOption == "2")
                        {
                            sizeCost = 5.00;
                            size = "Medium";
                        }
                        else if (sizeOption == "3")
                        {
                            sizeCost = 10.00;
                            size = "Large";
                        }

                        double coffeeCost = basePrice + sizeCost;
                        totalCost += coffeeCost;
                        previousOrders.Add($"{size} {coffeeType} - R{coffeeCost:F2}");

                        Console.Write("Do you want to order another coffee? (yes/no): ");
                        string anotherCoffee = Console.ReadLine().ToLower();

                        if (anotherCoffee != "yes")
                        {
                            ordering = false;
                            Console.WriteLine($"Total cost: R{totalCost:F2}");
                        }
                    }
                }
                else if (option == "2")
                {
                    if (previousOrders.Count == 0)
                    {
                        Console.WriteLine("No previous orders.");
                    }
                    else
                    {
                        Console.WriteLine("Previous Orders:");
                        foreach (string order in previousOrders)
                        {
                            Console.WriteLine(order);
                        }
                    }
                }
                else if (option == "3")
                {
                    openning = false;
                    Console.WriteLine("You have been logged out.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }

}