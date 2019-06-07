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
            uberEat.SelectRestaurant(new Restaurant());
            //everything is awesome until this step. When you order food in reality, are you ordering food from a "new Restaurant()" ????
            
            Console.WriteLine("Restaurant selected by user, Food menu displayed.");

            uberEat.AddFoodToOrder(new Food());
            //everything is awesome until this step. When you order food in reality, are you ordering food from a "new Food()" ????

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
