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
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Codeholic.Resources.Extensions;
using static Android.Bluetooth.BluetoothClass;
using System.Net;
using Codeholic.Resources;
using Codeholic.SQL;
using System.Text.Json;

namespace Codeholic
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener//, GestureDetector.IOnGestureListener
    {
        TextView textMessage;
        //internal bool isScrolling;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            Button pickFile = FindViewById<Button>(Resource.Id.btnPickFile);
            pickFile.Click += PickFile_Click;
#if DEBUG
            // During development, we can trust all certificates, including ASP.NET developer certificates
            // DO NOT ENABLE THIS IN RELEASE BUILDS
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (_, __, ___, ____) => true;
#endif
            TestConn();
            // for test:
            //getID();

            Button LoginButton = FindViewById<Button>(Resource.Id.ButtonLogin);

            LoginButton.Click += OnLoginPress;

            Button LoginSkipButton = FindViewById<Button>(Resource.Id.ButtonSkipLogin);

            LoginSkipButton.Click += OnSkipLoginPress;

        }

        private async void TestConn()
        {
            Codeholic.Resources.WebResponse response = await DatabaseConnection.Query("SELECT * FROM user WHERE userID = 1");



            SQL.User theUserFound = JsonSerializer.Deserialize<User>(response.data);
            Toast.MakeText(Android.App.Application.Context, "Greetings from " + theUserFound.username, ToastLength.Long).Show();
            //Toast.MakeText(Android.App.Application.Context, response.data, ToastLength.Long).Show();
            //DatabaseConnection.GetUserInfo();
        }

        private void PickFile_Click(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await PickAndShow(PickOptions.Images);
            });
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
                // when we click the home, dash, notifications button, it just changes the text message. okay. simple enough. we can make mine open up the plugin manager.
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    Intent Noahintent = new Intent(this, typeof(NoahActivity));
                    StartActivity(Noahintent);
                    return true;
                case Resource.Id.navigation_dashboard:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.Text = "Plugin Manager"; // just a hack for now
                    // code to begin new activity
                    Intent nextActivity = new Intent(this, typeof(Resources.PluginManagementSystemActivity));
                    StartActivity(nextActivity);
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

        //internal virtual void UpdateLineNumbers();


        /*
        private void Button_Clicked(object sender, EventArgs e)
        {
            FilePicker.PickAsync();

        }
        */
        /*
        public void OnClick(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.btnPickFile:
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await PickAndShow(PickOptions.Images);
                    });
                    break;
            }
        }

        public void ButtonClicked(View view)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await PickAndShow(PickOptions.Images);
            });
        }

        
    }
        */
        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    textMessage.Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        //FileImage.Source = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
                _ = ex;
            }

            return null;
        }
    }
}

=======
﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Codeholic.Resources.Extensions;
using static Android.Bluetooth.BluetoothClass;
using System.Net;
using Codeholic.Resources;
using Codeholic.SQL;
using System.Text.Json;

namespace Codeholic
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            Button pickFile = FindViewById<Button>(Resource.Id.btnPickFile);
            pickFile.Click += PickFile_Click;
#if DEBUG
            // During development, we can trust all certificates, including ASP.NET developer certificates
            // DO NOT ENABLE THIS IN RELEASE BUILDS
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (_, __, ___, ____) => true;
#endif
            TestConn();
            // for test:
            //getID();
        }

        private async void TestConn()
        {
            Codeholic.Resources.WebResponse response = await DatabaseConnection.Query("SELECT * FROM user WHERE userID = 1");



            SQL.User theUserFound = JsonSerializer.Deserialize<User>(response.data);
            Toast.MakeText(Android.App.Application.Context, "Greetings from " + theUserFound.username, ToastLength.Long).Show();
            //Toast.MakeText(Android.App.Application.Context, response.data, ToastLength.Long).Show();
            //DatabaseConnection.GetUserInfo();
        }

        private void PickFile_Click(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await PickAndShow(PickOptions.Images);
            });
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
                // when we click the home, dash, notifications button, it just changes the text message. okay. simple enough. we can make mine open up the plugin manager.
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.Text = "Plugin Manager"; // just a hack for now
                    // code to begin new activity
                    Intent nextActivity = new Intent(this, typeof(Resources.PluginManagementSystemActivity));
                    StartActivity(nextActivity);
                    return true;
            }
            return false;
        }

        /*
        private void Button_Clicked(object sender, EventArgs e)
        {
            FilePicker.PickAsync();

        }
        */
        /*
        public void OnClick(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.btnPickFile:
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await PickAndShow(PickOptions.Images);
                    });
                    break;
            }
        }

        public void ButtonClicked(View view)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await PickAndShow(PickOptions.Images);
            });
        }

        
    }
        */
        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    textMessage.Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        //FileImage.Source = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
                _ = ex;
            }

            return null;
        }
    }
}

>>>>>>> 0ab5a17... plugin manager and plugin uploader both functional (pull data from DB and populate fields, update DB when fields are changed). added DatabaseConnection.cs for sending SQL queries.
