using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinNativeDemo.DependencyServices;

namespace XamarinNativeDemo.Model
{

    public class UserDatabase
    {
        private SQLiteConnection conn;
        public UserDatabase()
        {
            conn = DependencyService.Get<ISqldatabase>().GetConnection();
            conn.CreateTable<User>();
        }

        public bool SaveUser(User mUser)
        {
            return conn.Execute(DatabaseHelper.InsertUser, new object[] { mUser.UserImg, mUser.FirstName, mUser.LastName,
                                                                          mUser.Address, mUser.MobileNo,mUser.Password }) == 1 ? true : false;
        }

        public bool UpdateUser(User mUser)
        {
            return conn.Execute(DatabaseHelper.UpdateUser, new object[] {mUser.UserImg, mUser.FirstName, mUser.LastName,
                                                                          mUser.Address, mUser.MobileNo,mUser.Password, mUser.UserId }) == 1 ? true : false;
        }

        public bool DeleteUser(int Id)
        {
            conn.Query<User>(DatabaseHelper.DeleteUser, Id);
            return true;
        }

        public List<User> GetAllUser()
        {
            return conn.Query<User>(DatabaseHelper.AllUser, new object[] { }).ToList();
        }
    }
}
