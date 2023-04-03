using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
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
            Button fileSelectorButton = FindViewById<Button>(Resource.Id.btnSelectFiles);
            fileSelectorButton.Click += async delegate
            {
                FileResult result = await Extensions.PickFile();
            };

        }

    }
}