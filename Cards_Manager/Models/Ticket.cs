namespace Cards_Manager.Models
{
    public class Ticket : Card
    {
        private int discount;

        public int Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }

        public string ImagePath { get; set; }

        public Ticket()
        {
            ImagePath = nameof(Ticket);
        }
    }
}