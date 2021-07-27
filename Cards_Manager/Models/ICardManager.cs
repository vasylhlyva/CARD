using System.Collections.Generic;

namespace Cards_Manager.Models
{
    public interface ICardManager
    {
        public List<Card> CardsList { get; }
        public void AddCardToList(Card card);
        public void DeleteCard(Card card);
    }
}