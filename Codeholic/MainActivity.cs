using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System;
using Microsoft.Data.SqlClient;

namespace Codeholic
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener//, GestureDetector.IOnGestureListener
    {
        TextView textMessage;
        //internal bool isScrolling;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            Button LoginButton = FindViewById<Button>(Resource.Id.ButtonLogin);

            LoginButton.Click += OnLoginPress;

            Button LoginSkipButton = FindViewById<Button>(Resource.Id.ButtonSkipLogin);

            LoginSkipButton.Click += OnSkipLoginPress;

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    Intent Noahintent = new Intent(this, typeof(NoahActivity));
                    StartActivity(Noahintent);
                    return true;
                case Resource.Id.navigation_dashboard:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }

        public void OnLoginPress(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You logged in", ToastLength.Short).Show();

            Intent Noahintent = new Intent(this, typeof(NoahActivity));
            StartActivity(Noahintent);
        }

        public void OnSkipLoginPress(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You chose not to login", ToastLength.Short).Show();

            Intent Noahintent = new Intent(this, typeof(NoahActivity));
            StartActivity(Noahintent);
        }

    }
}

