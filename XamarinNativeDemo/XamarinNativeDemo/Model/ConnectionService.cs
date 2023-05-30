using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace XamarinNativeDemo.Model
{
    public class ConnectionService
    {
        public static bool IsConnected()
        {
            bool connected = false;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                connected = true;
            return connected;
        }
    }
}
