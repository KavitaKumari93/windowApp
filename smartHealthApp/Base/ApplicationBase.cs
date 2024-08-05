using smartHealthApp.Common;
using smartHealthApp.Common.AppMessenger;
using smartHealthApp.Common.Enum;
using smartHealthApp.UserControls;
using smartHealthApp.UserControls.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace smartHealthApp.Base
{
    public abstract class ApplicationBase : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationBase"/> class.
        /// </summary>
        public ApplicationBase()
        {
            AppMessenger.Register(this, OnMessageToApp);
        }
        public void OnMessageToApp(AppMessage message)
        {
            switch (message.MessageType)
            {
                case AppMessageType.Navigate:
                    NavigateWindowTo((NavigationMessageData)message.MessageData);
                    break;
                default:
                    break;
            }
        }


        #region Property
       

        public static MainWindow MainWindow { get; set; }
        public Login LoginUC { get; set; }
        public SetUpAgency SetUpAgencyUC { get; set; }
        public MainDashboardArea MainDashboardAreaUC { get; set; }
        public AddEditUser AddEditUserUC { get; set; }
        public ManageUsers ManageUsersUC  { get; set; }
        public Dashboard DashboardUC { get; set; }
        #endregion




        #region Methods
        private void NavigateWindowTo(NavigationMessageData messageData)
        {
            //Transition viewTransition = Transition.Left;
            //if (messageData.Transition != null)
            //    viewTransition = (Transition)messageData.Transition;
            switch (messageData.NavigationTarget)
            {

                case NavigationPages.Login:
                    if (LoginUC == null)
                    {
                        LoginUC = new Login();
                    }
                    MainWindow.BlockMainScreenArea.Content = LoginUC;
                    break;

                case NavigationPages.SetUpForAgency:
                    if (SetUpAgencyUC == null)
                    {
                        SetUpAgencyUC = new SetUpAgency();
                    }
                    MainWindow.BlockMainScreenArea.Content = SetUpAgencyUC;
                    break;

                case NavigationPages.MainDashboard:
                    if (MainDashboardAreaUC == null)
                    {
                        MainDashboardAreaUC = new MainDashboardArea();
                    }
                    MainWindow.BlockMainScreenArea.Content = MainDashboardAreaUC;
                    break;
                case NavigationPages.Dashboard:
                    if (DashboardUC == null)
                    {
                        DashboardUC = new Dashboard();
                    }
                    MainWindow.BlockMainScreenArea.Content = DashboardUC;
                    break;

            }
        }




        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="messageData">The message data.</param>
        private void CloseWindow(NavigationMessageData messageData)
        {
        }
    }
    #endregion





}

