using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationRazorApexcharts
{
    public class Utils
    {

        public static DateTime RandomDay()
        {
            Random rnd = new Random();
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
        public static string GetMonthName(int month)
        {

            DateTime date = new DateTime(2010, month, 1);
            return date.ToString("MMMM");

        }
        public static (string key, string value) KeyValuePairToArray(List<KeyValuePair<string, int>> list)

        {
            if (list == null)
            {
                return ("'Veri Bulunamadı!'", "0");
            }
            if (list.Count == 0)
            {
                return ("'Veri Bulunamadı!'", "0");
            }
            string key = string.Empty;
            string value = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    key = "'" + list[i].Key + "'";
                    value = list[i].Value.ToString();
                }
                else
                {
                    key = key + ",'" + list[i].Key + "'";
                    value = value + "," + list[i].Value;
                }
            }

            return (key, value);
        }
        public static string KeyValuePairToString(List<KeyValuePair<string, int>> list)

        {
            if (list == null)
            {
                return "{x:'Veri Bulunamadı', y:1},";
            }
            if (list.Count == 0)
            {
                return "{x:'Veri Bulunamadı', y:1},";
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append("{x:'" + item.Key + "', y:" + item.Value + "},");
            }
            return sb.ToString();
        }
        public static bool SayiTekMi(int sayi)
        {
            if (sayi % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
