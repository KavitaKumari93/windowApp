using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Common.AppMessenger;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.ViewModel
{
    public class MainViewModel : PropertyChangeHelper
    {
        public MainViewModel()
        {
            AppMessenger.Navigate(ChekIfAgencyDetailsExists() ? NavigationPages.Login : NavigationPages.SetUpForAgency);
        }

        public bool ChekIfAgencyDetailsExists()
        {
            OrganizationModel organizationModel = new OrganizationModel();
            return CommonMethods.ReadFile(organizationModel) != null ? true : false;
        }

    }
}
