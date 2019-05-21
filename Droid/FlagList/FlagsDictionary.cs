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
        public Dictionary<string, CurrencyKey> FlagDictionary { get; private set; }        

        public void InitDictionary()
        {
            FlagDictionary = new Dictionary<string, CurrencyKey>()
            {

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

        private int Flag { get; set; }
        private string CurrencyDescription { get; set; }
    }
}