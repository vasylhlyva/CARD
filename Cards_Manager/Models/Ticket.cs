using System;
namespace Cards_Manager.Models
{
    public class Ticket : Card
    {
        private int discount;
        private string imagePath = nameof(Ticket);
        public int Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged(nameof(Discount));
            }
        }

        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}
