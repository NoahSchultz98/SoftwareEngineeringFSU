﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.IO;
using Environment = System.Environment;
using File = System.IO.File;

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
            statusText.MovementMethod = new ScrollingMovementMethod();

            if (Extensions.ConnectedToDatabase())
                plugins = getDeveloperPlugins();
            else
            {
                plugins = new List<Codeholic.SQL.Plugin>();
                
                for(int i = 0; i < 5; i++)
                    plugins.Add(new Codeholic.SQL.Plugin(null));
            }

            ListPlugins(plugins);

            //Toast.MakeText(Android.App.Application.Context, Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, ToastLength.Long).Show();
            //Toast.MakeText(Android.App.Application.Context, "File exists: " + File.Exists(Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, "pluginData.txt")).ToString(), ToastLength.Long).Show();

        }

        async void ListPlugins(List<Codeholic.SQL.Plugin> pluginsToList)
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
            // here, we just replaced plugins to list with the list of plugins from getPluginsByCreator

            pluginsToList = await DatabaseConnection.GetPluginsByCreator(statusText);
            statusText.Text = "Found " + pluginsToList.Count().ToString() + " plugins belonging to user.";
            if(pluginsToList != null)
                foreach (Codeholic.SQL.Plugin plugin in pluginsToList)
                {
                    EditText pluginName = new EditText(this);
                    //pluginName.set
                    pluginName.Text = plugin.name;// "holy guacamole";
                    //pluginName.Id = plugin.pluginID;
                    EditText pluginDescription = new EditText(this);
                    pluginDescription.Text = plugin.description;

                    CheckBox pluginIsActive = new CheckBox(this);
                    pluginIsActive.Activated = (plugin.available > 0) ? true : false;
                    UpdateCheckBoxText(pluginIsActive);

                    pluginName.TextChanged += async (object sender, Android.Text.TextChangedEventArgs e) =>
                    {
                        await DatabaseConnection.UpdatePluginName(plugin.pluginID, pluginName.Text);
                    };

                    pluginDescription.TextChanged += async (object sender, Android.Text.TextChangedEventArgs e) =>
                    {
                        await DatabaseConnection.UpdatePluginDescription(plugin.pluginID, pluginDescription.Text);
                    };

                    pluginIsActive.Click += async (object sender, EventArgs e) =>
                    {
                        pluginIsActive.Activated = !pluginIsActive.Activated;
                        UpdateCheckBoxText(pluginIsActive);
                        await DatabaseConnection.UpdatePluginAvailability(plugin.pluginID, pluginIsActive.Checked);
                    };

                //DatabaseConnection.UpdatePluginName(1, pluginName.Text); };
                    
                        //pluginDescription.AfterTextChanged += UpdatePluginDescription;

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

                    pluginDownload.Click += async (object sender, EventArgs e) =>
                    {
                        SQL.Plugin foundPlugin = await DatabaseConnection.GetPluginByID(plugin.pluginID);

                        //serialize theData?
                        if(foundPlugin != null)
                        {
                            try
                            {
                                //Xamarin.Essentials.FilePicker.PickAsync(Xamarin.Essentials.PickOptions.Default);
                                //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "pluginData.txt");
                                string fileName = Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, "pluginData" + plugin.pluginID + ".txt");
                                //System.IO.File.Create(fileName);
                                //File.WriteAllText(fileName, plugin.pluginData); // well we'll see...

                                using (var writer = new StreamWriter(File.Create(fileName)))
                                {
                                    writer.Write(plugin.pluginData);
                                }
                            }
                            catch (Exception ex)
                            {
                                // oops
                                Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();
                            }
                        }
                    };

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

        void UpdatePluginName(object sender, EventArgs e)
        {
            //EditText pluginName = sender as EditText;
            //await DatabaseConnection.UpdatePluginName(pluginName.Id, pluginName.Text);

            //Toast.MakeText(Android.App.Application.Context, "Editing plugin name to " + pluginName.Text + "on pluginID " + pluginName.Id + "?", ToastLength.Long);
            Toast.MakeText(Android.App.Application.Context, "Test?", ToastLength.Long);
        }

        void UpdatePluginDescription(object sender, EventArgs e)
        {

        }

        void UpdateCheckBoxText(CheckBox checkBox)
        {
            checkBox.Checked = checkBox.Activated;
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