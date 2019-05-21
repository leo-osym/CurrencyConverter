using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    class Requester : IRequester
    {
        public async Task<decimal> RequestAsync(string currencyCode1, string currencyCode2)
        {
            string url = $"https://free.currconv.com/api/v7/convert?q={currencyCode1}_{currencyCode2}&compact=ultra&apiKey=f731dbae8f77ddac4d07";

            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                string str;
                if ((str = stream.ReadToEnd()) != null)
                {
                    JObject o = JObject.Parse(str);
                    return Convert.ToDecimal(o[$"{currencyCode1}_{currencyCode2}"]);
                }
            }
            return -1;
        }

    }
}
