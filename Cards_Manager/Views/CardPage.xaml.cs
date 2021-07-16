using System;
using System.Collections.Generic;
using Cards_Manager.Models;
using Cards_Manager.ViewModels;
using Xamarin.Forms;

namespace Cards_Manager.Views
{
    public partial class CardPage : ContentPage
    {
        public CardPage(CardViewModel cardsView)
        {
            InitializeComponent();
            this.BindingContext = cardsView;            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
