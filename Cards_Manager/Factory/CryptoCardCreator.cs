namespace Cards_Manager.Models
{
    public class CryptoCardCreator : CardCreator
    {
        public override Card FactoryMethod()
        {
            return new CryptoCard();
        }
    }
}
