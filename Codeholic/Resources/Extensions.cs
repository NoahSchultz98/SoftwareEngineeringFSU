using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Codeholic.Resources
{
    internal class Extensions
    {
        public static async Task<FileResult> PickFile()
        {
            var customFileType =
                new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
               { DevicePlatform.iOS, new[] { "public" } }, // or general UTType values  
               { DevicePlatform.Android, new[] { "*/*" } },
                });
            var options = new PickOptions
            {
                PickerTitle = "Please select a comic file",
                FileTypes = customFileType,
            };
            var result = await FilePicker.PickAsync(options);
            return result;
        }

    }
}