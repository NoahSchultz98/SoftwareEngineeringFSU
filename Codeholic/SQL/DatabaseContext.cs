﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Codeholic.SQL
{
    public class DatabaseContext : DbContext
    {



        public DbSet<Plugin> Plugins { get; set; }
        public DbSet<User> Users { get; set; }

        public string DbPath { get; }
        public string connectionString { get 
            {
                // connectionString="Data Source=IP_ADDRESS,PORT;Network Library=DBMSSOCN;Initial Catalog=DatabaseName;User ID=Username;Password=Password"ent
                //return "Data Source= www.pokodraws.com,3306;Network Library=DBMSSOCN;Initial Catalog=code-aholic;User ID=kkDFh18s6edh767LOOhseder1;Password=XCz792ziUoqlPxqZalOQPAlqwwQUi";
                return "Data Source= www.pokodraws.com,3306;User ID=kkDFh18s6edh767LOOhseder1;Password=XCz792ziUoqlPxqZalOQPAlqwwQUi";
            }
        }


        public DatabaseContext()
        {
            //SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();// not sure we need this...
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            /*next steps...:
             * (https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/)
               use a connection string to access the database on XAMPP rather than string dbPath (remember, this is on the phone...)
             
             */
            //string dbPath = Path.Combine(FileSystem.AppDataDirectory, "code-aholic.sql"); // we'll seee.....
            // but we want to access this as a web resource... hmm
            //optionsBuilder.UseSQL(connectionString);
            //optionsBuilder.UseSqlite(connectionString); // well...
        }

    }
}