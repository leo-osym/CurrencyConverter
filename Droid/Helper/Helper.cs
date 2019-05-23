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

namespace CurrencyConverter.Droid.Helper
{
    public static class Helper
    {
        public static int saveRightImage { get; set; } = Resource.Mipmap.ua;
        public static int saveLeftImage { get; set; } = Resource.Mipmap.us;
        public static string saveRightText { get; set; } = "UAH";
        public static string saveLeftText { get; set; } = "USD";
        public static string rightEditTextRepo { get; set; } = "";
        public static string leftEditTextRepo { get; set; } = "";

        public static int flag { get; set; } = 0;
    }
    
}