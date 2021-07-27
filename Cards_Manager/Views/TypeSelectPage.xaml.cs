using Cards_Manager.ViewModels;
using Xamarin.Forms;

namespace Cards_Manager.Views
{
    public partial class TypeSelectPage : ContentPage
    {
        /*public TypeSelectPage(CardViewModel cardsView)
        {
            InitializeComponent();
            this.BindingContext = cardsView;
        }*/

        public TypeSelectPage(CardTypeSelectViewModel cardsView)
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
