namespace Cards_Manager.Models
{
    public class CryptoCard : Card
    {
        private int bitcoins;
        private string imagePath = nameof(CryptoCard);

        public int Balance
        {
            get { return bitcoins; }
            set
            {
                bitcoins = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public string ImagePath
        {
            get => imagePath;
            set => imagePath = value;
        }
    }
}