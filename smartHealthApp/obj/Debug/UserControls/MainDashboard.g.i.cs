// Updated by XamlIntelliSenseFileGenerator 7/23/2024 3:47:33 PM
#pragma checksum "..\..\..\UserControls\MainDashboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "304D2E29D8EEFB06CC4EAFDC6A1852EC7E8452ADAC59CBCABF6B78B9AC09AB53"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using smartHealthApp.UserControls;
using smartHealthApp.ViewModel;


namespace smartHealthApp.UserControls
{


    /// <summary>
    /// MainDashboard
    /// </summary>
    public partial class MainDashboard : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/smartHealthApp;component/usercontrols/maindashboard.xaml", System.UriKind.Relative);

#line 1 "..\..\..\UserControls\MainDashboard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.flyout = ((MahApps.Metro.Controls.FlyoutsControl)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal MahApps.Metro.Controls.FlyoutsControl flyoutIcon;
        internal MahApps.Metro.Controls.Flyout leftNavigationIcons;
        internal System.Windows.Controls.ListView lstIconPanel;
        internal System.Windows.Shapes.Path Icon_Refresh;
        internal System.Windows.Controls.ListView lstTitlePanel;
        internal System.Windows.Shapes.Path Title_IconRefresh;
        internal System.Windows.Controls.TextBlock myTextBlock;
        internal System.Windows.Controls.TextBlock syncTextBox;
        internal System.Windows.Controls.Button MinimizeButton;
        internal System.Windows.Controls.Button MaximizeButton;
        internal System.Windows.Controls.Button CloseButton;
        internal System.Windows.Controls.ContentPresenter workingRegion;
    }
}

