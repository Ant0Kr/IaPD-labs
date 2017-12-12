using System;
using System.ComponentModel;

namespace CDBurn
{
    public static class Helper
    {
        public static string ToReadableString(this Enum _enum)
        {
            if (_enum == null) return null;
            var description = _enum.ToString();
            try
            {
                var fi = _enum.GetType().GetField(_enum.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    description = attributes[0].Description;
            }
            catch
            {
                // ignored
            }
            return description;
        }
    }
}