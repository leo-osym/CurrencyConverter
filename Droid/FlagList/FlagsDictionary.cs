using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CurrencyConverter.Droid.FlagList
{
    public class FlagsDictionary
    {
        public static Dictionary<string, CurrencyKey> FlagDictionary  = new Dictionary<string, CurrencyKey>()
            {
                {"AUD", new CurrencyKey(flag:Resource.Mipmap.au,currencyDescription:"Австралийский доллар") },
                {"CAD",new CurrencyKey(flag:Resource.Mipmap.ca,currencyDescription:"Канадский доллар") },
                {"DKK",new CurrencyKey(flag:Resource.Mipmap.dk,currencyDescription:"Датская крона" )},
                {"EUR",new CurrencyKey(flag:Resource.Mipmap.eu,currencyDescription:"Евро") },
                {"GBP", new CurrencyKey(flag:Resource.Mipmap.gb,currencyDescription:"Фунт стерлингов") },
                {"JPY", new CurrencyKey(flag:Resource.Mipmap.jp,currencyDescription:"Японская йена")},
                {"NZD", new CurrencyKey(flag:Resource.Mipmap.nz,currencyDescription:"Новозеландский доллар") },
                {"RUB", new CurrencyKey(flag:Resource.Mipmap.ru,currencyDescription:"Российский рубль") },
                {"UAH", new CurrencyKey(flag:Resource.Mipmap.ua,currencyDescription:"Украинская гривна") },
                {"USD", new CurrencyKey(flag:Resource.Mipmap.us,currencyDescription:"Американский доллар") },
            };
        }

    public class CurrencyKey
    {
        public CurrencyKey(int flag, string currencyDescription)
        {
            Flag = flag;
            CurrencyDescription = currencyDescription;
        }

        public  int Flag { get; private set; }
        public string CurrencyDescription { get; private set; }
    }
}
