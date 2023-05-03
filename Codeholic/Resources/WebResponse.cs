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

namespace Codeholic.Resources
{
    public class WebResponse
    {
        public int status { get; set; }
        public string status_message { get; set; }
        public string data { get; set; }

        public override string ToString()
        {
            return "Status: " + status + " Status Message: " + status_message + " Data: " + data;
        }

        /*
        public int status = -1;
        public string status_message = "uninitialized status_message";

        public string data = "uninitialized data";

        public WebResponse()
        {

        }
        */
    }
}