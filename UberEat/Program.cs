using System;

namespace UberEat
{
    class MainClass
    {
        public static void Main(string[] args)
        {   

            UberEat uberEat = new UberEat(new FoodOrder(), new AvailableRestaurantsDetector());
            Console.WriteLine("UberEat ready.");

            IClient thisUser = new Client();
            uberEat.ClientLoggedIn(thisUser);
            Console.WriteLine("User logged in. Available Restaurants displayed.");

            /*Assuming Front-end will tell which restaurant, food is selected.*/
            uberEat.RestaurantsToBeDisplayed(); //return to something in real code.
            uberEat.SelectRestaurant(new Restaurant());
            Console.WriteLine("Restaurant selected by user, Food menu displayed.");

            uberEat.RestaurantsToBeDisplayed(); //return to something in real code.
            uberEat.AddFoodToOrder(new Food());
            Console.WriteLine("Food added to user's order.");
            uberEat.AddFoodToOrder(new Food());
            Console.WriteLine("Food added to user's order.");
            uberEat.AddFoodToOrder(new Food());
            Console.WriteLine("Food added to user's order.");

            uberEat.HandleOrder();
            Console.WriteLine("Restaurant will deliver food.");

            uberEat.OrderReceivedByClent();
            Console.WriteLine("Order arrived, payment completed.");
        }
    }
}
