using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace smartHealthApp.ViewModel
{
    public class AddEditUserViewModel : PropertyChangeHelper
    {
        //private SynchronizationContext synchronizationContext;
        //private UserService userService;

        #region Properties
        private StaffModel _staffModelObj;
        public StaffModel StaffModelObj
        {
            get { return _staffModelObj; }
            set { _staffModelObj = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public RelayCommandHelper SaveUserCommand {  get; set; }
        public RelayCommandHelper SaveContinueCommand { get; set; }
        #endregion

        public AddEditUserViewModel()
        {
            StaffModelObj = new StaffModel();
            StaffModelObj.UserObj = new UserModel();
            SaveUserCommand = new RelayCommandHelper(x=> SaveUserMethod());
            SaveContinueCommand = new RelayCommandHelper(x => SaveContinueMethod());
        }

        #region Methods
        private void SaveUserMethod()
        {
            var data=new UserService().SaveOrUpdateUserAsync(StaffModelObj);


        }
        private void SaveContinueMethod()
        {


        }
        #endregion
    }
}
