using MahApps.Metro.Controls;
using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace smartHealthApp.ViewModel
{
    

    public class DashboardViewModel : PropertyChangeHelper
    {
        #region Ctor
        public DashboardViewModel()
        {
          
        }
        #endregion

        #region Properties
        
        #endregion

        #region Commands
        public RelayCommandHelper Command1 { get; set; }
        public RelayCommandHelper Command2 { get; set; }
        public RelayCommandHelper Command3 { get; set; }
        #endregion

        #region Methods
        public void Method1()
        {
           
        }

        public void Method2()
        {
           
        }
        
       
        private void Method3(object x)
        {  
        }  
      
        #endregion

    }
}
