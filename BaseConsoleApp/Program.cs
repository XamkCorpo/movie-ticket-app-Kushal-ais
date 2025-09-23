using System;

namespace MovieTicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Welcome to the Movie Ticket System ===");

            string userName = "";
            while (true)
            {
                Console.Write("Please enter your name: ");
                userName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    break;
                }
                Console.WriteLine("Error: Name cannot be empty. Please try again.");
            }

            int userAge = 0;
            while (true)
            {
                Console.Write("Please enter your age: ");
                string ageInput = Console.ReadLine();
                if (int.TryParse(ageInput, out userAge) && userAge > 0)
                {
                    break;
                }
                Console.WriteLine("Error: Age must be a positive number. Please try again.");
            }

            int ticketType = 0;
            decimal ticketPrice = 0;
            string ticketName = "";

            while (true)
            {
                Console.WriteLine("\nPlease select your ticket type:");
                Console.WriteLine("1: Child's Ticket (under 12 years) = $5");
                Console.WriteLine("2: Adult Ticket (12-64 years) = $10");
                Console.WriteLine("3: Senior Ticket (65+ years) = $7");
                Console.Write("Enter your choice (1-3): ");

                string choice = Console.ReadLine();

                if (int.TryParse(choice, out ticketType) && ticketType >= 1 && ticketType <= 3)
                {
                    if (ticketType == 1 && userAge < 12)
                    {
                        ticketPrice = 5.00m;
                        ticketName = "Child's Ticket";
                        break;
                    }
                    else if (ticketType == 2 && userAge >= 12 && userAge <= 64)
                    {
                        ticketPrice = 10.00m;
                        ticketName = "Adult Ticket";
                        break;
                    }
                    else if (ticketType == 3 && userAge >= 65)
                    {
                        ticketPrice = 7.00m;
                        ticketName = "Senior Ticket";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error: Selected ticket type does not match your age. Please select again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number between 1 and 3.");
                }
            }

            decimal discount = 0.00m;
            bool askForDiscount = true;

            while (askForDiscount)
            {
                Console.Write("\nDo you have a discount code? (yes/no): ");
                string response = Console.ReadLine().ToLower();

                if (response == "yes" || response == "y")
                {
                    Console.Write("Enter your discount code: ");
                    string code = Console.ReadLine();

                    if (code == "SALE20")
                    {
                        discount = ticketPrice * 0.20m;
                        Console.WriteLine($"Discount applied! You saved ${discount:F2}");
                        askForDiscount = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount code.");
                        Console.Write("Try another code? (yes/no): ");
                        string tryAgain = Console.ReadLine().ToLower();
                        if (tryAgain == "no" || tryAgain == "n")
                        {
                            askForDiscount = false;
                        }
                    }
                }
                else if (response == "no" || response == "n")
                {
                    askForDiscount = false;
                }
                else
                {
                    Console.WriteLine("Please enter 'yes' or 'no'.");
                }
            }

            decimal finalPrice = ticketPrice - discount;

            Console.WriteLine("\n=== ORDER SUMMARY ===");
            Console.WriteLine($"Customer Name: {userName}");
            Console.WriteLine($"Ticket Type: {ticketName}");
            Console.WriteLine($"Original Price: ${ticketPrice:F2}");
            Console.WriteLine($"Discount Applied: ${discount:F2}");
            Console.WriteLine($"Final Price: ${finalPrice:F2}");
            Console.WriteLine("Thank you for your purchase!");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}