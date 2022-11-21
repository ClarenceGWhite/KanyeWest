using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                var kanyeURL = "https://api.kanye.rest/";
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes/";
                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();

                Console.WriteLine($"Kanye says: {kanyeQuote}");
                Console.WriteLine($"Ron responded: {ronQuote}");
                Console.WriteLine();


            }



           
        }
    }
}
