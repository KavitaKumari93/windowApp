using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using smartHealthApp.ViewModel;

namespace smartHealthApp.UserControls
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : MetroWindow
    {
        

        public Dashboard()
        {
            InitializeComponent();
            this.DataContext = new DashboardViewModel();
           // leftNavigationTitle.Visibility = Visibility.Visible;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //leftNavigationTitle.IsOpen = !leftNavigationTitle.IsOpen;
            //flyoutTitle.Visibility= leftNavigationTitle.IsOpen?Visibility.Visible:Visibility.Collapsed;
            //if (leftPanelTitle.Visibility == Visibility.Visible)
            //{
            //    leftPanelTitle.Visibility = Visibility.Collapsed;
            //}
            //else
            //    leftPanelTitle.Visibility = Visibility.Visible;
        }
    }
}