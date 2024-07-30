using smartHealthApp.Common.Enum;
using smartHealthApp.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.Navigation
{

    public class NavigationResponse : PropertyChangeHelper
    {
        ObservableCollection<NavigationResponse> lst = null;

        #region Property
        public int Id { get; set; }
        public string Name { get; set; }
        private string iconKey;
        public string IconKey
        {
            get { return iconKey; }
            set { iconKey = value; OnPropertyChanged(); }
        }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(); }
        }
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; OnPropertyChanged(); }
        }
        #endregion


        #region Method
        public ObservableCollection<NavigationResponse> GetNavigationList()
        {
            try
            {
                return new ObservableCollection<NavigationResponse>
                {
                   new NavigationResponse { Id = (int)DashboardModules.AddEditUser, Name = "Add User", IsSelected = true, IsActive = true },
                   new NavigationResponse { Id = (int)DashboardModules.ManageUsers, Name = "Manage User", IsSelected = false, IsActive = true }
                };
            }
            catch (Exception ex)
            {
                // Log the exception (assuming a logging mechanism is in place)
                Console.WriteLine(ex); // Replace with your logging mechanism
                return new ObservableCollection<NavigationResponse>(); // Return an empty collection instead of null
            }


        }
        #endregion
    }
}
