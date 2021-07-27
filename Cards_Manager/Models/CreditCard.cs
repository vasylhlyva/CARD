using System;
namespace Cards_Manager.Models
{
    public class CreditCard : Card
    {
        private int credit;
        private string imagePath = nameof(CreditCard);
        public int CreditBalance
        {
            get { return credit; }
            set
            {
                credit = value;
                OnPropertyChanged(nameof(CreditBalance));
            }
        }

        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}
