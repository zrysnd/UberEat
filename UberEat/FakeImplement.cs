﻿using System;
namespace UberEat
{
    // your file name is Interfaces.cs, why am I seeing things below that are not Interfaces????
    //^^^ These are fake implementations for interfaces, used in main function. Moved to a new file now.
    public class Client : IClient
    {
        public ILocation Location => throw new NotImplementedException();

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
        public ILocation Location => throw new NotImplementedException();

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

        public IToBeDisplayed GetProviderDisplayInfo()
        {
            Console.WriteLine("Restaurant and its food displayed.");
            return null;//faking implementation, won't use null in real code
        }
    }

    public class Food : IPurchasable
    {
        public IPayment Price => throw new NotImplementedException();

        public IBusinessProvider OrderProvider => throw new NotImplementedException();

        public IToBeDisplayed GetItemDisplayInfo()
        {
            Console.WriteLine("Food of selected restaurants displayed.");
            return null;//faking implementation, won't use null in real code
        }
    }

    public class FoodOrder : IShippableOrder
    {

        public IBusinessProvider OrderProvider => throw new NotImplementedException();

        public ILocation Location => throw new NotImplementedException();

        public IPayment TotalPrice => throw new NotImplementedException();

        public void AddPurchased(IPurchasable ToBePurchased)
        {
            //throw new NotImplementedException();
        }

        public void clear()
        {
            //throw new NotImplementedException();
        }

        public IToBeDisplayed GetOrderDisplayInfo()
        {
            Console.WriteLine("Order displayed. ");
            return null;//faking implementation, won't use null in real code
        }
    }

    public class AvailableRestaurantsDetector : IAvaibleBusinessProviders
    {

        public IBusinessProvider TheProviderSelectedByUser()
        {
            return new Restaurant();
        }

        public IToBeDisplayed GetAvailableProvidersDisplayInfo()
        {
            Console.WriteLine("Available restaurants displayed.");
            return null;//faking implementation, won't use null in real code
        }

        public void UpdateAvailableProviders()
        {
            //throw new NotImplementedException();
        }
    }
}
