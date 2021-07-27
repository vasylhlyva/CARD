using Cards_Manager.Models;
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
            viewModel = new CardsListViewModel(this.Navigation,new CardManager());
            BindingContext = viewModel;            
        }        
        protected override async void OnAppearing()
        {
           await viewModel.OnAppearing();
        }
    }
}
