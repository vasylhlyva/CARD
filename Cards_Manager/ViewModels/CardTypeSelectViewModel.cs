using System.Collections.Generic;
using System.Windows.Input;
using Cards_Manager.Models;
using Cards_Manager.Views;
using Xamarin.Forms;
using Cards_Manager.Enums;

namespace Cards_Manager.ViewModels
{
    public class CardTypeSelectViewModel : BaseViewModel
    {
        public ICommand AddCardCommand { get; set; }
        private ICardManager cardManager;
        private CardTypeEnum selectedCardType;

        public List<CardTypeEnum> CardsTypeSourceList { get; set; }

        public CardTypeEnum SelectedCardType
        {
            get { return selectedCardType; }
            set { selectedCardType = value; }
        }

        public CardTypeSelectViewModel(INavigation navigation, ICardManager cardManager) : base(navigation)
        {
            this.cardManager = cardManager;
            CardsTypeSourceList = new List<CardTypeEnum>()
                {CardTypeEnum.CreditCard, CardTypeEnum.CryptoCard, CardTypeEnum.Ticket};
            AddCardCommand = new Command(ShowAddingMenu);
        }

        private Card GetCardByType(CardTypeEnum cardType)
        {
            switch (cardType)
            {
                case CardTypeEnum.CreditCard:
                    return new CreditCard();
                case CardTypeEnum.CryptoCard:
                    return new CryptoCard();
                case CardTypeEnum.Ticket:
                    return new Ticket();
                default:
                    return new Card();
            }
        }

        private async void ShowAddingMenu()
        {
            var card = GetCardByType(SelectedCardType);
            await Navigation.PushAsync(new CardPage(new CardViewModel(Navigation, cardManager, card)));
        }
    }
}