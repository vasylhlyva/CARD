using System;
using Cards_Manager.Models;
using System.ComponentModel;
namespace Cards_Manager.ViewModels
{
    public class CardViewModel : ImplementsINotifyPCh
    {
        
        CardsListViewModel CardsListViewModel;
        public Card card { get; set; }
        public CardViewModel()
        {
            card = new Card();
        }
        public CardsListViewModel ListViewModel
        {
            get { return CardsListViewModel; }
            set
            {
                if(CardsListViewModel != value){
                    CardsListViewModel = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
       
        public int Amount
        {
            get { return card.Amount; }
            set
            {
                card.Amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string Type
        {
            get { return card.Type; }
            set
            {
                card.Type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Name
        {
            get { return card.Name; }
            set
            {
                card.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
    public class ImplementsINotifyPCh : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string pName)
        {
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }
    }
}
