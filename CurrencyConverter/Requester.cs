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
            string url = $"https://free.currconv.com/api/v7/convert?q={currencyCode1}_{currencyCode2}&compact=ultra&apiKey=f731dbae8f77ddac4d07";

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


        //public async Task<decimal> RequestAsync(string currencyCode1, string currencyCode2)
        //{
        //    using (var client = new System.Net.Http.HttpClient())
        //    {
        //        string url = $"https://free.currconv.com/api/v7/convert?q={currencyCode1}_{currencyCode2}&compact=ultra&apiKey=f731dbae8f77ddac4d07";

        //        client.BaseAddress = new Uri(url);
        //        var result = await client.GetAsync("/myEndpoint");
        //        if (result.IsSuccessStatusCode && result.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            //ok to process
        //            var str = await result.Content.ReadAsStringAsync();
                                                              
        //            JObject o = JObject.Parse(str);
        //            return Convert.ToDecimal(o[$"{currencyCode1}_{currencyCode2}"]);                                          
        //        }
        //    }
        //    return -1M;
        //}
    }
}
