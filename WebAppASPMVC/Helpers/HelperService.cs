using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppASPMVC.Helpers
{
    public static class HelperService
    {
        public static string WriteCsv<T>(List<T> data)
        {
            var properties = typeof(T).GetProperties();
            var header = string.Join(",", properties.Select(p => p.Name));
            var rows = data.Select(d => string.Join(",", properties.Select(p => EscapeCsvValue(p.GetValue(d, null))))).ToList();

            return string.Format("{0}\n{1}", header, string.Join("\n", rows));
        }

        private static string EscapeCsvValue(object value)
        {
            if (value == null) return "";

            var stringValue = value.ToString();
            if (stringValue.Contains(",") || stringValue.Contains("\""))
            {
                return string.Format("\"{0}\"", stringValue.Replace("\"", "\"\""));
            }

            return stringValue;
        }

    }
}