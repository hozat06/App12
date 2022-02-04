using Android.Content;
using Android.Views;
using Android.Widget;
using App1.Models;
using System.Collections.Generic;
using System.Linq;

namespace App1.Droid.DependencyServices
{
    public class OrderCustomAdapter : BaseAdapter
    {
        List<OrderLine> _orderLine;
        Context _context;

        public OrderCustomAdapter(Context context, List<OrderLine> orderLine)
        {
            _context = context;
            _orderLine = orderLine;
        }

        public override int Count
        {
            get
            {
                return _orderLine.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            OrderLine orderLine = _orderLine[position];
            convertView = LayoutInflater.From(_context).Inflate(Resource.Layout.listview_custom_row, null);
            TextView tvProductName = (TextView)convertView.FindViewById(Resource.Id.tvOrderDisplay_ProductName);
            TextView tvProductQuantity = (TextView)convertView.FindViewById(Resource.Id.tvOrderDisplay_Quantity);
            TextView tvProductPrice = (TextView)convertView.FindViewById(Resource.Id.tvOrderDisplay_Price);
            TextView tvProductTotal = (TextView)convertView.FindViewById(Resource.Id.tvOrderDisplay_Total);

            tvProductName.Text = _orderLine[position].Product?.Name;
            tvProductQuantity.Text = _orderLine[position].Quantity.ToString();
            tvProductPrice.Text = _orderLine[position].Price.ToString("N2");
            tvProductTotal.Text = _orderLine[position].Total.ToString("N2");

            return convertView;
        }
    }
}