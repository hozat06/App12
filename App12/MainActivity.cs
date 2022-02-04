using Android.App;
using Android.Content;
using Android.Hardware.Display;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.ObjectModel;

namespace App12
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public DisplayManager displayManager = null;
        public Display[] presentationDisplays = null;
        public static ArrayAdapter<string> arrayAdapter;
        public static ObservableCollection<string> ulkeler = new ObservableCollection<string>
        {
            "Türkiye", "Almanya", "Avusturya", "Amerika","İngiltere"
        };

        Button btn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            displayManager = (DisplayManager)GetSystemService(Context.DisplayService);
            if (displayManager != null)
            {
                presentationDisplays = displayManager.GetDisplays(DisplayManager.DisplayCategoryPresentation);
                if (presentationDisplays.Length > 0)
                {
                    
                    btn=FindViewById<Button>(Resource.Id.btn);
                    btn.Click += btnClick;

                    SecondaryDisplay secondaryDisplay = 
                        new SecondaryDisplay(this, presentationDisplays[0]);
                    secondaryDisplay.Show();
                }
            }
        }

        private void btnClick(object sender, System.EventArgs e)
        {
            ulkeler.Insert(0,"Çin");
            //arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, ulkeler);

            SecondaryDisplay.Yenile();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}