using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

namespace Codeholic.SQL
{
    [Table]
    internal class PluginPairingTable
    {
        // by default, it assumes the field name is the same as the variable name, but we can specify Name="nameOfField" explicitly.
        // i have declared the names of each field here explicitly just to demonstrate how this works (to myself/for future reference)
        [Column(IsPrimaryKey = true, Name="pairingID")]
        public int pairingID;

        [Column(Name="userID")]
        public int userID;

        [Column(Name="pluginID")]
        public int pluginID;
    }
}