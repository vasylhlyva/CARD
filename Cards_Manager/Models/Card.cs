using System;
using System.Collections.Generic;
using Cards_Manager.ViewModels;

namespace Cards_Manager.Models
{
    public class Card : ImplementsINotifyPropertyChanged
    {
        private int amount;
        private string type;
        private string name;
        private string id;
        private string balanceType;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string BalanceType
        {
            get{ return balanceType; }
            set
            {
                balanceType = value;
                OnPropertyChanged(nameof(BalanceType));
            }
        }
    }
}
