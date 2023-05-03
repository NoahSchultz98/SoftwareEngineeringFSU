using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Codeholic.SQL
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public UserType userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public override string ToString()
        {

            return "User ID: " + userID + " User Type: " + userType + " Username: " + username;
        }
    }

    public enum UserType
    {
        guest=0,registeredUser=1,pluginDeveloper=2
    }
}