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

        public void AcceptPayment(IMoney payment)
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
        public IMoney Price => throw new NotImplementedException();

        public IBusinessProvider BusinessProvider => throw new NotImplementedException();
    }

    public class FoodOrder : IShippableOrder
    {
        public IMoney Price => throw new NotImplementedException();

        public IBusinessProvider BusinessProvider => throw new NotImplementedException();

        public ILocationProvidable TargetLocation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IPurchasable AccessPurchasable(int index)
        {
            throw new NotImplementedException();
        }

        public void AddPurchased(IPurchasable ToBePurchased)
        {
            //throw new NotImplementedException();
        }

        public void clear()
        {
            //throw new NotImplementedException();
        }

        public void RemovePurchasable(IPurchasable ToBeRemoved)
        {
            Console.WriteLine("Selected food removed from order.");
        }
    }

    public class AvailableRestaurantsDetector : IAvaibleBusinessProviders
    {

        public IBusinessProvider TheProviderSelectedByUser()
        {
            return new Restaurant();
        }

        public void UpdateAvailableProviders(ILocationProvidable ClientLocation)
        {
            //throw new NotImplementedException();
        }
    }
}
