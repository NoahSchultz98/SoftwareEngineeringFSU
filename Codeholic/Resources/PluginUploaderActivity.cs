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

namespace Codeholic.Resources
{
    [Activity(Label = "PluginUploader")]
    public class PluginUploaderActivity : Activity
    {
        EditText pluginNameEditText;
        EditText pluginDescriptionEditText;
        FileResult lastFileResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your application here

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.PluginUploader);
            
            Button fileSelectorButton = FindViewById<Button>(Resource.Id.btnSelectFile);
            fileSelectorButton.Click += FileSelectorButton_Click;

            Button fileUploaderButton = FindViewById<Button>(Resource.Id.btnUploadPlugin);
            fileUploaderButton.Click += FileUploaderButton_Click;

            TextView selectedFileLabel = FindViewById<TextView>(Resource.Id.labelSelectedFile);

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

            if(lastFileResult != null)
            {
                // open, read file
                fileData = System.IO.File.ReadAllText(Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, lastFileResult.FileName));
            }

            Toast.MakeText(Android.App.Application.Context, Path.Combine(Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath, lastFileResult.FileName), ToastLength.Long).Show();

            var result = DatabaseConnection.UploadPlugin(new SQL.Plugin(fileData, pluginNameEditText.Text, pluginDescriptionEditText.Text));
            //Toast.MakeText(Android.App.Application.Context, "Result: " + result.Result, ToastLength.Long).Show();

        }

        private void FileSelectorButton_Click(object sender, EventArgs e)
        {
            /*
            Intent intent = new Intent();
            intent.SetType("text/plain");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select file"), 1);
            */
            
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                var result = await PickAndShow(PickOptions.Images);
                lastFileResult = result;
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

        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync();

                if (result != null)
                {
                    FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = $"File Name: {result.FileName}";
                    var stream = await result.OpenReadAsync();
                    // write this to a string and send it to the db
                    //Extensions.uploadPlugin(new Plugin("")); // data should go here, in future
                }

                return result;
            }
            catch (System.Exception ex)
            {
                // The user canceled or something went wrong
                _ = ex;
            }

            return null;
        }

        async Task<FileResult> PickAFileMaybe()
        {

            try
            {
                var file = await FilePicker.PickAsync();
                if (file == null)
                {
                    FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = "nope, sorry";
                    return null;
                }
                FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = file.FileName;
                return file;
            }
            catch
            {

            }
            // attempt 2
            try
            {
                var file = await FilePicker.PickAsync();

                if (file == null)
                {

                    FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = "nope, sorry (2)";
                    return null;
                }

                FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = file.FileName + " from method 2";
                return file;
            }
            catch
            {

            }
            return null;
        }

    }
}