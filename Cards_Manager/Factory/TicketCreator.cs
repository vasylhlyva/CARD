namespace Cards_Manager.Models
{
    public class TicketCreator : CardCreator
    {
        public override Card FactoryMethod()
        {
            return new Ticket();
        }
    }
}
