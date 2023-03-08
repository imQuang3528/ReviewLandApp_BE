using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Utility
{
    public static class ExtensionUtility
    {
        public static T Get<T>(this Dictionary<string, object> dic, string key)
        {
            T value = default(T);
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null && converter.IsValid(dic[key].ToString()))
                {
                    return (T)converter.ConvertFromString(dic[key].ToString());
                }
            }
            return value;
        }
    }
}
