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
            _AvailableRestaurants.UpdateAvailableProviders();
        }

        // something let the user borrows the restaurants-> added.
        public IToBeDisplayed RestaurantsToBeDisplayed()
        {
            return _AvailableRestaurants.ToBeDisplayed();
        }

        public IToBeDisplayed OrderToBeDisplayed()
        {
            return _Order.ToBeDisplayed();
        }

        public void SelectRestaurant(IBusinessProvider RestaurantSelected)
        {
            _RestaurantSelected = RestaurantSelected;
        }

        public IToBeDisplayed FoodToBeDisplayed()
        {
            return _RestaurantSelected.ToBeDisplayed();
        }

        public void AddFoodToOrder(IPurchasable food  )
        {
            _Order.AddPurchased(food);
        }

        public bool HandleOrder()
        {
            if (!_RestaurantSelected.OrderAccepted(_Order))
                return false;
            _RestaurantSelected.AskProviderToDeliverOrderedGoods(_Order, _Client);
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
