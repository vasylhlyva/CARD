using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cards_Manager.ViewModels;
using Cards_Manager.Views;
using Xamarin.Forms;

namespace Cards_Manager.Models
{
    public class CardManager
    {
        public static CardManager instance;
        public static CardManager Instance => instance ?? (instance = new CardManager());

        public List<Card> CardsList { get; }

        private CardManager()
        {
            CardsList = new List<Card>();           
        }

        public void AddCardToList(Card card)
        {             
            if (card != null)
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
                    if (Card.Name != card.Name || Card.Amount != card.Amount)
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
