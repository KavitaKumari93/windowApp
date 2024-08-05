using ControlzEx.Standard;
using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Models;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp.ViewModel
{
    public class AddEditUserViewModel : PropertyChangeHelper
    {
        private SynchronizationContext synchronizationContext;
        private string _message = string.Empty;
        private string _newLine = Environment.NewLine;

        #region Properties
        private StaffModel _staffModelObj;
        public StaffModel StaffModelObj
        {
            get { return _staffModelObj; }
            set { _staffModelObj = value; OnPropertyChanged(); }
        }

        private bool _isLoaderActive;
        public bool IsLoaderActive
        {
            get { return _isLoaderActive; }
            set { _isLoaderActive = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public RelayCommandHelper SaveUserCommand { get; set; }
        public RelayCommandHelper SaveContinueCommand { get; set; }
        #endregion

        public AddEditUserViewModel()
        {
            StaffModelObj = new StaffModel
            {
                UserObj = new UserModel()
            };
            SaveUserCommand = new RelayCommandHelper(x => SaveUserMethod());
            SaveContinueCommand = new RelayCommandHelper(x => SaveUserMethod());
        }

        #region Methods
        private async void SaveUserMethod()
        {
            // synchronizationContext = SynchronizationContext.Current;

            if (!ValidateInfo())
            {
                IsLoaderActive = true;

                try
                {
                    var result = await Task.Run(() => new UserService().SaveOrUpdateUserAsync(StaffModelObj));

                    if (result != 0)
                    {
                        IsLoaderActive = false;
                        MessageBox.Show("User Save Successfully!!");
                    }
                    else
                        MessageBox.Show("Something went wrong!!");

                    //synchronizationContext.Post(new SendOrPostCallback(o =>
                    //{
                    //    IsLoaderActive = false;

                    //    if (result != 0)
                    //    {
                    //        MessageBox.Show("User Save Successfully!!");
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Something went wrong!!");
                    //    }
                    //}), null);
                }
                catch (Exception ex)
                {
                    //synchronizationContext.Post(new SendOrPostCallback(o =>
                    //{
                        IsLoaderActive = false;
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    //}), null);
                }
            }
            else
            {
                //synchronizationContext.Post(new SendOrPostCallback(o =>
                //{
                    MessageBox.Show(_message);
                //}), null);
            }
        }

        public bool ValidateInfo()
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("Please provide required information :");

            bool err = false;
            if (string.IsNullOrEmpty(StaffModelObj.UserObj.UserName))
            {
                messageBuilder.AppendLine("UserName");
                err = true;
            }

            if (string.IsNullOrEmpty(StaffModelObj.UserObj.Password))
            {
                messageBuilder.AppendLine("Password");
                err = true;
            }

            if (string.IsNullOrEmpty(StaffModelObj.Email))
            {
                messageBuilder.AppendLine("Email,");
                err = true;
            }

            if (string.IsNullOrEmpty(StaffModelObj.FirstName))
            {
                messageBuilder.AppendLine("First Name");
                err = true;
            }

            if (string.IsNullOrEmpty(StaffModelObj.LastName))
            {
                messageBuilder.AppendLine("Last Name");
                err = true;
            }
            _message = messageBuilder.ToString().TrimEnd();

            return err;
        }
        #endregion
    }
}
