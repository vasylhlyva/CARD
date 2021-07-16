using System;
using Cards_Manager.Models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Cards_Manager.Views;
using System.Threading.Tasks;

namespace Cards_Manager.ViewModels
{
    public class CardViewModel : BaseViewModel
    {
        private Card card;             

        public Card Card
        {
            get => card;
            set
            {
                card = value;
                OnPropertyChanged(nameof(Card));
            }
        }

        public ICommand DelCardCommand { get; set; }
        public ICommand SaveCardCommand { get; set; }
        public ICommand EditCardCommand { get; set; }
        //public ICommand SaveEditedCardCommand { get; set; }
        public ICommand GenerateIdCommand { get; set; }

        public CardViewModel(INavigation navigation, Card card = null) : base(navigation)
        {
            SaveCardCommand = new Command(SaveCard);
            DelCardCommand = new Command(DeleteCard);            
            //SaveEditedCardCommand = new Command(SaveEditedCard);
            GenerateIdCommand = new Command(GetId);            
            if (card != null)
            {
                Card = card;
            }
            else
            {
                Card = new Card();
            }
        }

        public void GetId()
        {
            var random = new Random();
            string createdStringForId = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                createdStringForId = String.Concat(createdStringForId, random.Next(10).ToString());
            }
            Card.Id = createdStringForId;
        }

        public void DeleteCard()
        {            
            CardManager.Instance.DeleteCard(Card);
            Back();
        }        

        /*public void SaveEditedCard()
        {            
            Back();
        }*/

        public void SaveCard()
        {
            CardManager.Instance.AddCardToList(Card);            
            Back();
        }
    }
}
