using System;
namespace UberEat
{   
    /*Reuse: An abstract concept containing info to be displayed*/
    public interface IDisplayable
    {

    }


    /* Reuse: any payment, in any currency*/
    public interface IMoney
    {

    }

    /* Reuse: Any object that can provide its current location*/
    public interface ILocationProvidable
    {

    }


    /*Reuse: IPurchasable can be any good or services(ex: booking hotel, goods from grocery stores..) that can be purchased */
    //anything that allows the user to borrows the purchasables??? -> inherits Idisplaiable
    public interface IPurchasable : IDisplayable
    {
        IMoney Price { get; }
        IBusinessProvider BusinessProvider { get; }
    }

    /*Reuse: an order containing one or more than one 'any kind of good or services 
      from the same seller. */
    public interface IOrder : IPurchasable
    {
        void AddPurchased(IPurchasable ToBePurchased);
        void RemovePurchasable(IPurchasable ToBeRemoved);
        IPurchasable AccessPurchasable(int index);
        void clear();
    }

    /* Reuse: IOrderPlacable represents any client ordering any good or services */
    public interface IOrderPlacable
    {
        void PlaceOrder(IOrder order, IOrderReceivable orderReceiver);
    }

    /*Reuse: Any organization, individual providing good or services clients require*/
    public interface IOrderReceivable
    {
        bool OrderAccepted(IOrder order);
    }

    /* Reuse: IOrderPlacable represents any client paying for any good or services */
    public interface IPayable
    {
        void PayForOrder(IOrder order, IPaymentRecievable seller);
    }

    /* Reused: any good or service provider receiving payment */
    public interface IPaymentRecievable
    {
        void AcceptPayment(IMoney payment);
    }


    /* Reuse: Any goods that can be shipped */
    public interface IShippable: ILocationProvidable
    {
        ILocationProvidable TargetLocation { get; set; }
    }

    /* Reuse: Any group of shippable goods from a same seller */
    public interface IShippableOrder: IOrder, IShippable
    {

    }

    /* Reuse: any client buying goods, and need the goods to be delivered. */
    public interface IClient: IOrderPlacable, IPayable, ILocationProvidable
    {

    }

    /*  Reuse: any good provider that need to deliver goods to client*/
    public interface IBusinessProvider: IOrderReceivable, IPaymentRecievable, ILocationProvidable, IDisplayable
    {
        IPurchasable TheItemPurchasedByUser();
        void AskProviderToDeliverOrderedGoods(IShippable order, IClient client );
    }

    /* Reuse: A collection of good or service providers that is available to the user.  */
    public interface IAvaibleBusinessProviders: IDisplayable
    {
        void UpdateAvailableProviders(ILocationProvidable ClientLocation);
        IBusinessProvider TheProviderSelectedByUser();
    }




}
