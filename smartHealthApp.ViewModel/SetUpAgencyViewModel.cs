using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.AppMessenger;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp.ViewModel
{
    public class SetUpAgencyViewModel : PropertyChangeHelper
    {
        private SynchronizationContext synchronizationContext;
        private string _message = string.Empty;
        private string _newLine = Environment.NewLine;
        #region Constructor
        public SetUpAgencyViewModel()
        {
            OrganizationModelObj = new OrganizationModel();
            OrganizationModelObj.UserModelObj = new UserModel();
            OrganizationModelObj.OrganizationSMTPModelObj = new OrganizationSMTPModel();

            SaveAgencyCommmand = new RelayCommandHelper(x => SaveOrganization());
        }
        #endregion
        private bool _isLoaderActive;
        public bool IsLoaderActive
        {
            get { return _isLoaderActive; }
            set { _isLoaderActive = value; OnPropertyChanged(); }
        }
        private OrganizationModel _organizationModelObj;
        public OrganizationModel OrganizationModelObj
        {
            get { return _organizationModelObj; }
            set { _organizationModelObj = value; OnPropertyChanged(); }
        }
        #region Commands
        public RelayCommandHelper SaveAgencyCommmand { get; set; }
        #endregion

        #region Methods
        private async void SaveOrganization()
        {
            synchronizationContext = SynchronizationContext.Current;

            if (!ValidateInfo())
            {
                try
                {
                    IsLoaderActive = true;
                    var result = await new OrganizationService().SaveOrganizationAsync(OrganizationModelObj);
                    if (result > 0)
                    {
                        IsLoaderActive = false;
                        GlobalData.organizationId = result;
                        synchronizationContext.Send(_ =>
                        {
                            MessageBox.Show("Organization Saved Successfully!!");
                        }, null);
                        NavigateToLoginScreen();
                    }
                    else
                    {
                        synchronizationContext.Send(_ =>
                        {
                            MessageBox.Show("Failed to save organization.");
                        }, null);
                    }
                }
                catch (Exception ex)
                {
                    synchronizationContext.Send(_ =>
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }, null);
                }
            }
            else
            {
                synchronizationContext.Send(_ =>
                {
                    MessageBox.Show(_message);
                }, null);
            }
        }

        public void NavigateToLoginScreen()
        {
            AppMessenger.Navigate(NavigationPages.Login);
        }

        public bool ValidateInfo()
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("Please provide required information :");

            bool err = false;
            if (string.IsNullOrEmpty(OrganizationModelObj.OrganizationName))
            {
                messageBuilder.AppendLine("Organization Name");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.BusinessName))
            {
                messageBuilder.AppendLine("Business Name");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.UserModelObj.UserName))
            {
                messageBuilder.AppendLine("UserName,");
                err = true;
            }
            if (string.IsNullOrEmpty(OrganizationModelObj.ContactPersonFirstName))
            {
                messageBuilder.AppendLine("Contact Person FirstName");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.ContactPersonLastName))
            {
                messageBuilder.AppendLine("Contact Person LastName");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.UserModelObj.Password))
            {
                messageBuilder.AppendLine("Password");
                err = true;
            }
            if (string.IsNullOrEmpty(OrganizationModelObj.OrganizationSMTPModelObj.SMTPUserName))
            {
                messageBuilder.AppendLine("SMTP UserName");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.OrganizationSMTPModelObj.SMTPPassword))
            {
                messageBuilder.AppendLine("SMTP Password");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.OrganizationSMTPModelObj.ConnectionSecurity))
            {
                messageBuilder.AppendLine("SMTP ConnectionSecurity");
                err = true;
            }
            _message = messageBuilder.ToString().TrimEnd();

            return err;
        }


        #endregion
    }
}
