using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Codeholic.Resources;
using Codeholic.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using static Android.Provider.Contacts.Intents;

namespace Codeholic
{
    [Activity(Label = "Activity1")]
    public class SignUpActivity : Activity
    {

        EditText nameInput;
        EditText passInput;
        EditText emailInput;
        TextView textMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            SetContentView(Resource.Layout.signUpPage);

            nameInput = FindViewById<EditText>(Resource.Id.userName);
            passInput = FindViewById<EditText>(Resource.Id.userPass);
            emailInput = FindViewById<EditText>(Resource.Id.userEmail);

            Button Submit = FindViewById<Button>(Resource.Id.ButtonSubmit);

            Submit.Click += OnSubmitPress;

        }

        public async void OnSubmitPress(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "You logged in", ToastLength.Short).Show();

            string username = nameInput.EditableText.ToString();
            string password = passInput.EditableText.ToString();
            string email  = emailInput.EditableText.ToString();

            if ((string.Compare(username, "") == 0) | (string.Compare(password, "") == 0) | (string.Compare(email, "") == 0)) {
                Toast.MakeText(this, "Please enter a value in all fields", ToastLength.Short).Show();
                return;
            }


            string myQuery = "insert into user (userType, username, password, firstName, lastName, email) ";
            myQuery += "values (1, '"+ username +"', '"+ password+"', 'BLANK', 'BLANK', '"+email+"');";

            // insert into the database 
            var result = await DatabaseConnection.Query(myQuery);

            if (result != null && result.data == "false")
            { // if result is false the username is taken
                Toast.MakeText(this, "That username is taken", ToastLength.Short).Show();
                return;
            }
            else if (result == null) { // if the result is null the query did something weird
                Toast.MakeText(this, "NULL RESULT", ToastLength.Short).Show();
                return;
            }

            // test to see if the query was successful 

            Toast.MakeText(this, "You have made an account!", ToastLength.Short).Show();

            Intent SignInActivity = new Intent(this, typeof(MainActivity));
            StartActivity(SignInActivity);

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
                    textMessage.Text = "Plugin Manager"; // just a hack for now
                    // code to begin new activity
                    Intent nextActivity = new Intent(this, typeof(Resources.PluginManagementSystemActivity));
                    StartActivity(nextActivity);
                    return true;
            }
            return false;
        }
        
    }
}