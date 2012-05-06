using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hexagonvitals.Test
{

    public static class ObjectUtilities
    {
        public static Dictionary<string, object> GetAllProperties(object o)
        {
            var bag = new Dictionary<string, object>();

            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                bag[p.Name] = p.GetValue(o, null);
            }
            return bag;
        }

        public static string PrintDictionary<K, V>(Dictionary<K, V> dictionary)
        {
            var sb = new StringBuilder();
            foreach (K key in dictionary.Keys)
            {
                sb.AppendLine("{0} = {1}".FormatWith(key, PrettyPrint(dictionary[key])));
            }
            return sb.ToString();
        }

        private static string PrettyPrint(object o)
        {
            var defaultString = "" + o;

            if (o is string)
            {
                return defaultString;
            }
            if (o is DictionaryEntry)
            {
                var d = (DictionaryEntry)o;
                return "{0} => '{1}'".FormatWith(d.Key, d.Value);
            }
            if (o is IEnumerable)
            {
                var o2 = ((IEnumerable)o).Cast<object>();
                return "[{0}]".FormatWith(string.Join(",", o2.Select(PrettyPrint)));
            }

            if (defaultString.Contains(Environment.NewLine))
            {
                return "[{0}]".FormatWith(defaultString.Trim().Replace(Environment.NewLine, ", "));
            }
            return defaultString;
        }

        public static string GetPropertiesAsString(this object o)
        {
            return PrintDictionary(GetAllProperties(o));
        }
    }
}
