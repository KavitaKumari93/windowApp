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
    /// Interaction logic for SetUpAgency.xaml
    /// </summary>
    public partial class SetUpAgency : UserControl
    {
        public SetUpAgency()
        {
            InitializeComponent();
            this.DataContext = new SetUpAgencyViewModel();
        }
    }
}
