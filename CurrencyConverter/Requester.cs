using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    public class Requester : IRequester
    {
        public async Task<decimal> RequestAsync(string currencyCode1, string currencyCode2)
        {
            string url = $"https://free.currconv.com/api/v7/convert?q={currencyCode1}_{currencyCode2}&compact=ultra&apiKey=414b804213365ca9925e";

            try //System.Net.WebException
            {
                var response = await WebRequest.Create(url).GetResponseAsync().ConfigureAwait(false);
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                        string str;
                        if ((str = stream.ReadToEnd()) != null)
                        {
                            JObject o = JObject.Parse(str);
                            var s = o[$"{currencyCode1}_{currencyCode2}"].ToString();

                            return Convert.ToDecimal(s);
                        }
                }
            }
            catch (WebException exception)
            {
                return -1;
            }
            return -1;
        }
    }
}
