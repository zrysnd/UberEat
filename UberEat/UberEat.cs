using System;
namespace UberEat
{
    public class UberEat
    {
        IClient _Client; 
        IAvaibleBusinessProviders _AvailableRestaurants;
        IBusinessProvider _RestaurantSelected;
        IShippableOrder _Order;

        public UberEat(IShippableOrder order, IAvaibleBusinessProviders restaurantsMonitor)
        {
            _Order = order;
            _AvailableRestaurants = restaurantsMonitor;
        }

        public void ClientLoggedIn(IClient client)
        {
            _Client = client;
            _AvailableRestaurants.UpdateAvailableProviders(_Client);
        }

        // something let the user borrows the restaurants-> added.
        public IDisplayable RestaurantsToBeDisplayed()
        {
            Console.WriteLine("Available restaurants displayed.");
            return _AvailableRestaurants;
        }

        public IDisplayable OrderToBeDisplayed()
        {
            Console.WriteLine("Order displayed. ");
            return _Order;
        }

        public void SelectRestaurant(IBusinessProvider RestaurantSelected)
        {
            _RestaurantSelected = RestaurantSelected;
        }

        public IDisplayable FoodToBeDisplayed()
        {
            Console.WriteLine("Restaurant and its food displayed.");
            return _RestaurantSelected;
        }

        public void AddFoodToOrder(IPurchasable food  )
        {
            _Order.Add(food);
        }

        public bool HandleOrder()
        {
            if (!_RestaurantSelected.OrderAccepted(_Order))
                return false;
            _Order.TargetLocation = _Client;
            _RestaurantSelected.AskProviderToDeliverOrderedGoods(_Order);
//             _Order.clear();//not a good idea. what if they want to see order history.-> removed. 

            return true;
        }

        public void OrderReceivedByClent() 
            // how is OrderReceivedByClent related to HandleOrder ? 
            /*^^^ HandleOrder stops at asking the restaurant to deliver, when the frontend found the order
                  arrived to client, it can call this function, then app will process payment. */
        {
            _Client.PayForOrder(_Order, _RestaurantSelected);
        }

        public IAvaibleBusinessProviders AvailableRestaurants
        {
            get {return this._AvailableRestaurants; }
        }

        public IBusinessProvider SelectedRestaurant
        {
            get { return this._RestaurantSelected; }
        }
    }


}
