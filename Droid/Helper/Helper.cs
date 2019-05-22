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
        public static int saveRightImage { get; set; } = Resource.Mipmap.ca;
        public static int saveLeftImage { get; set; } = Resource.Mipmap.au;
        public static string saveRightText { get; set; } = "CAD";
        public static string saveLeftText { get; set; } = "AUD";
        
    }
    
}