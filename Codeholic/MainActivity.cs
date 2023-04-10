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
            //string connectionString;
            //SqlConnection con;

            //connectionString = @"Data Source=WIN-50GP30FGO75;Initial Catalog=Demodb;User ID=sa;Password=demol23";

            //con = new SqlConnection(connectionString);
            //SetContentView(Resource.Layout.layout1);
            // CHECK THE DATA BASE PLEASE 
            // LOGIN IF THAT SHIT IS YUMMY

            //con.Open();
            //MessageBox.Show("Connection Open  !");

            Toast.MakeText(this, "You loggin in", ToastLength.Short).Show(); // send an alert when you login

            //con.Close();
        }
    }
}

