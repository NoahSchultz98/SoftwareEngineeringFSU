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
using System.Runtime.CompilerServices;

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
        public int available { get; set; }

        public Plugin()
        {
            name = "default plugin name";
            description = "default plugin description";
            pluginData = "data string";
            helpdocData = "helpdoc data string";
            
        }
        public Plugin(string _data, string _helpDocData, string _name = "default plugin name", string _description = "default plugin description")
        {
            // constructor stuff
            pluginData = _data;
            name = _name;
            description = _description;
            helpdocData = "help doc data";

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