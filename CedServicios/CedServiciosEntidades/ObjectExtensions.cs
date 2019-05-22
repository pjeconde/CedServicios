using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static bool IsNull(this object obj)
        {
            return (obj == null || obj == DBNull.Value);
        }

        public static Decimal AsDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static Int64 AsInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }

        public static Int32 AsInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static Int32 AsInt32NullDefault(this object obj, int defaultValue)
        {
            if (obj == null || obj == DBNull.Value)
                return defaultValue;

            return Convert.ToInt32(obj);
        }

        public static Int16 AsInt16(this object obj)
        {
            return Convert.ToInt16(obj);
        }

        public static Single AsSingle(this object obj)
        {
            return Convert.ToSingle(obj);
        }

        public static Double AsDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static String AsString(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return string.Empty;

            return Convert.ToString(obj);
        }

        public static Boolean AsBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static DateTime AsDateTime(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return new DateTime();

            return Convert.ToDateTime(obj);
        }

        public static String IsNullAsString(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return string.Empty;

            return Convert.ToString(obj);
        }

        public static int _ToInt32(this string value)
        {
            int r;

            int.TryParse(value, out r);

            return r;
        }

        public static int? _ToNullableInt32(this string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                int r;

                if (int.TryParse(value, out r))
                    return r;
            }

            return null;
        }
    }
}