using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Codeholic.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Codeholic.Resources
{
    internal class DatabaseConnection
    {
        // set this to a user to 'log in', unset to 'log out'
        public static User currentUser;

        public static int currentUserID { get { if (currentUser != null) return currentUser.userID; else return -1; } } // not -1 = logged in -- login can set this variable to enable functions. unset to 'log out'. it's like a key in the ignition
        // returns pluginDeveloper by default until database integration
        public static UserType currentUserType { get { if (currentUser != null) return currentUser.userType; else return UserType.guest; } }

        // address of the local server
        private static string URI = "http://192.168.47.237/Codeaholic/access.php";
        

        public static bool HavePrivilege(UserType privilegeLevel)
        {
            if (currentUserType >= privilegeLevel)
                return true;
            else
                return false;
        }

        public async static Task<WebResponse> Query(string _query)
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "query",
                    query = _query
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                    return data;
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();
                    return null;
                }
            }
        }

        // data.data will contain an error message in the case of an error on the server side
        public async static Task<WebResponse> QueryWithErrorReporting(string _query)
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "queryWithErrorReporting",
                    query = _query
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                    return data;
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();
                    return null;
                }
            }
        }

        public async static Task<WebResponse> NoahQuery(string _query)
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "query",
                    query = _query
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
                // could try/catch here
                return data;
            }
        }

        public async static Task<User> GetUserInfo()
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "getUserInfo",
                    userID = currentUserID
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
                // could try/catch here
                //Toast.MakeText(Android.App.Application.Context, data.data, ToastLength.Long).Show();
                User user = JsonSerializer.Deserialize<User>(data.data);

                return user;
            }
        }

        public async static Task<bool> UploadPlugin(SQL.Plugin plugin)
        {
            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "uploadPlugin",
                    userID = currentUserID,
                    pluginName = plugin.name,
                    pluginData = plugin.pluginData,
                    helpdocData = plugin.helpdocData,
                    description = plugin.description
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
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "Result: " + data.ToString(), ToastLength.Long).Show();

                bool success = (data.data == "true") ? true : false;

                return success;
            }
        }

        public async static Task<List<Codeholic.SQL.Plugin>> GetPluginsByCreator(TextView debugWindow = null)
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "getPluginsByCreator",
                    userID = currentUserID
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

                List<SQL.Plugin> pluginsByCreator = new List<SQL.Plugin>();
                if (debugWindow != null)
                {
                    debugWindow.Text = data.data;
                }
                try
                {
                    pluginsByCreator = JsonSerializer.Deserialize<List<SQL.Plugin>>(data.data).ToList();
                    if (debugWindow != null)
                    {
                        debugWindow.Text = pluginsByCreator.Count().ToString();
                    }
                    //Toast.MakeText(Android.App.Application.Context)
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long);
                    if (debugWindow != null)
                    {
                        debugWindow.Text = ex.StackTrace;
                    }
                }
                return pluginsByCreator;
            }
        }

        public async static Task<bool> UpdatePluginName(int _pluginID, string _name)
        {

            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "updatePluginName",
                    pluginID = _pluginID,
                    name = _name,
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();

                bool success = false;

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                    //Toast.MakeText(Android.App.Application.Context, data.data, ToastLength.Long).Show();

                    success = (data.data == "true") ? true : false;
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();

                }
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();


                return success;
            }
        }


        public async static Task<bool> UpdatePluginDescription(int _pluginID, string _description)
        {

            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "updatePluginDescription",
                    pluginID = _pluginID,
                    description = _description
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();

                bool success = false;

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);

                    success = (data.data == "true") ? true : false;
                }
                catch (Exception ex)
                {
                    Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();

                }
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();


                return success;
            }
        }

        public async static Task<bool> UpdatePluginAvailability(int _pluginID, bool _available)
        {

            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "updatePluginAvailability",
                    pluginID = _pluginID,
                    available = _available
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();

                bool success = false;

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);

                    success = (data.data == "true") ? true : false;
                }
                catch (Exception ex)
                {
                    //Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();

                }
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();


                return success;
            }
        }

        public async static Task<bool> UpdatePluginData(int _pluginID, string _pluginData)
        {

            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "updatePluginData",
                    pluginID = _pluginID,
                    pluginData = _pluginData
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();

                bool success = false;

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                    success = (data.data == "true") ? true : false;
                }
                catch (Exception ex)
                {
                    //Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();

                }
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();


                return success;
            }
        }

        public async static Task<bool> UpdateHelpDocData(int _pluginID, string _helpdocData)
        {

            if (!HavePrivilege(UserType.pluginDeveloper))
                return false;

            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "updatePluginHelpDocData",
                    pluginID = _pluginID,
                    helpdocData = _helpdocData
                }),
                Encoding.UTF8,
                "application/json");

                using HttpResponseMessage response = await httpClient.PostAsync(URI, jsonContent);

                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();

                bool success = false;

                try
                {
                    WebResponse data = await response.Content.ReadFromJsonAsync<WebResponse>(options);
                    success = (data.data == "true") ? true : false;
                }
                catch (Exception ex)
                {
                    //Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();

                }
                // want to get the result as bool
                //Toast.MakeText(Android.App.Application.Context, "trying to update pluginID " + _pluginID + " to name " + _name, ToastLength.Long).Show();


                return success;
            }
        }

        // get string... serialize string

        public async static Task<Codeholic.SQL.Plugin> GetPluginByID(int _pluginID)
        {
            using (HttpClientHandler clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var httpClient = new HttpClient(clientHandler);

                using StringContent jsonContent = new StringContent(JsonSerializer.Serialize(new
                {
                    function = "getPluginByID",
                    pluginID = _pluginID 
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

                SQL.Plugin plugin = JsonSerializer.Deserialize<SQL.Plugin>(data.data);
                return plugin;
            }
        }

    }
}