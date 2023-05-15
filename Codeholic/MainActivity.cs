using Android.App;
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
using static Android.Provider.ContactsContract.CommonDataKinds;

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
            //TestConn();
            //TestInsert();
            // for test:
            //getID();
        }

        private async void TestInsert()
        {
            string username = "a name8";
            string password = "a password6";
            string email = "an email6";
            
            string myQuery = "insert into user (userType, username, password, firstName, lastName, email) "
             + "values (0, '" + username + "', '" + password + "', 'BLANK', 'BLANK', '" + email + "');";


            var result = await DatabaseConnection.Query(myQuery);

            
            if (result != null)
                if (result.data == "false")
                {
                    Toast.MakeText(this, "That username is taken.", ToastLength.Short).Show();
                    return;
                }
                else
                {
                    Toast.MakeText(this, "Successfully registered user!", ToastLength.Short).Show();
                }
            

            
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
                    if(DatabaseConnection.currentUserType != UserType.pluginDeveloper)
                    {
                        Toast.MakeText(this, "You must be registered as a plugin developer to access the plugin management interface.", ToastLength.Long).Show();
                        return false;
                    }
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

