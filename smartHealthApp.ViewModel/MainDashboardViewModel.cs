﻿using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.Navigation;
using smartHealthApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.Remoting.Messaging;

namespace smartHealthApp.ViewModel
{

    public class MainDashboardViewModel : PropertyChangeHelper
    {
        #region Ctor
        public MainDashboardViewModel()
        {
            IsLeftPanelVisible = Visibility.Visible;
            NavigationModelList = new NavigationResponse().GetNavigationList().Where(x => x.IsActive == true).ToObservableCollection();
            HandleLeftPanelCommand = new RelayCommandHelper(x => HandleLeftPanelVisibility());
            ItemSelectionCommand = new RelayCommandHelper(x => OnItemSelected(x));
            HeaderClickCommand = new RelayCommandHelper(x => OnHeaderSelected(x));
            BindDefaultView();
        }
        #endregion

        #region Properties
        private ObservableCollection<NavigationResponse> navigationModelList;
        public ObservableCollection<NavigationResponse> NavigationModelList
        {
            get { return navigationModelList; }
            set { navigationModelList = value; OnPropertyChanged(); }
        }

        private NavigationResponse _selectedListItem;
        public NavigationResponse SelectedListItem
        {
            get { return _selectedListItem; }
            set { _selectedListItem = value; BindDefaultView(); OnPropertyChanged(); }
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
        private Visibility _isLeftPanelVisible;
        public Visibility IsLeftPanelVisible
        {
            get { return _isLeftPanelVisible; }
            set { _isLeftPanelVisible = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        public RelayCommandHelper HandleLeftPanelCommand { get; set; }
        public RelayCommandHelper ItemSelectionCommand { get; set; }
        public RelayCommandHelper HeaderSelectionCommand { get; set; }
        public RelayCommandHelper HeaderClickCommand { get; set; }
        #endregion

        #region Methods
        public void BindDefaultView()
        {
            if (SelectedListItem == null || SelectedListItem.Id == 0)
            {
                SelectedListItem = NavigationModelList.FirstOrDefault();
                BindView(SelectedListItem.TitleHeader);
            }
        }

        public void HandleLeftPanelVisibility()
        {
            IsLeftPanelVisible = IsLeftPanelVisible == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        public void BindView(object x)
        {
            switch (x.ToString())
            {
                case "Add User":
                    CurrentView = new AddEditUserViewModel();
                    break;
                case "User List":
                    CurrentView = new ManageUserViewModel();
                    break;
                case "Dashboard":
                    CurrentView = new DashboardViewModel();
                    break;
                default:
                    CurrentView = new DashboardViewModel();
                    break;

            }
        }
        // Handle header selection(yo handle leaf node)
        private void OnHeaderSelected(object header)
        {
            if ((NavigationResponse)header != null)
            {
                var response = (NavigationResponse)header;
                BindView(response.TitleHeader.ToString());
            }
        }
        // Handle item selection
        private void OnItemSelected(object item)
        {
            BindView(item.ToString());
        }

        #endregion

    }

}
