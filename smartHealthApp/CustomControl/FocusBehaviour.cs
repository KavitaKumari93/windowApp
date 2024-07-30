using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp.CustomControl
{
    public static class FocusBehaviour
    {
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }

        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached(
                "IsFocused", typeof(bool), typeof(FocusBehaviour),
                new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        private static void OnIsFocusedPropertyChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement)d;
            if ((bool)e.NewValue)
            {
                System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input,
                new Action(delegate ()
                {
                    uie.Focus();
                }));
            }
        }
    }
}
