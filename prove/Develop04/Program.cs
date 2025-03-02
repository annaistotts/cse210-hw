using System;

class Program
{
    static void Main(string[] args)
    {
        Activity breathingActivity = new BreathingActivity();
        Activity reflectionActivity = new ReflectionActivity();
        Activity listingActivity = new ListingActivity();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathingActivity.PerformActivity();
                    break;

                case "2":
                    reflectionActivity.PerformActivity();
                    break;

                case "3":
                    listingActivity.PerformActivity();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return; 

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
