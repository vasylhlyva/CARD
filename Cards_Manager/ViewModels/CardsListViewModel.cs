using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Cards_Manager.Views;
using System.Collections.ObjectModel;
using MySqlConnector;

namespace Cards_Manager.ViewModels
{
    public class CardsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardsViewModels> CardsObserverList { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddCardCommand { set; get; }
        public ICommand DelCardCommand {  set; get; }
        public ICommand SaveCardCommand {  set; get; }
        public ICommand BackCommand { set; get; }
        public ICommand SaveToDbCommand { set; get; }
        public ICommand DelFromDbCommand { set; get; }
        CardsViewModels SelectedCard;
        public INavigation Navigation { get; set; }
        protected void OnPropertyChanged(string pName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(pName));
        }
        public CardsListViewModel()
        {
            CardsObserverList = new ObservableCollection<CardsViewModels>();
            OnPropertyChanged(nameof(CardsObserverList));
            DelFromDbCommand = new Command(DelFromDb);
            SaveToDbCommand = new Command(SaveToDb);
            AddCardCommand = new Command(AddCard);
            DelCardCommand = new Command(DeleteCard);
            SaveCardCommand = new Command(SaveCard);
            BackCommand = new Command(Back);
        }

        private void DelFromDb(object Cardobj)
        {
            CardsViewModels Card = Cardobj as CardsViewModels;

            if (Card != null)
            {
                string CommandDb = "DELETE FROM `Cards` WHERE `Cards`.`Type` = @Type AND `Cards`.`Amount` = @Amount AND  `Cards`.`Name` = @name";

                DB dB = new DB();
                dB.OpenConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(CommandDb, dB.GetConnection());
                mySqlCommand.Parameters.Add("@Type", MySqlDbType.VarChar).Value = Card.Type;
                mySqlCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = Card.Name;
                mySqlCommand.Parameters.Add("@Amount", MySqlDbType.VarChar).Value = Card.Amount;

                mySqlCommand.ExecuteNonQuery();
                dB.CloseConnection();
            }
        }

        private void SaveToDb(object Cardobj)
        {
            CardsViewModels Card = Cardobj as CardsViewModels;
            
            if (Card != null)
            {
                string CommandDb = "INSERT INTO `Cards`(`Type`, `Name`, `Amount`) VALUES(@Type, @Name, @Amount)";

                DB dB = new DB();
                dB.OpenConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(CommandDb, dB.GetConnection());
                mySqlCommand.Parameters.Add("@Type",MySqlDbType.VarChar).Value = Card.Type;
                mySqlCommand.Parameters.Add("@Name", MySqlDbType.VarChar).Value = Card.Name;
                mySqlCommand.Parameters.Add("@Amount", MySqlDbType.VarChar).Value = Card.Amount;
                
                mySqlCommand.ExecuteNonQuery();
                dB.CloseConnection();
            }
        }

        public CardsViewModels SelectCard
        {
            get { return SelectedCard; }
            set
            {
                if (SelectedCard != value)
                {
                    CardsViewModels temporarycard = value;
                    SelectCard = null;
                    OnPropertyChanged("Select Card");
                    Navigation.PushAsync(new CardsPage(temporarycard));
                }
            }
            
        }
        public  void DeleteCard (object Cardobj)
        {
            CardsViewModels Card = Cardobj as CardsViewModels;
            if (Card != null)
            {
                foreach(var card in CardsObserverList)
                {
                    if(Card.Name != card.Name || Card.Amount != card.Amount)
                    {
                        continue;
                    }
                    CardsObserverList.Remove(card);
                    break;
                }

                //CardsObserverList.Remove(Card);
            }
            Back();
        }
        public async void Back()
        {
           await Navigation.PopAsync();
        }
        public void SaveCard(object Cardobj)
        {
            CardsViewModels Card = Cardobj as CardsViewModels;
            if (Card != null)
            {
                CardsObserverList.Add(Card);
            }
            Back();
        }
        private void AddCard()
        {
            Navigation.PushAsync(new CardsPage(new CardsViewModels()
            { ListViewModel = this }));
        }
    }
}
