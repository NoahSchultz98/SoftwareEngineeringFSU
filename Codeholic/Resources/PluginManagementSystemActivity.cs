using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codeholic.Resources
{
    [Activity(Label = "Plugin Management System")]
    public class PluginManagementSystemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.PluginManagementSystem);
            Button pluginUploaderButton = FindViewById<Button>(Resource.Id.btnaccessUploader);
            pluginUploaderButton.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(Resources.PluginUploaderActivity));
                StartActivity(nextActivity);
            };
            Button pluginManagerButton = FindViewById<Button>(Resource.Id.btnmanagePlugins);
            pluginManagerButton.Click += delegate
            {
                Intent nextActivity = new Intent(this, typeof(Resources.PluginManagerActivity));
                StartActivity(nextActivity);
            };


            /*
            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            */
        }



    }
}
