using CommonLiberaryCore.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CommonLiberaryCore.Utilities
{
    public  class Utils
    {
        public static DataTable ConvertListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;

        }
        public static string CreatePassword(int length, bool encrypt)
        {
            string passw = "";
            try
            {
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                passw = res.ToString();
                if (!encrypt)
                    return passw;
            }
            catch
            {
                throw new Exception("Something went wrong!");
            }
            return Encryption.Encrypt(passw);
        }
        public static string CreateUniqueApplicationNo(int length)
        {
            try
            {
                const string valid = "123456789123456789123456789";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                return res.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static string GenerateNumericOTP(int digit = 4)
        {
            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < digit; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            return strrandom;
        }

        public static string CreateRandomGuidNo()
        {
            var str = SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd).ToString().Split('-');

            var output = str[str.Length - 1];
            output += CreateUniqueApplicationNo(20 - (output.Length));
            return output;
        }


        public static string GenerateUniqueOrderId(int length)
        {
            try
            {
                var orderId = System.DateTime.Now.ToString("yyyyMMddhhmmss") + CreateUniqueApplicationNo(length);
                return orderId;
            }
            catch
            {
                return CreateUniqueApplicationNo(length);
            }
        }

        public static string GetIPAddress()
        {
            var _IPAddress = "";
            IPHostEntry? Host = default;
            string? Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    _IPAddress = Convert.ToString(IP);
                }
            }
            return _IPAddress;
        }
        public static string GetQueryStringFromModelClass(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p?.GetValue(obj, null)?.ToString());

            return String.Join("&", properties.ToArray());
        }
        public static string cleanString(string str)
        {

            //-- Only alpha - numeric - and hyphen,
            return Regex.Replace(str, @"[^0-9a-zA-Z-]+", "");
        }

        /// <summary>
        /// Checks the string if its Email or Mobile
        /// </summary>
        /// <param name="emailOrPhone"></param>
        /// <returns>Item1 : isEmail | Item2 : isPhone</returns>
        public static Tuple<bool, bool> IsValidEmailOrPhone(string emailOrPhone)
        {
            bool phone = Regex.IsMatch(emailOrPhone, @"^[7-9][0-9]{9}$", RegexOptions.IgnoreCase);
            bool email = Regex.IsMatch(emailOrPhone, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            return Tuple.Create(email, phone);
        }
    }
}
