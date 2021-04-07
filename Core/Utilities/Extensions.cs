using System;

namespace Core.Utilities
{
    public static class Extensions
    {
        public static bool CorreactLatLong(this string value)
        {
            return true;
        }
        public static string TrimSafe(this string value)
        {
            return (value ?? "").Trim();
        }
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static T ThrowExceptionIfNull<T>(this T value, string message = "") where T : class
        {
            if (value.IsNull())
                throw new InvalidDataException(message);
            return value;
        }
        public static string ThrowExceptionIfNullOrEmpty(this string value, string message = "")
        {
            var val = (value ?? "").Trim();
            if (string.IsNullOrEmpty(val))
                throw new InvalidDataException(message);
            return value;
        }
        public static Guid ToGuid(this string value)
        {
            if (!Guid.TryParse(value, out var guid))
                throw new InvalidDataException($"can not convert {value} to guid");
            return guid;
        }
        public static string CheckIsValidLocation(this string location)
        {
            return decimal.TryParse(location ?? "", out var c) ? location.Trim() :
                throw new InvalidDataException("invalid location");
        }
    }
}
