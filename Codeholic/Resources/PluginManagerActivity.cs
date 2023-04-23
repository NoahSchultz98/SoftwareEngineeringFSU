using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
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

        List<Codeholic.SQL.Plugin> plugins = new List<Codeholic.SQL.Plugin>();
        TextView statusText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.PluginManager);
            statusText = FindViewById<TextView>(Resource.Id.status);

            if (Extensions.ConnectedToDatabase())
                plugins = getDeveloperPlugins();
            else
            {
                plugins = new List<Codeholic.SQL.Plugin>();
                
                for(int i = 0; i < 5; i++)
                    plugins.Add(new Codeholic.SQL.Plugin(null));
            }

            ListPlugins(plugins);

        }

        void ListPlugins(List<Codeholic.SQL.Plugin> pluginsToList)
        {
            LinearLayout pluginManagerLayout = FindViewById<LinearLayout>(Resource.Id.PluginManager);

            if(Extensions.DEBUG_MODE)
            if (pluginManagerLayout == null)
                statusText.Text = "layout is not null";
            else
                statusText.Text = "signs point to pog";

            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
     LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent
  );
            foreach (Codeholic.SQL.Plugin plugin in pluginsToList)
            {
                TextView pluginName = new TextView(this);
                //pluginName.set
                pluginName.Text = plugin.name;// "holy guacamole";

                TextView pluginDescription = new TextView(this);
                pluginDescription.Text = plugin.description;

                CheckBox pluginIsActive = new CheckBox(this);
                pluginIsActive.Activated = plugin.available;
                UpdateCheckBoxText(pluginIsActive);
                pluginIsActive.Click += UpdatePluginAvailability;

                // add code for modifying/overwriting, add code for downloading


                //ExpandableListView expandableListView= new ExpandableListView(this);

                //ArrayAdapter adapter = new ArrayAdapter<string>(context)


                //expandableListView.AddView(pluginName);
                //expandableListView.AddView(pluginDescription); 
                //expandableListView.AddView(pluginIsActive);

                //pluginManagerLayout.AddView(expandableListView);

                //View divider = new View(this);
                //divider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 1);
                //divider.SetBackgroundColor(Android.Graphics.Color.DarkGray);
                

                //pluginName.LayoutParameters = layoutParams;
                //pluginDescription.LayoutParameters = layoutParams;

                // for some reason, pluginManagerLayout keeps being null
                //if(pluginManagerLayout != null)
                pluginManagerLayout.AddView(pluginName);
                pluginManagerLayout.AddView(pluginDescription);
                pluginManagerLayout.AddView(pluginIsActive);


                Button pluginDownload = new Button(this);
                Button pluginUpload = new Button(this);

                //LinearLayout.LayoutParams buttonParams = new LinearLayout.LayoutParams(0, LinearLayout.LayoutParams.WrapContent, 0);
                //pluginDownload.LayoutParameters = buttonParams;
                //pluginUpload.LayoutParameters = buttonParams;

                pluginDownload.Text = "Download Backup";
                pluginUpload.Text = "Modify/Overwrite Plugin";

                pluginManagerLayout.AddView(pluginDownload);
                pluginManagerLayout.AddView(pluginUpload);
                
            }
        }

        void UpdatePluginAvailability(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
                return;

            UpdateCheckBoxText(checkBox);
            
        }

        void UpdateCheckBoxText(CheckBox checkBox)
        {
            checkBox.Text = (checkBox.Checked) ? "Publicly Available" : "Not available";
        }

        /// <summary>
        /// Grabs all plugins associated with the plugin developer's userID and returns them as a list of plugins, or null
        /// </summary
        /// <returns></returns>
        List<Codeholic.SQL.Plugin> getDeveloperPlugins()
        {

            // database magic

            return null;

        }

    }
}