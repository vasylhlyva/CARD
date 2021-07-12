using System;
using System.Collections.Generic;
using Cards_Manager.ViewModels;
using Xamarin.Forms;

namespace Cards_Manager.Views
{
    public partial class CardsListViewPage : ContentPage
    {
        public CardsListViewPage()
        {
            InitializeComponent();
            BindingContext = new CardsListViewModel() { Navigation = this.Navigation };
        }
    }
}
