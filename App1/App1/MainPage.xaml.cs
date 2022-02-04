using App1.ViewModels;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            mainPageViewModel = new MainPageViewModel();
            this.BindingContext = mainPageViewModel;
        }
    }
}
