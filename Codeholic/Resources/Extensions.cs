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
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace Codeholic.Resources
{
    internal class Extensions
    {

        
        private static RestClient _client = new RestClient("https://www.pokodraws.com/");


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

        public static void TestRest()
        {
            string toToast = "";
            var request = new RestRequest("CodeholicLibrary.php", Method.Get);
            var response = _client.Execute(request);

            toToast = response.StatusDescription.ToString();
            
            Toast.MakeText(Android.App.Application.Context, toToast, ToastLength.Long).Show();
        }

        public static void Post()
        {
            string URI = "http://www.pokodraws.com/CodeaholicLibrary.php";
            string myParameters;

            using (WebClient webClient = new WebClient())
            {
                //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                //string result = webClient.UploadString(URI, myParameters);
                
            }

        }

        private static string URI = "http://192.168.1.4/Codeaholic/access.php";
        public async static Task<User> GetUserInfo()
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                string result = await httpClient.GetStringAsync(URI);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "getUserInfo",
                    userID = 1
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                // data isn't null, so...
                User user = JsonSerializer.Deserialize<User>(data.data);

                return user;
            }
        }

            public async static void Get()
            {
            // reference: https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
            //string URI = "https://jsonplaceholder.typicode.com/todos";
            //string URI = "https://www.pokodraws.com/CodeholicLibrary.php";
            string URI = "http://192.168.1.4/Codeaholic/access.php";
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                string result = await httpClient.GetStringAsync(URI);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "getUserInfo",
                    userID = 1
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                //result = await response.Content.ReadAsStringAsync();

                //WebResponse data = JsonConverter.Deserialize<WebResponse>(result);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                // data isn't null, so...
                User user = JsonSerializer.Deserialize<User>(data.data);


                // availableData = "Status Code: " + data.status.ToString() + " Status_Message: " + data.status_message + " Data String: " + data.data;
                // it's returning basically a new object(?)
                Toast.MakeText(Android.App.Application.Context, "Result: " + user.userType.ToString(), ToastLength.Long).Show();
            }
        }

        public static string ConnectionTest()
        {
            string connectionString = "Data Source= 192.168.1.4; Initial Catalog=codeaholic;User ID=kkDFh18s6edh767LOOhseder1;Password=XCz792ziUoqlPxqZalOQPAlqwwQUi";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                Toast.MakeText(Android.App.Application.Context, "The connection is open", ToastLength.Long).Show();
                sqlConnection.Close();
            }
            catch (Exception e)
            {

                return e.Message;
                //throw;
                //Toast.MakeText(Android.App.Application.Context, "An error was encountered in attempting to open the connection: " + e.Message, ToastLength.Long).Show();

                //return e.StackTrace;
                //Toast.MakeText(Android.App.Application.Context, "An error was encountered in attempting to open the connection.", ToastLength.Long).Show();
            }
            return "Successfully connected to database";
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