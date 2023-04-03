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
    [Activity(Label = "Plugin Manager")]
    public class PluginManagerActivity : Activity
    {
        /*
         * Class provides backend functionality 
         * 
         * Require:
         * LINQ to SQL (poll database)
         * 
         * Plugin management/uploader methods:
         * Upload new plugin
         * Modify existing plugin
         * Change availability of existing plugin
         * 
         * (plugin class? likely)
         * 
         * Get Plugins(userCredentials) returns List<Plugin>
         * 
        */
    }
}