﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace smartHealthApp.Converters
{
   
        public class InverseBooleanConverter : IValueConverter
        {

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool)
                {
                    return !(bool)value;
                }

                return null;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool)
                {
                    return !((bool)value);
                }

                return null;
            }
        }
    }

