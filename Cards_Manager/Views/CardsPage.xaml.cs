using System;
using System.Collections.Generic;
using Cards_Manager.ViewModels;

using Xamarin.Forms;

namespace Cards_Manager.Views
{
    public partial class CardsPage : ContentPage
    {
        public CardsViewModels viewModels { get; set; }

        public CardsPage(CardsViewModels cardsView)
        {
            InitializeComponent();
            viewModels = cardsView;
            this.BindingContext = viewModels;
            
        }
    }
}
