using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.Navigation;
using smartHealthApp.Models;
using smartHealthApp.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.ViewModel
{
    public  class ManageUserViewModel:PropertyChangeHelper
    {
        #region CTOR
        public ManageUserViewModel()
        {
         
            AddUserCommand = new RelayCommandHelper(x => AddUser());
            LoadUsers();
        }
        #endregion

        #region Properties
        private ObservableCollection<StaffModel> _staffListObj = null;
        public ObservableCollection<StaffModel> StaffListObj
        {
            get { return _staffListObj; }
            set { _staffListObj = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands 
        public RelayCommandHelper AddUserCommand {  get; set; }
        #endregion

        #region Methods 
        public void AddUser()
        {

        }

        public async void LoadUsers()
        {
            try
            {
                ListingFiltterModel listingFiltter = new ListingFiltterModel();
                var details =await new UserService().GetStaffUsers(listingFiltter);
                if (details != null)
                {
                    StaffListObj = details.ToObservableCollection();
                }
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
