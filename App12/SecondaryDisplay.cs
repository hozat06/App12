using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace App12
{
    public class SecondaryDisplay : Presentation
    {
        private static SecondaryDisplay _this;
        ListView mainList;
        readonly Button btn;

        public SecondaryDisplay(Context outerContext, Display display) : base(outerContext, display)
        {
            _this = this;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_secondary_display);

            mainList = (ListView)FindViewById<ListView>(Resource.Id.listView1);
            Yenile();
        }

        public static void Yenile()
        {
            MainActivity.arrayAdapter = new ArrayAdapter<string>(Application.Context, Android.Resource.Layout.SimpleListItem1, MainActivity.ulkeler);
            _this.mainList.Adapter = MainActivity.arrayAdapter;
            MainActivity.arrayAdapter.NotifyDataSetChanged();
        }
        
    }
}