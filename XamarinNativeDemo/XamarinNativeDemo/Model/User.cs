using SQLite;

namespace XamarinNativeDemo.Model
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int UserId { get; set; }
        public string UserImg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }

        public string DisplayName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
