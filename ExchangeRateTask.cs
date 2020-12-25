using System;
using System.IO;
using System.Net;

namespace MyDataStructure
{
    class Program
    {
        public static double ExchangeRate(string from, string to)
        {
            var rssFeed = RssFeed();
            if (from == "USD" && to == "GEL")
            {
                var usdResult = rssFeed.Substring(rssFeed.IndexOf("USD"), 47);
                return Convert.ToDouble(usdResult.Substring(41));
            }

            if (from != "EUR" || to != "GEL") return 0;
            string eurResult = rssFeed.Substring(rssFeed.IndexOf("EUR"), 41);
            return Convert.ToDouble(eurResult.Substring(35));

        }

        private static string RssFeed()
        {
            var request = WebRequest.Create("http://www.nbg.ge/rss.php").GetResponse().GetResponseStream();
            var reader = new StreamReader(request);
            return reader.ReadToEnd();
        }

        static void Main(string[] args)
        {
            var usdToGel = ExchangeRate("USD", "GEL");
            Console.WriteLine(usdToGel);

            var eurToGel = ExchangeRate("EUR", "GEL");
            Console.WriteLine(eurToGel);
        }
    }
}