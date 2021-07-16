using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Cards_Manager.Views;
using System.Collections.ObjectModel;
using Cards_Manager.Models;
using System.Threading.Tasks;

namespace Cards_Manager.ViewModels
{
    public class CardsListViewModel : BaseViewModel
    {
        private Card selectedCard;        

        public ObservableCollection<Card> CardsObserverList { get; set; }               

        public Card SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                OnPropertyChanged(nameof(SelectedCard));
            }
        }       

        public ICommand ShowMenuCommand { get; set; }
        public ICommand EditSelectedCardCommand { get; set; }
        public ICommand DelSelectedCardCommand { get; set; }

        public CardsListViewModel(INavigation navigation) : base(navigation)
        {
            CardsObserverList = new ObservableCollection<Card>();
            ShowMenuCommand = new Command(ShowAddingMenu);
            EditSelectedCardCommand = new Command(EditSelectedCard);
            DelSelectedCardCommand = new Command(DeleteSelectedCard);
        }

        public override Task OnAppearing()
        {
            CardsObserverList.Clear();
            foreach (var card in CardManager.Instance.CardsList)
            {
                CardsObserverList.Add(card);
            }
            return Task.CompletedTask;
        }

        private void DeleteSelectedCard()
        {
            if (SelectedCard != null)
            {
                CardsObserverList.Remove(SelectedCard);
                CardManager.Instance.CardsList.Remove(SelectedCard);
                SelectedCard = null;
            }
        }        

        private async void EditSelectedCard()
        {
            if (SelectedCard != null)
            {                              
                await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation,SelectedCard)));
                SelectedCard = null;
            }
        }

        private async void ShowAddingMenu()
        {
            await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation)));
        }
    }
}
