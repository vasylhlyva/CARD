using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using Cards_Manager.Views;
using System.Collections.ObjectModel;
using MySqlConnector;

namespace Cards_Manager.ViewModels
{
    public class CardsListViewModel : ImplementsINotifyPCh
    {
        public ObservableCollection<CardViewModel> CardsObserverList { get; set; }
        
        public ICommand AddCardCommand { set; get; }
        public ICommand DelCardCommand {  set; get; }
        public ICommand SaveCardCommand {  set; get; }
        public ICommand BackCommand { set; get; }
        public ICommand SaveToDbCommand { set; get; }
        public ICommand DelFromDbCommand { set; get; }
        CardViewModel SelectedCard;
        public INavigation Navigation { get; set; }
        
        public CardsListViewModel()
        {
            CardsObserverList = new ObservableCollection<CardViewModel>();
            OnPropertyChanged(nameof(CardsObserverList));
            DelFromDbCommand = new Command(DelFromDb);
            SaveToDbCommand = new Command(SaveToDb);
            AddCardCommand = new Command(AddCard);
            DelCardCommand = new Command(DeleteCard);
            
            BackCommand = new Command(Back);
        }

        private void DelFromDb(object Cardobj)
        {
            CardViewModel Card = Cardobj as CardViewModel;

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
            CardViewModel Card = Cardobj as CardViewModel;
            
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

        public CardViewModel SelectCard
        {
            get { return SelectedCard; }
            set
            {
                if (SelectedCard != value)
                {
                    CardViewModel temporarycard = value;
                    SelectCard = null;
                    OnPropertyChanged("Select Card");
                    Navigation.PushAsync(new CardPage(temporarycard));
                }
            }
            
        }
        public  void DeleteCard (object Cardobj)
        {
            CardViewModel Card = Cardobj as CardViewModel;
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
        
        private void AddCard()
        {
            Navigation.PushAsync(new CardPage(new CardViewModel()
            { ListViewModel = this }));
        }
    }
}
