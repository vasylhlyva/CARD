using System;
using Cards_Manager.Models;
using System.Windows.Input;
using Xamarin.Forms;
using Cards_Manager.Views;

namespace Cards_Manager.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        private Card card;
        private ICardManager cardManager;

        public Card Card
        {
            get => card;
            set
            {
                card = value;
                OnPropertyChanged(nameof(Card));
            }
        }

        public ICommand AddCardCommand { get; set; }
        public ICommand DeleteCardCommand { get; set; }
        public ICommand SaveCardCommand { get; set; }
        public ICommand GenerateCardNumberAndIdCommand { get; set; }
        public ICommand GenerateCardNumberCommand { get; set; }
        public ICommand ShowTypeMenuCommand { get; set; }

        public CardViewModel(INavigation navigation, ICardManager cardManager) : base(navigation)
        {
            this.cardManager = cardManager;
            SaveCardCommand = new Command(SaveCard);
            DeleteCardCommand = new Command(DeleteCard);
            GenerateCardNumberCommand = new Command(GenerateCardNumber);
            GenerateCardNumberAndIdCommand = new Command(GenerateCardNumberAndId);
            AddCardCommand = new Command(ShowAddingMenu);
            Card = new Card();
        }

        public CardViewModel(INavigation navigation, ICardManager cardManager, Card card) : this(navigation,
            cardManager)
        {
            Card = card;
        }

        public void GenerateCardNumberAndId()
        {
            GenerateCardId();
            GenerateCardNumber();
        }

        public void GenerateCardNumber()
        {
            Card.CardNumber = LongRandom(999999999, 9999999999, new Random());
        }

        public void GenerateCardId()
        {
            var random = new Random();
            Card.Id = random.Next(0, 99999999);
        }

        public void DeleteCard()
        {
            cardManager.DeleteCard(Card);
            Back();
        }

        public async void SaveCard()
        {
            cardManager.AddCardToList(Card);
            await NavigateToRootAsync();
        }

        public long LongRandom(long min, long max, Random random)
        {
            byte[] array = new byte[8];
            random.NextBytes(array);
            long longRand = BitConverter.ToInt64(array, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        private async void ShowAddingMenu()
        {
            //  Card sampleCard = GetCardType(CardTypeIndex);            
            await Navigation.PushAsync(new CardPage(this));
        }
    }
}