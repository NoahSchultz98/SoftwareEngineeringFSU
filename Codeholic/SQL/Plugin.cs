using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codeholic.SQL
{
    public class Plugin
    {

        [Key]
        public int pluginID { get; set; }
        public string name { get; set; }
        public string pluginData { get; set; }
        public string helpdocData { get; set; }
        public int creator { get; set; }
        public string description { get; set; }
        public bool available { get; set; }

        public Plugin()
        {
            name = "default plugin name";
            description = "default plugin description";
        }
        public Plugin(string _data)
        {
            // constructor stuff
            pluginData = _data;
            name = "default plugin name";
            description = "default plugin description";
        }
    }
}
        /*
        public string name;
        public string description;
        public string data;

        public bool available = false;

        public Plugin(string _data)
        {
            // constructor stuff
            data = _data;
            name = "default plugin name";
            description = "default plugin description";
        }

    }
}
        */