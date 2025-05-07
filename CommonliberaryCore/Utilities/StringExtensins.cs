using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLiberaryCore.Utilities
{
    public static class StringExtensins
    {
        public static string ToNullSafeString(this object value)
        {
            return value?.ToString();

        }

        // Characters that are used in base64 strings.
        private static Char[] Base64Chars = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/' };
        /// <summary>
        /// Extension method to test whether the value is a base64 string
        /// </summary>
        /// <param name="value">Value to test</param>
        /// <returns>Boolean value, true if the string is base64, otherwise false</returns>
        // Make it private as there is the name makes no sense for an outside caller
        private static Boolean IsInvalid(char value)
        {
            var intValue = (Int32)value;
            if (intValue >= 48 && intValue <= 57)
                return false;
            if (intValue >= 65 && intValue <= 90)
                return false;
            if (intValue >= 97 && intValue <= 122)
                return false;
            return intValue != 43 && intValue != 47;
        }
        public static bool IsBase64String(this string value)
        {
            if (value == null || value.Length == 0 || value.Length % 4 != 0
             || value.Contains(' ') || value.Contains('\t') || value.Contains('\r') || value.Contains('\n'))
                return false;
            var index = value.Length - 1;
            if (value[index] == '=')
                index--;
            if (value[index] == '=')
                index--;
            for (var i = 0; i <= index; i++)
                if (IsInvalid(value[i]))
                    return false;
            return true;

        }

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEmpty(this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string GetFileExtension(this string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "png";
                case "AAAAF":
                    return "mp4";
                case "JVBER":
                    return "pdf";
                case "AAABA":
                    return "ico";
                case "UMFYI":
                    return "rar";
                case "E1XYD":
                    return "rtf";
                case "U1PKC":
                    return "txt";
                case "MQOWM":
                case "77U/M":
                    return "srt";
                case "/9J/4":
                default:
                    return "jpg";
            }
        }
    }
}
