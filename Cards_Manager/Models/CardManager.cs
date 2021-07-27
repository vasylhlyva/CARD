using System.Collections.Generic;
using System.Linq;

namespace Cards_Manager.Models
{
    public class CardManager : ICardManager
    {
        public List<Card> CardsList { get; }

        public CardManager()
        {
            CardsList = new List<Card>();
        }

        public void AddCardToList(Card card)
        {
            if (card != null && card.CardNumber != null)
            {
                CardsList.Add(card);
            }
        }

        public void DeleteCard(Card card)
        {
            var foundCard = CardsList.FirstOrDefault(x => x.Id.Equals(card.Id));

            if (foundCard == null)
            {
                return;
            }

            CardsList.Remove(foundCard);
        }
    }
}