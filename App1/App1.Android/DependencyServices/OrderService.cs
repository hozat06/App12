using Android.Hardware.Display;
using Android.Views;
using App1.Droid.DependencyServices;
using App1.Models;
using App1.Services;
using App1.ViewModels;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(OrderService))]
namespace App1.Droid.DependencyServices
{
    public class OrderService : IOrderService
    {
        
        //public ArrayAdapter<OrderLine> arrayAdapter;
        public OrderCustomAdapter arrayAdapter;
        public DisplayManager displayManager = null;
        public Display[] presentationDisplays = null;
        SecondaryDisplay secondaryDisplay;

        public Order Order => MainPageViewModel._this.Order;

        public OrderPageType OrderPage { get; set; }

        public OrderService()
        {

            if (displayManager == null)
                displayManager = (DisplayManager)MainActivity.s_instance.GetSystemService(MainActivity.DisplayService);

            if (displayManager != null)
            {
                if (presentationDisplays == null)
                    presentationDisplays = displayManager.GetDisplays(DisplayManager.DisplayCategoryPresentation);
                
            }
        }        

        public void ShowDisplay()
        {
            if (presentationDisplays.Length > 0)
            {
                secondaryDisplay = new SecondaryDisplay(this, MainActivity.s_instance, presentationDisplays[0]);
                secondaryDisplay.Show();
            }
        }

        public void Refresh(int? index)
        {
            if (Order != null && secondaryDisplay!=null)
            {
                if (OrderPage == OrderPageType.Ad)
                    secondaryDisplay.ListRefreshAd(index ?? Order.Lines.Count - 1);
                else
                    secondaryDisplay.ListRefresh();
            }
        }
    }
}