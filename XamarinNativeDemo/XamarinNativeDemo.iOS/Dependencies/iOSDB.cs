using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.iOS.Dependencies;

[assembly: Dependency(typeof(iOSDB))]
namespace XamarinNativeDemo.iOS.Dependencies
{
    public class iOSDB : ISqldatabase
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "UserDB.sqlite";
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder  
            string libraryPath = Path.Combine(dbPath, "..", "Library"); // Library folder  
            var path = Path.Combine(libraryPath, dbName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}