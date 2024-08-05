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
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;

namespace smartHealthApp.ViewModel
{
    public class MainViewModel : PropertyChangeHelper
    {
        public MainViewModel()
        {
            GlobalData.organizationId  = CheckIfAgencyDetailsExists();
            AppMessenger.Navigate(GlobalData.organizationId > 0 ? NavigationPages.Login : NavigationPages.SetUpForAgency);
        }

        public int CheckIfAgencyDetailsExists()
        {
            OrganizationModel organizationModel = new OrganizationModel();
            var result = CommonMethods.ReadFile(organizationModel);
            return result is OrganizationModel orgModel ? orgModel.OrganizationID : 0;
        }
    }
}
