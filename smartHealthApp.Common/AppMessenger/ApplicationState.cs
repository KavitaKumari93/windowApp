using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Common.AppMessenger
{
    public static class ApplicationState
    {
        private static Dictionary<string, object> _values =
                   new Dictionary<string, object>();
        public static void SetValue(string key, object value)
        {
            if (_values.ContainsKey(key))
            {
                _values.Remove(key);
            }
            _values.Add(key, value);
        }

        public static T GetValue<T>(string key)
        {
            if (_values.ContainsKey(key))
            {
                return (T)_values[key];
            }
            else
            {
                return default(T);
            }
        }

        public static T GetValueAndClear<T>(string key)
        {
            if (_values.ContainsKey(key))
            {
                T valueToReturn = (T)_values[key];
                ClearKey(key);
                return valueToReturn;
            }
            else
            {
                return default(T);
            }
        }

        public static void ClearData()
        {
            _values.Clear();
        }

        public static void ClearKey(string key)
        {
            if (_values.ContainsKey(key))
            {
                _values.Remove(key);
            }
        }
    }
}
