using System;
namespace UberEat
{
    public class UberEat
    {
        IClient _Client; //init??-> added ClientLoggedIn
        IAvaibleBusinessProviders _AvailableRestaurants;//init? -> added in constructor.
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

        // something let the user borrows the restaurants
        public IToBeDisplayed RestaurantsToBeDisplayed()
        {
            return _AvailableRestaurants.ToBeDisplayed();
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
            /*Not sure about whether I need this line or not, I think the software need to
            wait for restaurant to accept order, assuming the frontend calls this
            HandleOrder() in a while loop or other possible proper ways. */
            if (!_RestaurantSelected.OrderAccepted(_Order))
                return false;
            _RestaurantSelected.AskProviderToDeliverOrderedGoods(_Order, _Client);

//             _Order.clear();//not a good idea. what if they want to see order history.-> removed. 

            return true;
        }

        public void OrderReceivedByClent()
        {
            _Client.PayForOrder(_Order, _RestaurantSelected);
        }
    }


}
