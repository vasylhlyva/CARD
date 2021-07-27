using System.Threading.Tasks;
using System.Windows.Input;
using Cards_Manager.Implementations;
using Xamarin.Forms;

namespace Cards_Manager.ViewModels
{
    public class BaseViewModel : ImplementsINotifyPropertyChanged
    {
        public INavigation Navigation { get; }
        public ICommand BackCommand { get; }

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
            BackCommand = new Command(Back);
        }

        public virtual Task OnAppearing() => Task.CompletedTask;

        public virtual Task OnDisappearing() => Task.CompletedTask;

        public async void Back()
        {
            await Navigation.PopAsync();
        }

        public async Task NavigateToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }
    }
}