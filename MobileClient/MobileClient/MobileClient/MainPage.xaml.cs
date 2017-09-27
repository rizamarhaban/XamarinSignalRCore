using MobileClient.ViewModels;
using Xamarin.Forms;

namespace MobileClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Bind the View Model
            BindingContext = new MainPageViewModel();
        }
    }
}
