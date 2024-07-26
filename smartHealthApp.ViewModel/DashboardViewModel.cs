using MahApps.Metro.Controls;
using smartHealthApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace smartHealthApp.ViewModel
{
    public class DashboardViewModel : PropertyChangeHelper
    {
        public DashboardViewModel()
        {
                
        }
        public RelayCommandHelper ShowLeftFlyoutCommand { get; set; }
        public RelayCommandHelper ShowRightFlyoutCommand { get; set; }

       ;

        private void ShowLeftFlyout()
        {
            var window = (MetroWindow)App.Current.MainWindow;
            var flyout = window.Flyouts.Items[0] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
        }

        private void ShowRightFlyout()
        {
            var window = (MetroWindow)App.Current.MainWindow;
            var flyout = window.Flyouts.Items[1] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
