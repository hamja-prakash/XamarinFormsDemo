using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinNativeDemo.DependencyServices
{
    public interface ISqldatabase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
