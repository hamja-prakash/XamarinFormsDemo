using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinNativeDemo.Model
{
    public class DatabaseHelper
    {
        public static string InsertUser = "Insert into User(UserImg,FirstName,LastName,Address,MobileNo,Password)Values(?,?,?,?,?,?)";
        public static string UpdateUser = "Update User Set UserImg=?, FirstName=?, LastName=?, Address=?,MobileNo=?, Password=? Where UserId=?";
        public static string DeleteUser = "Delete from User where UserId=?";
        public static string AllUser = "Select * from User";
    }
}
