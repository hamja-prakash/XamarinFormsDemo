using SQLite;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Droid.Dependencies;

[assembly: Dependency(typeof(AndroidDB))]
namespace XamarinNativeDemo.Droid.Dependencies
{
    public class AndroidDB : ISqldatabase
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "UserDB.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = System.IO.Path.Combine(dbPath, dbName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}