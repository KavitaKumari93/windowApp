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
            IsLeftPanelVisible = Visibility.Visible;
            NavigationModelList = new NavigationResponse().GetNavigationList().Where(x => x.IsActive == true).ToObservableCollection();
            HandleLeftPanelCommand = new RelayCommandHelper(x => HandleLeftPanelVisibility());
            BindSelectedView();
        }
        #endregion

        #region Properties
        private ObservableCollection<NavigationResponse> navigationModelList = null;
        public ObservableCollection<NavigationResponse> NavigationModelList
        {
            get { return navigationModelList; }
            set { navigationModelList = value; OnPropertyChanged(); }
        }

        private bool isLoaderActive;
        public bool IsLoaderActive
        {
            get { return isLoaderActive; }
            set { isLoaderActive = value; OnPropertyChanged(); }
        }
        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set { currentView = value; OnPropertyChanged(); }
        }
        private NavigationResponse selectedMenu;
        public NavigationResponse SelectedMenu
        {
            get { return selectedMenu; }
            set
            {
                selectedMenu = value; if (selectedMenu != null) { BindSelectedView(); }
                OnPropertyChanged();
            }
        }

        private Visibility _isLeftPanelVisible;
        public Visibility IsLeftPanelVisible
        {
            get { return _isLeftPanelVisible; }
            set { _isLeftPanelVisible = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public RelayCommandHelper HandleLeftPanelCommand { get; set; }
        #endregion

        #region Methods
        public void BindSelectedView()
        {
            if (SelectedMenu == null || SelectedMenu.Id == 0)
            {
                SelectedMenu = NavigationModelList[0];
            }
            switch (SelectedMenu.Id)
            {
                case 1:
                    CurrentView = new AddEditUserViewModel();
                    break;
                case 2:
                    CurrentView = new ManageUserViewModel();
                    break;
                default:
                    CurrentView = new AddEditUserViewModel();
                    break;
            }
        }

        public void HandleLeftPanelVisibility()
        {
            IsLeftPanelVisible = IsLeftPanelVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        #endregion

    }
}
