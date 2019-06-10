using System;
namespace UberEat
{
    // your file name is Interfaces.cs, why am I seeing things below that are not Interfaces????
    //^^^ These are fake implementations for interfaces, used in main function. Moved to a new file now.
    public class Client : IClient
    {

        public void PayForOrder(IOrder order, IPaymentRecievable seller)
        {
            //throw new NotImplementedException();
        }

        public void PlaceOrder(IOrder order, IOrderReceivable orderReceiver)
        {
            //throw new NotImplementedException();
        }
    }

    public class Restaurant : IBusinessProvider
    {

        public void AcceptPayment(IPayment payment)
        {
            //throw new NotImplementedException();
        }

        public void AskProviderToDeliverOrderedGoods(IShippable order, IClient client)
        {
            //throw new NotImplementedException();
        }

        public bool OrderAccepted(IOrder order)
        {
            return true;
        }

        public IPurchasable TheItemPurchasedByUser()
        {
            return new Food();
        }
    }

    public class Food : IPurchasable
    {
        public IPayment Price => throw new NotImplementedException();

        public IBusinessProvider BusinessProvider => throw new NotImplementedException();
    }

    public class FoodOrder : IShippableOrder
    {

        public IBusinessProvider OrderProvider => throw new NotImplementedException();

        public IPayment TotalPrice => throw new NotImplementedException();

        public void AddPurchased(IPurchasable ToBePurchased)
        {
            //throw new NotImplementedException();
        }

        public void clear()
        {
            //throw new NotImplementedException();
        }


        public void NeedToBeShippedTo(ILocationProvidable target)
        {
            throw new NotImplementedException();
        }
    }

    public class AvailableRestaurantsDetector : IAvaibleBusinessProviders
    {

        public IBusinessProvider TheProviderSelectedByUser()
        {
            return new Restaurant();
        }

        public void UpdateAvailableProviders()
        {
            //throw new NotImplementedException();
        }
    }
}
