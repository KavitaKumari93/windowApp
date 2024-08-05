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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp.ViewModel
{
    public class LoginViewModel : PropertyChangeHelper
    {
        private SynchronizationContext synchronizationContext;
        #region Property


        private bool _isAgencyPortalSelected;
        public bool IsAgencyPortalSelected
        {
            get { return _isAgencyPortalSelected; }
            set { _isAgencyPortalSelected = value; OnPropertyChanged(); }
        }
        private bool isBusinessNameVerfied;
        public bool IsBusinessNameVerfied
        {
            get { return isBusinessNameVerfied; }
            set { isBusinessNameVerfied = value; OnPropertyChanged(); }
        }

        private OrganizationModel _organizationModelObj;
        public OrganizationModel OrganizationModelObj
        {
            get { return _organizationModelObj; }
            set { _organizationModelObj = value; OnPropertyChanged(); }
        }
        private string _verifyBussinessName;
        public string VerifyBussinessName
        {
            get { return _verifyBussinessName; }
            set { _verifyBussinessName = value; OnPropertyChanged(); }
        }
        private LoginModel _agencyLoginDetailsObj;
        public LoginModel AgencyLoginDetailsObj
        {
            get { return _agencyLoginDetailsObj; }
            set { _agencyLoginDetailsObj = value; OnPropertyChanged(); }
        }
        private LoginModel _patientLoginDetailsObj;
        public LoginModel PatientLoginDetailsObj
        {
            get { return _patientLoginDetailsObj; }
            set { _patientLoginDetailsObj = value; OnPropertyChanged(); }
        }


        #endregion

        #region Commands
        public RelayCommandHelper VerifyBusinessCommand { get; set; }
        public RelayCommandHelper AgencyPortalSelectionCommand { get; set; }
        public RelayCommandHelper PatientPortalSelectionCommand { get; set; }
        public RelayCommandHelper AgencyLoginCommand { get; set; }
        public RelayCommandHelper PatientLoginCommand { get; set; }


        #endregion

        public LoginViewModel()
        {
            IsAgencyPortalSelected = true;
            OrganizationModelObj = new OrganizationModel();
            AgencyLoginDetailsObj = new LoginModel();
            VerifyBusinessCommand = new RelayCommandHelper(x => VerifyBusiness());
            AgencyPortalSelectionCommand = new RelayCommandHelper(x => AgencyPortalSelection());
            PatientPortalSelectionCommand = new RelayCommandHelper(x => PatientPortalSelection());
            AgencyLoginCommand = new RelayCommandHelper(x => ValidateAgencyUser());
        }

        #region Methods

        public void AgencyPortalSelection()
        {
            IsAgencyPortalSelected = true;
            AgencyLoginDetailsObj = new LoginModel();
        }
        public void PatientPortalSelection()
        {
            IsAgencyPortalSelected = false;
            PatientLoginDetailsObj = new LoginModel();
        }
        //public int CheckIfAgencyDetailsExists()
        //{
        //    OrganizationModel organizationModel = new OrganizationModel();
        //    var result = CommonMethods.ReadFile(organizationModel);
        //    return result is OrganizationModel orgModel ? orgModel.OrganizationID : 0;
        //}
        public  void VerifyBusiness()
        {
            try
            {
                synchronizationContext = SynchronizationContext.Current;
                if (!string.IsNullOrEmpty(VerifyBussinessName))
                {
                    var org = new OrganizationService().CheckOrganizationBusinessName(VerifyBussinessName, GlobalData.organizationId);
                    OrganizationModelObj.OrganizationID = org.Result;
                   
                    if (OrganizationModelObj.OrganizationID == 0)
                        synchronizationContext.Send(new SendOrPostCallback(o =>
                        {
                            MessageBox.Show("Invalid Bussiness Name!!");
                        }), null);
                    else
                        IsBusinessNameVerfied = true;
                }
                else
                    synchronizationContext.Send(new SendOrPostCallback(o =>
                    {
                        MessageBox.Show("Enter Bussiness Name to continue!!");
                    }), null);
              
            }
            catch (Exception ex)
            {

            }
        }
        public void ValidateAgencyUser()
        {
            if (!string.IsNullOrEmpty(AgencyLoginDetailsObj.UserName) && !string.IsNullOrEmpty(AgencyLoginDetailsObj.Password))
            {
                var users = new UserService().GetUsersByOrganizationId(OrganizationModelObj.OrganizationID);
                if (users.Result != null)
                {
                    UserModel adminDetails = users.Result.FirstOrDefault(x => x.RoleID == (int)Roles.Admin);
                    //Validate Admin User
                    if (adminDetails.UserName == AgencyLoginDetailsObj.UserName && CommonMethods.Decrypt(adminDetails.Password) == AgencyLoginDetailsObj.Password)
                    {
                        NavigateToDashboardScreen();
                        GlobalData.organizationId= OrganizationModelObj.OrganizationID;
                    }
                    else
                    {
                        synchronizationContext.Send(new SendOrPostCallback(o =>
                        {
                            MessageBox.Show("Invalid Credentials");
                        }), null);
                    }
                }
            }
            else
            {
                synchronizationContext.Send(new SendOrPostCallback(o =>
                {
                    MessageBox.Show("Please enter login details");
                }), null);
            }
        }
        public void NavigateToDashboardScreen()
        {
            AppMessenger.Navigate(NavigationPages.MainDashboard);
        }
        #endregion
    }
}
