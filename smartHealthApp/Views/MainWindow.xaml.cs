using smartHealthApp.Base;
using smartHealthApp.UserControls;
using smartHealthApp.ViewModel;
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

namespace smartHealthApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow:ApplicationBase
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindow = this;
            this.DataContext =new MainViewModel();

        }
    }
}
