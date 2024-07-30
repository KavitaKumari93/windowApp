using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.Navigation;
using smartHealthApp.Models;
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
        }
        #endregion

        #region Properties
        private ObservableCollection<StaffModel> _staffList = null;
        public ObservableCollection<StaffModel> StaffList
        {
            get { return _staffList; }
            set { _staffList = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands 
        public RelayCommandHelper AddUserCommand {  get; set; }
        #endregion

        #region Methods 
        public void AddUser()
        {

        }

        public void LoadUsers()
        {
            try
            {
                
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
