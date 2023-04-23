using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Codeholic.Resources
{
    [Activity(Label = "PluginUploader")]
    public class PluginUploaderActivity : Activity
    {
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
            //selectedFileLabel.Text = "I swear I'm alive";

        }

        private void FileUploaderButton_Click(object sender, EventArgs e)
        {
            Extensions.uploadPlugin(new Codeholic.SQL.Plugin("")); // data should go here, in future
        }

        private void FileSelectorButton_Click(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await PickAndShow(PickOptions.Images);
            });
        }

        async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    FindViewById<TextView>(Resource.Id.labelSelectedFile).Text = $"File Name: {result.FileName}";
                    var stream = await result.OpenReadAsync();
                    // write this to a string and send it to the db
                    //Extensions.uploadPlugin(new Plugin("")); // data should go here, in future
                }

                return result;
            }
            catch (Exception ex)
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