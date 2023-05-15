using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
//using AndroidX.AppCompat.App;
using AndroidX.AppCompat.App;
using Codeholic.Resources;
using Codeholic.SQL;
//using Google.Android.Material.BottomNavigation;
using Google.Android.Material.BottomNavigation;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.ViewTreeObserver;

namespace Codeholic
{
    [Activity(Label = "Coding Time", Theme = "@style/AppTheme")]
    public class NoahActivity : MainActivity, /*AppCompatActivity,*/  BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        //int view = Resource.Layout.layout1;

        // login information

        private EditText editTextWindow;
        private TextView lineNumbers;
        private ScrollView scrollView;
        private bool isScrolling = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //base.OnCreate(savedInstanceState);
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.layout1);

            editTextWindow = FindViewById<EditText>(Resource.Id.editTextWindow);
            lineNumbers = FindViewById<TextView>(Resource.Id.lineNumbers);

            Button ButtonSave = FindViewById<Button>(Resource.Id.ButtonSave);
            Button ButtonLogout = FindViewById<Button>(Resource.Id.ButtonLogout);

            ButtonSave.Click += OnSavePress;
            ButtonLogout.Click += OnLogoutPress;

            editTextWindow.AddTextChangedListener(new MyTextWatcher(this));//

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            UpdateLineNumbers(1);

        }

        public new bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    //textMessage.SetText(Resource.String.title_home);
                    Intent Noahintent = new Intent(this, typeof(NoahActivity));
                    StartActivity(Noahintent);
                    return true;
                case Resource.Id.navigation_dashboard:
                    //textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    if (DatabaseConnection.currentUserType != UserType.pluginDeveloper)
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

        public void UpdateLineNumbers(int linesLength)
        {
            //string[] lines = lineNumbers.Text.Split('\n');
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 1; i <= linesLength/*lines.Length*/; i++)
            {
                sb.Append(i).Append("\n");
            }
            lineNumbers.Text = sb.ToString();
        }


        public void OnSavePress(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Save Clicked", ToastLength.Short).Show();

        }

        public void OnLogoutPress(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Logout Clicked", ToastLength.Short).Show();

        }

        private class MyOnScrollChangedListener : Java.Lang.Object, ViewTreeObserver.IOnScrollChangedListener
        {
            private NoahActivity activity;

            public MyOnScrollChangedListener(NoahActivity activity)
            {
                this.activity = activity;
            }

            public void OnScrollChanged()
            {
                activity.isScrolling = true;

                return;

            }
        }
        

        private class MyTextWatcher : Java.Lang.Object, ITextWatcher
        {
            private NoahActivity activity;

            private bool lineCheck;
            private int newLineCount = 0;
        
            public MyTextWatcher(NoahActivity activity)
            {
                this.activity = activity;
            }
        
            public void AfterTextChanged(IEditable s)
            {
                if (lineCheck)
                {
                    activity.UpdateLineNumbers(newLineCount);
                }

                return;
            }

            public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
            {
                newLineCount = 0;
                lineCheck = false;

                for (int i = 0; i < s.Length(); i++)
                {
                    if (s.CharAt(i) == '\n')
                    {
                        newLineCount += 1;
                    }
                }

            }
        
            public void OnTextChanged(ICharSequence s, int start, int before, int count)
            {
                int tempNLCount = 0;

                for (int i = 0; i < s.Length(); i++)
                {
                    if (s.CharAt(i) == '\n')
                    {
                        tempNLCount += 1;

                    }
                }

                if (tempNLCount != newLineCount)
                {
                    lineCheck = true;
                    newLineCount = tempNLCount;
                }

                return;
            }
        }
        
    }
}


   