using System;
using System.Collections;
using System.Collections.Generic;

namespace UberEat
{
    // your file name is Interfaces.cs, why am I seeing things below that are not Interfaces????
    //^^^ These are fake implementations for interfaces, used in main function. Moved to a new file now.
    public class Client : IClient
    {

        public void PayForOrder(IOrder order)
        {
            //throw new NotImplementedException();
        }

        public void PlaceOrder(IOrder order)
        {
            //throw new NotImplementedException();
        }

        public void SetHowLongWaitingForOrder(ITimeLimited timeDuration, IShippableOrder order)
        {
            Console.WriteLine("Order urgency set by user.");
        }
    }

    public class Restaurant : IBusinessProvider
    {

        public void AcceptPayment(IMoney payment, IPayable payer)
        {
            //throw new NotImplementedException();
        }

        public void AskProviderToDeliverOrderedGoods(IShippable order)
        {
            //throw new NotImplementedException();
        }

        public bool OrderAccepted(IOrder order, IOrderPlacable client)
        {
            return true;
        }

        public IPurchasable TheItemPurchasedByUser(IClient user)
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

        public ISelfLocationProvidable TargetLocation { get => throw new NotImplementedException(); set => Console.WriteLine("Order Target location set to client."); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Years { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Months { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Days { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Hours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Minutes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Seconds { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(IPurchasable item)
        {
            Console.WriteLine("Food added to user's order.");
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IPurchasable item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IPurchasable[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IPurchasable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPurchasable item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class AvailableRestaurantsDetector : IAvaibleBusinessProviders
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IBusinessProvider item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IBusinessProvider item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IBusinessProvider[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IBusinessProvider> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IBusinessProvider item)
        {
            throw new NotImplementedException();
        }

        public IBusinessProvider TheProviderSelectedByUser()
        {
            return new Restaurant();
        }

        public void UpdateAvailableProviders(ISelfLocationProvidable ClientLocation)
        {
            //throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
