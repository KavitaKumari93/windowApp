using smartHealthApp.Common;
using smartHealthApp.Common.AppMessenger;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using smartHealthApp.UserControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Window window = ChekIfAgencyDetailsExists() ? new MainWindow { Content = new Login() } : new MainWindow { Content = new SetUpAgency() };
            //window.Show();
        }

        public bool ChekIfAgencyDetailsExists()
        {
            OrganizationModel organizationModel =new OrganizationModel();
            return CommonMethods.ReadFile(organizationModel)!=null?true:false;
        }
       

    }

  
}





