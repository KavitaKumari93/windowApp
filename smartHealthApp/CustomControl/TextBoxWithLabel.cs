using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace smartHealthApp.CustomControl
{
    public class TextBoxWithLabel : TextBox
    {
        public static readonly DependencyProperty TextBoxInfoProperty;
        public static readonly DependencyProperty IsPasswordEnabledProperty;

        static TextBoxWithLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxWithLabel), new FrameworkPropertyMetadata(typeof(TextBoxWithLabel)));

            TextProperty.OverrideMetadata(
                typeof(TextBoxWithLabel),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(TextPropertyChanged)));

            TextBoxInfoProperty = DependencyProperty.Register(
            "TextBoxInfo",
            typeof(string),
            typeof(TextBoxWithLabel),
            new PropertyMetadata(string.Empty));

            IsPasswordEnabledProperty = DependencyProperty.Register(
                "IsPasswordEnabled", typeof(Boolean), typeof(TextBoxWithLabel), new FrameworkPropertyMetadata(false));
        }



        public Boolean IsPasswordEnabled
        {
            get { return (Boolean)base.GetValue(IsPasswordEnabledProperty); }
            set { base.SetValue(IsPasswordEnabledProperty, value); }
        }



        public string TextBoxInfo
        {
            get { return (string)GetValue(TextBoxInfoProperty); }
            set { SetValue(TextBoxInfoProperty, value); }
        }



        private static readonly DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterReadOnly(
            "HasText",
            typeof(bool),
            typeof(TextBoxWithLabel),
            new FrameworkPropertyMetadata(false));


        public static readonly DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        public bool HasText
        {
            get
            {
                return (bool)GetValue(HasTextProperty);
            }
        }

        public override void OnApplyTemplate()
        {
            PasswordBox passwordBox = base.GetTemplateChild("pwdBox") as PasswordBox;
            if (passwordBox != null)
            {
                passwordBox.PasswordChanged += delegate
                {
                    this.Text = passwordBox.Password;
                };
            }
            base.OnApplyTemplate();
        }
        private static void TextPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            TextBoxWithLabel itb = (TextBoxWithLabel)sender;

            bool actuallyHasText = itb.Text.Length > 0;

            if (actuallyHasText != itb.HasText)
            {
                itb.SetValue(HasTextPropertyKey, actuallyHasText);
            }
        }

    }
}
