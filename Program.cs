// See https://aka.ms/new-console-template for more information

namespace ClassOOP;
class Program
{
    //Instatiate the FoodItem list
    private static List<FoodItem> foodItems = new List<FoodItem>();
    static void Main(string[] args)
    {
        //Set the program to run until the boolean is set to false
        bool running = true;

        while (running)
        {
            //Grab input from the user
            Console.Write("Food Bank Inventory System\n" +
            "1. Add Food Items\n" +
            "2. Delete Food Items\n" +
            "3. Print List of Current Food Items\n" +
            "4. Exit the Program\n" +
            "Enter the number of the option you would like: \n");

            string input = Console.ReadLine();

            //Create a switch statement so that based on user input, we can run a function
            switch (input)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintFoodItems();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Thanks for visiting the Food Bank!");
                    break;
                default:
                    Console.WriteLine("Not a valid option. Please enter a different number.");
                    break;
            }

        }

    }

    //Create the AddFoodItem method to add a food item to the list
    private static void AddFoodItem()
    {

        //Use a try statement to gather input and catch errors in wrong datatype input
        try 
        {
            //Gather input from the user
            Console.Write("Enter food item: ");
            string item = Console.ReadLine();

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            //Quantity must be greater than 0
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be a positive integer.");
            }

            Console.Write("Enter the expiration date (ex.YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            //Date must be in DateTime format and greater than the current date
            if (date <= DateTime.Now)
            {
                throw new ArgumentException("Expiration date must be a valid date and greater than the current date.");
            }

            //Set the inputs to a newItem in the list
            FoodItem newItem = new FoodItem(item, category, quantity, date);
            foodItems.Add(newItem);

            Console.WriteLine("The food item was added succesfully.");
        } 

        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    //Create a method to delete a food item
    private static void DeleteFoodItem()
    {

        //Checks to see if there are more than 0 items in the list
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No items to delete");
            return;
        }

        //Print the list so user can see what items are numbered. Grab user input and convert to integer
        PrintFoodItems();
        Console.Write("Which food item would you like to delete?: ");
        string input = Console.ReadLine();
        int.TryParse(input, out int index);

        //Create if statement to check whether the user input is a valid number in the index
        if (index > 0 && index <= foodItems.Count)
        {
            foodItems.RemoveAt(index - 1);
            Console.WriteLine("Food item deleted successfully!");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    //Create a method to print the items in the list
    private static void PrintFoodItems()
    {
        //Checks if there are any items in the list
        if (foodItems.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
            return;
        }

        //Prints the items in the list
        Console.WriteLine("Food Item List\n");
        for (int i = 0; i < foodItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {foodItems[i]}\n");

        }
    }

}