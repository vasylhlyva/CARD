using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cards_Manager.ViewModels;
using Cards_Manager.Views;
using Xamarin.Forms;

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

        public void DeleteCard(Card Card)
        {            
            if (Card != null)
            {
                foreach (var card in CardsList)
                {
                    if (Card.Id != card.Id)
                    {
                        continue;
                    }
                    CardsList.Remove(card);
                    break;
                }             
            }
        }    

    }
}
