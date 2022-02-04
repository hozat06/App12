using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using App1.Droid.DependencyServices;
using App1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace App1.Droid
{

    public class SecondaryDisplay : Presentation
    {
        private readonly OrderService _orderService;

        private ListView mainList;
        private TextView tvOrderDisplay_Total,
                         tvOrderDisplayAd_ProductName, 
                         tvOrderDisplayAd_Quantity, 
                         tvOrderDisplayAd_Price,
                         tvOrderDisplayAd_Total;
        private ImageView imageView1, imageViewAd;


        public SecondaryDisplay(OrderService orderService, 
            Context outerContext, Display display) : base(outerContext, display)
        {
            this._orderService = orderService;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (_orderService.OrderPage == Services.OrderPageType.Ad)
            {
                SetContentView(Resource.Layout.activity_secondary_display_ad);
                tvOrderDisplayAd_ProductName = FindViewById<TextView>(Resource.Id.tvOrderDisplayAd_ProductName);
                tvOrderDisplayAd_Quantity = FindViewById<TextView>(Resource.Id.tvOrderDisplayAd_Quantity);
                tvOrderDisplayAd_Price = FindViewById<TextView>(Resource.Id.tvOrderDisplayAd_Price);
                tvOrderDisplayAd_Total = FindViewById<TextView>(Resource.Id.tvOrderDisplayAd_Total);
                imageViewAd = FindViewById<ImageView>(Resource.Id.imageViewAd);

                new CustomCountDownTimer(this.imageViewAd, 60000, 5000).Start();
            }
            else
            {
                SetContentView(Resource.Layout.activity_secondary_display);
                mainList = FindViewById<ListView>(Resource.Id.listView1);
                tvOrderDisplay_Total = FindViewById<TextView>(Resource.Id.tvOrderDisplay_Total);
                imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);

                ListRefresh();
            }
        }

        public void ListRefresh()
        {
            if (_orderService.Order == null)
                return;

            ListView mainList = FindViewById<ListView>(Resource.Id.listView1);
            TextView tvOrderDisplay_Total = FindViewById<TextView>(Resource.Id.tvOrderDisplay_Total);
            ImageView imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);

            var list = _orderService.Order.Lines.ToList();
            tvOrderDisplay_Total.Text = list.Sum(x => x.Total).ToString("N2");

            _orderService.arrayAdapter = new OrderCustomAdapter(
                Application.Context,
                list);

            mainList.Adapter = _orderService.arrayAdapter;
            _orderService.arrayAdapter.NotifyDataSetChanged();
        }

        public void ListRefreshAd(int index)
        {
            if (_orderService.Order == null)
                return;

            
            var list = _orderService.Order.Lines.ToList();
            tvOrderDisplayAd_Total.Text = list.Sum(x => x.Total).ToString("N2");

            var orderLine = list[index];

            tvOrderDisplayAd_ProductName.Text = orderLine.Product?.Name;
            tvOrderDisplayAd_Quantity.Text = orderLine.Quantity.ToString();
            tvOrderDisplayAd_Price.Text = String.Format("{0:N2} = {1:N2}", orderLine.Price, orderLine.Total);
        }

    }
}