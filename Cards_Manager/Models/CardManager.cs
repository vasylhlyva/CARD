using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Cards_Manager.ViewModels;
using Cards_Manager.Views;
using Xamarin.Forms;

namespace Cards_Manager.Models
{
    public class CardManager : ImplementsINotifyPCh
    {
        CardsListViewModel CardsListViewModel;
        public static ObservableCollection<CardViewModel> CardsObserverList { get; set; }
        CardViewModel SelectedCard;
        public ICommand AddCardCommand { set; get; }
        public ICommand DelCardCommand { set; get; }
        public static INavigation Navigation { get; set; }
        public static CardManager _instance;
        public static CardManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CardManager();
            }
            return _instance;
        }

        private CardManager()
        {
            CardsObserverList = new ObservableCollection<CardViewModel>();
            AddCardCommand = new Command(AddCardToList);
            DelCardCommand = new Command(DeleteCard);
        }

        public static void AddCardToList(object Cardobj)
        {
            CardViewModel card = Cardobj as CardViewModel;
            if (card != null)
            {
                CardsObserverList.Add(card);
            }
            Back();
        }

        public static void DeleteCard(object Cardobj)
        {
            CardViewModel Card = Cardobj as CardViewModel;
            if (Card != null)
            {
                foreach (var card in CardsObserverList)
                {
                    if (Card.Name != card.Name || Card.Amount != card.Amount)
                    {
                        continue;
                    }
                    CardsObserverList.Remove(card);
                    break;
                }             
            }
            Back();
        }
        
        public static async void Back()
        {
            await Navigation.PopAsync();
        }        
    }
}
