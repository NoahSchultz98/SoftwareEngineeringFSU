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
using System.Linq;
//using System.Data.Entity;

namespace Codeholic
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener//, GestureDetector.IOnGestureListener
    {
        TextView textMessage;
        EditText nameInput;
        EditText passInput;
        internal bool isScrolling;

        protected override void OnCreate(Bundle savedInstanceState)
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

            Button SignUpButton = FindViewById<Button>(Resource.Id.ButtonSignUp);

            SignUpButton.Click += OnSignUpPress;

            nameInput = FindViewById<EditText>(Resource.Id.enterUser);
            passInput = FindViewById<EditText>(Resource.Id.enterPass);

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
                    //textMessage.SetText(Resource.String.title_home);
                    Intent Noahintent = new Intent(this, typeof(NoahActivity));
                    StartActivity(Noahintent);
                    return true;
                case Resource.Id.navigation_dashboard:
                    //textMessage.SetText(Resource.String.title_dashboard);
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

        public void OnSignUpPress(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "You logged in", ToastLength.Short).Show();

            Intent SignupIntent = new Intent(this, typeof(SignUpActivity));
            StartActivity(SignupIntent);
        }

        public async void OnLoginPress(object sender, EventArgs e)
        {

            string username = nameInput.EditableText.ToString();
            string password = passInput.EditableText.ToString();

            //Boolean condition = username == "username" && password == "password";
            //string connection = "temporary value";

            string myQuery = "select * from user where username = '" + username + "'";
            myQuery += " and password = '" + password + "';";

            string ex = "unassigned";

            try
            { // try to login

                var result = await DatabaseConnection.Query(myQuery);
                Toast.MakeText(this, result.data, ToastLength.Short).Show();
                
                if (result != null && result.data == "false")
                { // if result is false the username is taken
                    Toast.MakeText(this, "query failed", ToastLength.Short).Show();
                    return;
                }
                else if (result == null)
                { // if the result is null the query did something weird
                    Toast.MakeText(this, "NULL RESULT", ToastLength.Short).Show();
                    return;
                }
                
                ex = result.data;

                User user = JsonSerializer.Deserialize<User>(result.data);
                
                DatabaseConnection.currentUser = user;

                //Toast.MakeText(this, "You logged in", ToastLength.Short).Show();

                Intent Noahintent = new Intent(this, typeof(NoahActivity));
                StartActivity(Noahintent);
            }
            catch { // catch when invalid
                    
                Toast.MakeText(this, "Incorrect Username or Password", ToastLength.Short).Show();
            }
            
        }

        public void OnSkipLoginPress(object sender, EventArgs e)
        {
            Toast.MakeText(this, "You chose not to login", ToastLength.Short).Show();

            /*
            User user = new User(); //= JsonSerializer.Deserialize<User>(result.data);

            user.userType = 0;
            user.firstName = "Guest";
            user.lastName = "Guest";
            user.userID = 99;
            user.email = "NONE";

            DatabaseConnection.currentUser = user;
            */
            Intent Noahintent = new Intent(this, typeof(NoahActivity));
            StartActivity(Noahintent);
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

