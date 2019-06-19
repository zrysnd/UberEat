using System;
using System.Collections.Generic;

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
            Console.WriteLine("User logged in.");

            /*Assuming Front-end will tell which restaurant, food is selected.*/
            uberEat.RestaurantsToBeDisplayed(); //return to something in real code.
            IAvaibleBusinessProviders avaibleRestaurants = uberEat.AvailableRestaurants;
            IBusinessProvider restaurantSelectedByUser = avaibleRestaurants.TheProviderSelectedByUser(thisUser);
            uberEat.SelectRestaurant(restaurantSelectedByUser);

            //everything is awesome until this step. When you order food in reality, are you ordering food from a "new Restaurant()" ????
            /*^^^ changed it to restaurantSelectedByUser, been lazy when faking the real code... */


            Console.WriteLine("Restaurant selected by user");


            uberEat.FoodToBeDisplayed(); //should return the display info to something in real code.
            uberEat.OrderToBeDisplayed();//should return the display info to something in real code.
            ICollection <IPurchasable> foodSeleted = uberEat.SelectedRestaurant.TheItemPurchasedByUser(thisUser);
            uberEat.AddFoodToOrder(foodSeleted);
            //everything is awesome until this step. When you order food in reality, are you ordering food from a "new Food()" ????
            /*^^^ changed it to foodSeleted, been lazy when faking the real code... */

            uberEat.OrderToBeDisplayed();//should return the display info to something in real code.
            foodSeleted = uberEat.SelectedRestaurant.TheItemPurchasedByUser(thisUser);
            uberEat.AddFoodToOrder(foodSeleted);
            uberEat.OrderToBeDisplayed();//should return the display info to something in real code.
            foodSeleted = uberEat.SelectedRestaurant.TheItemPurchasedByUser(thisUser);
            uberEat.AddFoodToOrder(foodSeleted);
            uberEat.OrderToBeDisplayed();//should return the display info to something in real code.
            Time timeLimitEnteredByUser = new Time();
            uberEat.SetOrderTimeLimit(timeLimitEnteredByUser);

            uberEat.HandleOrder();
            Console.WriteLine("Restaurant will deliver food.");

            uberEat.OrderReceivedByClent();
            Console.WriteLine("Order arrived, payment completed.");

        }
    }
}
