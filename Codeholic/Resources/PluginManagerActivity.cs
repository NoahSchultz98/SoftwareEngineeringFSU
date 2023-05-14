using Android.App;
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
using AndroidX.CardView.Widget;
using Xamarin.Essentials;
using Xamarin.Forms;

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
                    plugins.Add(new Codeholic.SQL.Plugin());
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
            bool firstLoop = true;
            if(pluginsToList != null)
                foreach (Codeholic.SQL.Plugin plugin in pluginsToList)
                {
                    // i think that we might want to just add a button in the cardview

                    CardView cardView = new CardView(Android.App.Application.Context);
                    cardView.Elevation = 4;
                    cardView.Radius = 5;
                    cardView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

                    Android.Widget.Button expandButton = new Android.Widget.Button(this);

                    expandButton.Text = plugin.name;

                    expandButton.SetBackgroundColor(Android.Graphics.Color.Gray);
                    expandButton.SetTextColor(Android.Graphics.Color.White);
                    //expandButton.SetTextAppearance(this, Android.Resource.Style.TextAppearanceDeviceDefaultWidgetActionBarTitle);

                    LinearLayout cardLayout = new LinearLayout(Android.App.Application.Context);
                    cardLayout.Orientation = Orientation.Vertical;
                    EditText pluginName = new EditText(this);
                    //pluginName.set
                    pluginName.Text = plugin.name;// "holy guacamole";
                    //pluginName.Id = plugin.pluginID;
                    EditText pluginDescription = new EditText(this);
                    pluginDescription.Text = plugin.description;

                    Android.Widget.CheckBox pluginIsActive = new Android.Widget.CheckBox(this);

                    // file select 1 & 2 
                    Android.Widget.Button pluginDownload = new Android.Widget.Button(this);
                    Android.Widget.Button pluginUpload = new Android.Widget.Button(this);

                    pluginDownload.Text = "Download Plugin Backup";
                    pluginUpload.Text = "Modify/Overwrite Plugin";


                    Android.Widget.Button helpdocDownload = new Android.Widget.Button(this);
                    Android.Widget.Button helpdocUpload = new Android.Widget.Button(this);

                    helpdocDownload.Text = "Download Help Doc Backup";
                    helpdocUpload.Text = "Modify/Overwrite Help Doc";

                    Android.Widget.Button fileSelectButton = new Android.Widget.Button(this);
                    fileSelectButton.Text = "Select Plugin File";

                    Android.Widget.Button helpDocFileSelectButton = new Android.Widget.Button(this);
                    helpDocFileSelectButton.Text = "Select Help Doc File";

                    TextView selectedFileText = new TextView(this);
                    selectedFileText.Text = "Selected Plugin File Will Appear Here";

                    TextView selectedHelpDocText = new TextView(this);
                    selectedHelpDocText.Text = "Selected Help Doc File Will Appear Here";

                    FileResult selectedFile = null;
                    FileResult selectedHelpDocFile = null;

                    fileSelectButton.Click += async (object sender, EventArgs e) =>
                    {
                        var result = await Extensions.PickFile();
                        if (result != null)
                        {
                            selectedFileText.Text = result.FileName;
                            // find a way to have pluginUpload upload this file/overwrite on click! 
                            selectedFile = result;
                        }
                        else
                            selectedFile = null;

                    };

                    helpDocFileSelectButton.Click += async (object sender, EventArgs e) =>
                    {
                        var result = await Extensions.PickFile();
                        if (result != null)
                        {
                            selectedHelpDocText.Text = result.FileName;
                            // find a way to have pluginUpload upload this file/overwrite on click! 
                            selectedHelpDocFile = result;
                        }
                        else
                            selectedHelpDocFile = null;

                    };

                    pluginUpload.Click += async (object sender, EventArgs e) =>
                    {
                        if(selectedFile == null)
                        {
                            // send a message that it needs to not be null!
                            Toast.MakeText(Android.App.Application.Context, "Please select a file first!", ToastLength.Long).Show();
                            return;
                        }
                        // alert the user that they are about to overwrite file 
                        //var result = await p.DisplayActionSheet("Overwrite plugin?", "No", null, "Yes");
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Overwrite Plugin?"); 
                        alert.SetPositiveButton("Yeah, let's do it", async (senderAlert, args) => {
                            
                            string updatedPluginData = File.ReadAllText(selectedFile.FullPath);

                            var result = await DatabaseConnection.UpdatePluginData(plugin.pluginID, updatedPluginData);
                            if (result)
                            {
                                Toast.MakeText(Android.App.Application.Context, "Successfully updated plugin data.", ToastLength.Long).Show();
                            }
                            else
                            {
                                Toast.MakeText(Android.App.Application.Context, "Failed to update plugin data.", ToastLength.Long).Show();
                            }

                        }); 
                        alert.SetNegativeButton("No thanks", (senderAlert, args) => {
                            //perform your own task for this conditional button click
                        });
                        RunOnUiThread (() => { alert.Show(); });
                    };

                    helpdocUpload.Click += async (object sender, EventArgs e) =>
                    {
                        if (selectedHelpDocFile == null)
                        {
                            // send a message that it needs to not be null!
                            Toast.MakeText(Android.App.Application.Context, "Please select a file first!", ToastLength.Long).Show();
                            return;
                        }
                        // alert the user that they are about to overwrite file 
                        //var result = await p.DisplayActionSheet("Overwrite plugin?", "No", null, "Yes");
                        AlertDialog.Builder alert = new AlertDialog.Builder(this);
                        alert.SetTitle("Overwrite Help Doc Data?");
                        alert.SetPositiveButton("Yeah, let's do it", async (senderAlert, args) => {

                            string updatedHelpDocData = File.ReadAllText(selectedHelpDocFile.FullPath);

                            var result = await DatabaseConnection.UpdateHelpDocData(plugin.pluginID, updatedHelpDocData);
                            if (result)
                            {
                                Toast.MakeText(Android.App.Application.Context, "Successfully updated help doc data.", ToastLength.Long).Show();
                            }
                            else
                            {
                                Toast.MakeText(Android.App.Application.Context, "Failed to update help doc data.", ToastLength.Long).Show();
                            }

                        });
                        alert.SetNegativeButton("No thanks", (senderAlert, args) => {
                            //perform your own task for this conditional button click
                        });
                        RunOnUiThread(() => { alert.Show(); });
                    };

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


                    void SetVisibility(ViewStates viewState)
                    {

                        pluginName.Visibility = viewState;
                        pluginDescription.Visibility = viewState;
                        pluginIsActive.Visibility = viewState;
                        pluginDownload.Visibility = viewState;
                        pluginUpload.Visibility = viewState;
                        helpdocDownload.Visibility = viewState;
                        helpdocUpload.Visibility = viewState;
                        helpDocFileSelectButton.Visibility = viewState;
                        selectedHelpDocText.Visibility = viewState;
                        fileSelectButton.Visibility = viewState;
                        selectedFileText.Visibility = viewState;
                    }

                    expandButton.Click += (object sender, EventArgs e) =>
                    {
                        if(pluginName.Visibility == ViewStates.Visible)
                            SetVisibility(ViewStates.Gone);
                        else
                            SetVisibility(ViewStates.Visible);
                        
                    };
                    
                    if(firstLoop)
                        firstLoop= false;
                    else
                        SetVisibility(ViewStates.Gone);
                    
                    cardLayout.AddView(expandButton);
                    cardLayout.AddView(pluginName);
                    cardLayout.AddView(pluginDescription);
                    cardLayout.AddView(pluginIsActive);
                    cardLayout.AddView(pluginDownload);
                    cardLayout.AddView(fileSelectButton);
                    cardLayout.AddView(selectedFileText);
                    cardLayout.AddView(pluginUpload);
                    cardLayout.AddView(helpdocDownload);
                    cardLayout.AddView(helpDocFileSelectButton);
                    cardLayout.AddView(selectedHelpDocText);
                    cardLayout.AddView(helpdocUpload);
                    cardView.AddView(cardLayout);
                    pluginManagerLayout.AddView(cardView);
                    //pluginManagerLayout.AddView(pluginName);
                    //pluginManagerLayout.AddView(pluginDescription);
                    //pluginManagerLayout.AddView(pluginIsActive);
                    //pluginManagerLayout.AddView(pluginDownload);
                    //pluginManagerLayout.AddView(pluginUpload);
                
                }
        }

        void UpdatePluginAvailability(object sender, EventArgs e)
        {
            Android.Widget.CheckBox checkBox = sender as Android.Widget.CheckBox;
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

        void UpdateCheckBoxText(Android.Widget.CheckBox checkBox)
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