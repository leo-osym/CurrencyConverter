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
    public static class FlagsDictionary
    {
        public static Dictionary<string, CurrencyKey> FlagDictionary { get; private set; }

        public static void InitDictionary()
        {
            FlagDictionary = new Dictionary<string, CurrencyKey>()
            {
                {"AUD", new CurrencyKey(flag:Resource.Mipmap.au,currencyDescription:"Australian dollar") },
                {"CAD",new CurrencyKey(flag:Resource.Mipmap.ca,currencyDescription:"Canadian dollar") },
                {"DKK",new CurrencyKey(flag:Resource.Mipmap.dk,currencyDescription:"Danish krone" )},
                {"EUR",new CurrencyKey(flag:Resource.Mipmap.eu,currencyDescription:"Euro") },
                {"GBP", new CurrencyKey(flag:Resource.Mipmap.gb,currencyDescription:"Pound sterling") },
                {"JPY", new CurrencyKey(flag:Resource.Mipmap.jp,currencyDescription:"Japanese yen")},
                {"NZD", new CurrencyKey(flag:Resource.Mipmap.nz,currencyDescription:"New Zealand dollar") },
                {"RUB", new CurrencyKey(flag:Resource.Mipmap.ru,currencyDescription:"Russia ruble") },
                {"UAH", new CurrencyKey(flag:Resource.Mipmap.ua,currencyDescription:"Ukraine hryvnia") },
                {"USD", new CurrencyKey(flag:Resource.Mipmap.us,currencyDescription:"United States dollar") },
            };


        }
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