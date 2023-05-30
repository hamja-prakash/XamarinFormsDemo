
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNativeDemo.DependencyServices;
using XamarinNativeDemo.Model;

namespace XamarinNativeDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserView : ContentView
    {
        #region [ Properties ]
        public List<User> mUsers;
        UserDatabase userDatabase;
        public int UserId = 0;
        public ImageButton ImageButton;
        public Label Title;
        #endregion

        public UserView(ImageButton imgbtn, Label title)
        {
            InitializeComponent();
            userDatabase = new UserDatabase();
            mUsers = new List<Model.User>();
            this.ImageButton = imgbtn;
            this.Title = title;
            BindUserData();
        }

        #region [ Methods ]
        public void BindUserData()
        {
            try
            {
                mUsers = userDatabase.GetAllUser();
                if (mUsers != null && mUsers.Count > 0)
                {
                    lblNoDataMsg.IsVisible = false;
                    lstUsers.IsVisible = true;
                    lstUsers.ItemsSource = mUsers.ToList();
                }
                else
                {
                    lstUsers.IsVisible = false;
                    lblNoDataMsg.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void SearchUsersData()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchUser.Text) &&
                    !string.IsNullOrWhiteSpace(txtSearchUser.Text) &&
                    txtSearchUser.Text.Length >= 2)
                {
                    lstUsers.ItemsSource = null;

                    if (mUsers != null && mUsers.Count > 0)
                    {
                        var mUserSearchList = mUsers.Where(x => x.DisplayName.ToLower().Contains(txtSearchUser.Text.ToLower()) ||
                                                                x.Address.ToLower().Contains(txtSearchUser.Text.ToLower()) ||
                                                                x.MobileNo.Contains(txtSearchUser.Text)).ToList();
                        if (mUserSearchList != null &&
                            mUserSearchList.Count > 0)
                        {
                            lstUsers.IsVisible = true;
                            lblNoDataMsg.IsVisible = false;
                            lstUsers.ItemsSource = mUserSearchList.ToList();
                        }
                        else
                        {
                            lblNoDataMsg.IsVisible = true;
                            lstUsers.IsVisible = false;
                        }
                    }
                }
                else
                {
                    lstUsers.IsVisible = true;
                    lblNoDataMsg.IsVisible = false;
                    lstUsers.ItemsSource = mUsers.ToList();
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region [ Events ]
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SearchUsersData();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void TxtSearch_Completed(object sender, EventArgs e)
        {
            try
            {
                SearchUsersData();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void ImgSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchUsersData();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        private void FrmUser_Tapped(object sender, EventArgs e)
        {
            if (sender is Frame frmUser && frmUser.BindingContext is Model.User mUser)
            {
                if (mUser != null)
                {
                    App.Current.MainPage.DisplayAlert("User", "You have selected " + mUser.FirstName + "", "Ok");
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                this.ImageButton.Source = "iconBackBtn.png";
                this.Title.Text = "Add User";
                grdUser.IsVisible = false;
                grdAddUser.IsVisible = true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private async void FrmSave_Tapped(object sender, EventArgs e)
        {
            try
            {
                await frmSave.ScaleTo(0.9, 100, Easing.Linear);
                await frmSave.ScaleTo(1.0, 100, Easing.Linear);
                if (ValidateControl())
                {
                    User muser = new User();
                    muser.FirstName = txtFirstName.Text;
                    muser.LastName = txtLastName.Text;
                    muser.Address = txtAddress.Text;
                    muser.MobileNo = txtMobileNo.Text;
                    muser.Password = txtFirstName.Text;
                    muser.UserImg = "img1.jpg";
                    if (UserId > 0)
                    {
                        muser.UserId = UserId;
                        userDatabase.UpdateUser(muser);
                    }
                    else
                        userDatabase.SaveUser(muser);

                    App.Current.MainPage.DisplayAlert("Alert", "User has been successfully save", "Ok");
                    grdAddUser.IsVisible = false;
                    grdUser.IsVisible = true;
                    BindUserData();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public bool ValidateControl()
        {
            bool isValid = false;
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter first name", "Ok");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter last name", "Ok");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter address", "Ok");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(txtMobileNo.Text))
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter mobile number", "Ok");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                App.Current.MainPage.DisplayAlert("Alert", "Please enter password", "Ok");
                isValid = false;
            }
            else
                isValid = true;
            return isValid;
        }

        private void BtnEdit_Tapped(object sender, EventArgs e)
        {
            if (sender is ImageButton imgEdit && imgEdit.BindingContext is Model.User mUser)
            {
                if (mUser.UserId > 0)
                {
                    grdAddUser.IsVisible = true;
                    grdUser.IsVisible = false;
                    txtPassword.IsEnabled = false;
                    txtFirstName.Text = mUser.FirstName;
                    txtLastName.Text = mUser.LastName;
                    txtAddress.Text = mUser.Address;
                    txtMobileNo.Text = mUser.MobileNo;
                    txtPassword.Text = mUser.Password;
                    UserId = mUser.UserId;
                }
            }
        }

        private async void BtnDelete_Tapped(object sender, EventArgs e)
        {
            if (sender is ImageButton imgEdit && imgEdit.BindingContext is Model.User mUser)
            {
                if (mUser.UserId > 0)
                {
                    var alertmsg = await App.Current.MainPage.DisplayAlert("Alert", "Are you sure you want to delete this record?", "Ok", "Cancel");
                    if (alertmsg)
                    {
                        userDatabase.DeleteUser(mUser.UserId);
                        BindUserData();
                    }
                }
            }
        }

        //private void lstUsers_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        //{
        //    int pageSize = 1;
        //    pageSize += 1;
        //    var item = (User)e.Item;
        //    if (mUsers.Count >= pageSize)
        //    {
        //        if (item == mUsers.Last())
        //        {
        //            pageSize += pageSize;
        //            lstUsers.IsVisible = true;
        //            BindUserData();
        //        }
        //    }
        //}
    }
}