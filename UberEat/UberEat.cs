using System;
namespace UberEat
{
    public class UberEat
    {
        private IClient _Client;
        private IShippableOrder _Order;

        public UberEat(IShippableOrder order, IAvaibleBusinessProviders restaurantsMonitor)
        {
            _Order = order;
            AvailableRestaurants = restaurantsMonitor;
        }

        public void ClientLoggedIn(IClient client)
        {
            _Client = client;
            AvailableRestaurants.UpdateAvailableProviders(_Client);
        }

        // something let the user borrows the restaurants-> added.
        public IDisplayable RestaurantsToBeDisplayed()
        {
            Console.WriteLine("Available restaurants displayed.");
            return AvailableRestaurants;
        }

        public IDisplayable OrderToBeDisplayed()
        {
            Console.WriteLine("Order displayed. ");
            return _Order;
        }

        public void SelectRestaurant(IBusinessProvider RestaurantSelected)
        {
            SelectedRestaurant = RestaurantSelected;
        }

        public IDisplayable FoodToBeDisplayed()
        {
            Console.WriteLine("Restaurant and its food displayed.");
            return SelectedRestaurant;
        }

        public void AddFoodToOrder(IPurchasable food  )
        {
            _Order.Add(food);
        }

        public bool HandleOrder()
        {
            if (!SelectedRestaurant.OrderAccepted(_Order, _Client))
                return false;
            _Order.TargetLocation = _Client;
            SelectedRestaurant.AskProviderToDeliverOrderedGoods(_Order);
//             _Order.clear();//not a good idea. what if they want to see order history.-> removed. 

            return true;
        }

        public void OrderReceivedByClent() 
            // how is OrderReceivedByClent related to HandleOrder ? 
            /*^^^ HandleOrder stops at asking the restaurant to deliver, when the frontend found the order
                  arrived to client, it can call this function, then app will process payment. */
        {
            _Client.PayForOrder(_Order);
        }

        public IAvaibleBusinessProviders AvailableRestaurants { get; }

        public IBusinessProvider SelectedRestaurant { get; private set; }

        public void SetOrderTimeLimit(ITimeLimited timeEnteredByUser)
        {
            _Order.Hours = timeEnteredByUser.Hours;
            _Order.Minutes = timeEnteredByUser.Minutes;
            Console.WriteLine("Order's arrival time limit set by user");
        }
    }


}
