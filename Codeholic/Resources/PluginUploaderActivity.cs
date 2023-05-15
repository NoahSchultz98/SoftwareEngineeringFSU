using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Codeholic.SQL;
using Java.IO;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.IO;
using Android.Webkit;

namespace Codeholic.Resources
{
    [Activity(Label = "PluginUploader")]
    public class PluginUploaderActivity : Activity
    {
        EditText pluginNameEditText;
        EditText pluginDescriptionEditText;
        FileResult lastPluginFileResult;
        FileResult lastHelpDocFileResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.PluginUploader);

            Button pluginFileSelectorButton = FindViewById<Button>(Resource.Id.btnSelectPluginFile);
            pluginFileSelectorButton.Click += PluginFileSelectorButton_Click;

            Button helpdocFileSelectorButton = FindViewById<Button>(Resource.Id.btnSelectHelpDocFile);
            helpdocFileSelectorButton.Click += HelpDocFileSelectorButton_Click;

            Button fileUploaderButton = FindViewById<Button>(Resource.Id.btnUploadPlugin);
            fileUploaderButton.Click += FileUploaderButton_Click;


            pluginNameEditText = FindViewById<EditText>(Resource.Id.pluginName);
            pluginDescriptionEditText = FindViewById<EditText>(Resource.Id.pluginDescription);

            //selectedFileLabel.Text = "I swear I'm alive";

        }

        private void FileUploaderButton_Click(object sender, EventArgs e)
        {
            //Extensions.uploadPlugin(new Codeholic.SQL.Plugin("")); // data should go here, in future
            //FindViewById<TextView>(Resource.Id.textViewErrorLogging).Text = Extensions.ConnectionTest();
            //Extensions.Get();
            //Extensions.TestRest();


            // get data from selected file...
            // 

            string fileData = "placeholder data";
            string helpDocData = "placeholder data";
            if (lastPluginFileResult == null)
            {
                Toast.MakeText(Android.App.Application.Context, "Please select a plugin file first.", ToastLength.Long).Show();
                return;
            }
            else
            {
                // open, read file
                fileData = System.IO.File.ReadAllText(Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, lastPluginFileResult.FileName));
            }
            if (lastHelpDocFileResult == null)
            {
                AlertDialog.Builder helpDocAlert = new AlertDialog.Builder(this);
                helpDocAlert.SetTitle("Upload plugin without help documentation?");


                helpDocAlert.SetPositiveButton("Yeah, let's do it", async (senderAlert, args) => {

                    // continue execution...
                    UploadThePlugin();
                });
                helpDocAlert.SetNegativeButton("No thanks", (senderAlert, args) => {

                    // stop execution...

                    return;

                });
                RunOnUiThread(() => { helpDocAlert.Show(); });

            }
            else
            {
                helpDocData = System.IO.File.ReadAllText(Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, lastHelpDocFileResult.FileName));
                UploadThePlugin();
            }

            void UploadThePlugin()
            {

                // alert the user that they are about to overwrite file 
                //var result = await p.DisplayActionSheet("Overwrite plugin?", "No", null, "Yes");
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Upload plugin?");
                alert.SetPositiveButton("Yeah, let's do it", async (senderAlert, args) => {

                    //Toast.MakeText(Android.App.Application.Context, fileData + " and... " + helpDocData, ToastLength.Short).Show();
                    var result = await DatabaseConnection.UploadPlugin(new SQL.Plugin(fileData, helpDocData, pluginNameEditText.Text, pluginDescriptionEditText.Text));

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

                    return;

                });
                RunOnUiThread(() => { alert.Show(); });
            }

        }

        private void PluginFileSelectorButton_Click(object sender, EventArgs e)
        {
            /*
            Intent intent = new Intent();
            intent.SetType("text/plain");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select file"), 1);
            */

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                //var result = await PickAndShow(PickOptions.Images);
                var result = await Extensions.PickFile();
                lastPluginFileResult = result;
                FindViewById<TextView>(Resource.Id.labelSelectedPluginFile).Text = lastPluginFileResult.FullPath;
            });

        }

        private void HelpDocFileSelectorButton_Click(object sender, EventArgs e)
        {
            /*
            Intent intent = new Intent();
            intent.SetType("text/plain");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select file"), 1);
            */

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                //var result = await PickAndShow(PickOptions.Images);
                var result = await Extensions.PickFile();
                lastHelpDocFileResult = result;
                FindViewById<TextView>(Resource.Id.labelSelectedHelpDocFile).Text = lastPluginFileResult.FullPath;

            });

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1 && resultCode == Result.Ok)
            {
                var uri = data.Data;
                var stream = ContentResolver.OpenInputStream(uri);

                Toast.MakeText(Android.App.Application.Context, uri.Path, ToastLength.Long).Show();

                string str = "";
                StringBuffer buf = new StringBuffer();
                BufferedReader reader = new BufferedReader(new InputStreamReader(stream));

                while ((str = reader.ReadLine()) != null)
                {
                    buf.Append(str + "\n");
                }
                stream.Close();

            }

        }
    }
}