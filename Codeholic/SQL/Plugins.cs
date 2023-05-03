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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Codeholic.SQL
{
    public class Plugins
    {
        
        [Key]
        public int pluginID { get; set; }
        public string name { get; set; }
        public string pluginData { get; set; }
        public string helpdocData { get; set; }
        public int creator { get; set; }
        public string description { get; set; }
        public bool available { get; set; }
    }
}