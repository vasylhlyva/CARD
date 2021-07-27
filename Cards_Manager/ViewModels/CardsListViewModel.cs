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
        private ICardManager cardManager;       

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

        public ICommand AddCardCommand { get; set; }
        public ICommand ShowTypeMenuCommand { get; set; }
        public ICommand EditSelectedCardCommand { get; set; }
        public ICommand DelSelectedCardCommand { get; set; }

        public CardsListViewModel(INavigation navigation, ICardManager cardManager) : base(navigation)
        {
            this.cardManager = cardManager;
            CardsObserverList = new ObservableCollection<Card>();
            AddCardCommand = new Command(ShowAddingMenu);
            ShowTypeMenuCommand = new Command(ShowTypeMenu);
            EditSelectedCardCommand = new Command(EditSelectedCard);
            DelSelectedCardCommand = new Command(DeleteSelectedCard);
        }

        public override Task OnAppearing()
        {
            CardsObserverList.Clear();
            foreach (var card in cardManager.CardsList)
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
                cardManager.DeleteCard(SelectedCard);
                SelectedCard = null;
            }
        }        

        private async void EditSelectedCard()
        {
            if (SelectedCard != null)
            {
                await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation,cardManager,SelectedCard)));
                SelectedCard = null;
            }
        }

        private async void ShowTypeMenu()
        {
            await Navigation.PushAsync(new TypeSelectPage(new CardTypeSelectViewModel(Navigation,cardManager)));//card type
            //await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation,cardManager)));
        }

        private async void ShowAddingMenu()
        {
            //await Navigation.PushAsync(new TypeSelectPage(new CardViewModel(Navigation, cardManager)));
            await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation,cardManager)));
        }
    }
}
