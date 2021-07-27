using System;
using System.Collections.Generic;
using Cards_Manager.Implementations;
using Cards_Manager.ViewModels;

namespace Cards_Manager.Models
{    
    public class Card : ImplementsINotifyPropertyChanged
    {
        private string name;
        private long? cardNumber = null;        
        private int? id = null;        

        public long? CardNumber
        {
            get { return cardNumber; }
            set
            {
                if (cardNumber == null) {
                    cardNumber = value;
                    OnPropertyChanged(nameof(CardNumber));
                }                
            }
        }

        public int? Id
        {
            get { return id; }
            set
            {
                if(id == null)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
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


    }
}
