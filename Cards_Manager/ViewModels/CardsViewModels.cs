using System;
using Cards_Manager.Models;
using System.ComponentModel;
namespace Cards_Manager.ViewModels
{
    public class CardsViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        CardsListViewModel CardsLViewModel;
        public Card Card { get; set; }
        public CardsViewModels()
        {
            Card = new Card();
        }
        public CardsListViewModel ListViewModel
        {
            get { return CardsLViewModel; }
            set
            {
                if(CardsLViewModel != value){
                    CardsLViewModel = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }
        protected void OnPropertyChanged(string pName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }
        public int Amount
        {
            get { return Card.Amount; }
            set
            {
                Card.Amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string Type
        {
            get { return Card.Type; }
            set
            {
                Card.Type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Name
        {
            get { return Card.Name; }
            set
            {
                Card.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
