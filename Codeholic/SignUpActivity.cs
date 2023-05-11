using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeholic
{
    [Activity(Label = "Activity1")]
    public class SignUpActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here

            SetContentView(Resource.Layout.signUpPage);


            Button Submit = FindViewById<Button>(Resource.Id.ButtonSubmit);

            Submit.Click += OnSubmitPress;

        }

        public void OnSubmitPress(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "You logged in", ToastLength.Short).Show();

            Intent Noahintent = new Intent(this, typeof(NoahActivity));
            StartActivity(Noahintent);
        }
    }
}