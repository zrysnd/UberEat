using System;
using System.Collections;
using System.Collections.Generic;

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
    public interface ISelfLocationProvidable
    {

    }

    /*Represent any task that's time limited. It should have 
     * functions returning the time info, but we can fill in latter, like IDisplayable*/
    public interface ITimeLimited
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
    public interface IOrder : IPurchasable, ICollection<IPurchasable>
    {
    }

    /* Reuse: IOrderPlacable represents any client ordering any good or services */
    public interface IOrderPlacable
    {
        void PlaceOrder(IOrder order);
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
    public interface IShippable: ISelfLocationProvidable
    {
        ISelfLocationProvidable TargetLocation { get; set; }
    }

    /* Reuse: Any group of shippable goods from a same seller */
    public interface IShippableOrder: IOrder, IShippable
    {

    }

    /* Reuse: any client buying goods, and need the goods to be delivered. */
    public interface IClient: IOrderPlacable, IPayable, ISelfLocationProvidable
    {

    }

    /*  Reuse: any good provider that need to deliver goods to client*/
    public interface IBusinessProvider: IOrderReceivable, IPaymentRecievable, ISelfLocationProvidable, IDisplayable
    {
        IPurchasable TheItemPurchasedByUser(IClient user);
        void AskProviderToDeliverOrderedGoods(IShippable order, IClient client );
    }

    /* Reuse: A collection of good or service providers that is available to the user.  */
    public interface IAvaibleBusinessProviders: IDisplayable, ICollection<IBusinessProvider>
    {
        void UpdateAvailableProviders(ISelfLocationProvidable ClientLocation);
        IBusinessProvider TheProviderSelectedByUser();
    }

}
