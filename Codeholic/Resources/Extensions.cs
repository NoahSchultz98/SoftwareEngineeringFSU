using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
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
using System.Data;
using Codeholic.SQL;

namespace Codeholic.Resources
{
    internal class Extensions
    {


        private static string dbServer = "";
        private static string dbName = "";
        public const bool DEBUG_MODE = false;

        public static async void uploadPlugin(Plugin plugin)
        {
            using(var dbContext = new DatabaseContext())
            {
                var query = dbContext.Add(plugin);
                await dbContext.SaveChangesAsync();

                Toast.MakeText(Android.App.Application.Context, "Added plugin to local database", ToastLength.Long).Show();
            }

        }
        public static void getID()
        {
            using(var dbContext = new DatabaseContext())
            {
                //var users = dbContext.Users.ToList();
                var query = from user in dbContext.Users select user;
                var users = query.ToList();

                foreach (var user in users)
                {
                    Toast.MakeText(Android.App.Application.Context, "Found user: " + user.username, ToastLength.Long).Show();
                }
            }

            //Toast.MakeText(Android.App.Application.Context,"Mmm, crispy!", ToastLength.Long).Show();
        }

        public static bool ConnectedToDatabase()
        {
            // stump code to allow for debugging stuff. if this is false, go with unit tests, if this is true, pull data from database (for instance)
            return false;
        }

        public static bool HasPrivilege(int userId)
        {
            // stump code for later; when we can lookup users in the database we'll check if their userType has sufficient privileges
            return true;
        }

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