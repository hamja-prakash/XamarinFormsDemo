using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Forms.Internals.Profile;

namespace XamarinNativeDemo.Model
{
    public class EmployeeListner : StatusResult
    {
        public List<Datum> data { get; set; }
    }
}
