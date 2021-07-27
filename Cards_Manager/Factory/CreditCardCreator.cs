using System;
namespace Cards_Manager.Models
{
    public class CreditCardCreator : CardCreator
    {
        public override Card FactoryMethod()
        {
            return new CreditCard();
        }
    }
}
