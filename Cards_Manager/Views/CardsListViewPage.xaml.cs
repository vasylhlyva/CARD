using System;
using System.Collections.Generic;
using Cards_Manager.ViewModels;
using Xamarin.Forms;

namespace Cards_Manager.Views
{
    public partial class CardsListViewPage : ContentPage
    {
        private CardsListViewModel viewModel;

        public CardsListViewPage()
        {
            InitializeComponent();
            viewModel = new CardsListViewModel(this.Navigation);
            BindingContext = viewModel;            
        }        
        protected override async void OnAppearing()
        {
           await viewModel.OnAppearing();
        }
    }
}
