using System;
using System.Collections.Generic;

namespace CurrencyConverter.iOS
{
  static  public class FlagsData
    {

         public static Dictionary<string , FlagItem> FlagDictionary = new Dictionary<string, FlagItem>{ 
                { "AUD", new FlagItem(flagImage: "au", description: "Australian dollar") },
           { "CAD", new FlagItem(flagImage: "ca", description: "Canadian dollar") },
{ "DKK", new FlagItem(flagImage: "dk", description: "Danish krone") },
{ "EUR", new FlagItem(flagImage: "eu", description: "Euro") },

                { "GBP", new FlagItem(flagImage: "gb", description: "British pound") },
               { "JPY", new FlagItem(flagImage: "jp", description: "Japanese yen") },  
    { "NZD", new FlagItem(flagImage: "nz", description: "New Zeland dollar") },
      { "RUB", new FlagItem(flagImage: "ru", description: "Russian ruble") }, 
                { "UAH", new FlagItem(flagImage: "ua", description: "Ukrainian grivna") },
      { "USD", new FlagItem(flagImage: "us", description: "American dollar") }
            };
        }
        // public FlagItem[] flags = n

        //public static void InitDictionary () {
        //    FlagDictionary = new Dictionary<string, FlagItem>()
        //{
        //    {"AUD", new FlagItem(flagImage:"au" ,description: "Australian dollar" ) },
        //        {"JPY", new FlagItem(flagImage:"jp" ,description: "Japanese yen" ) },
        //        {"GBP", new FlagItem(flagImage:"gb" ,description: "British pound" ) },
        //        {"USD", new FlagItem(flagImage:"us" ,description: "American dollar" ) },
        //        {"CAD", new FlagItem(flagImage:"ca" ,description: "Canadian dollar" ) },
        //        {"EUR", new FlagItem(flagImage:"eu" ,description: "Euro" ) },
        //        {"DKK", new FlagItem(flagImage:"dk" ,description: "Danish krone" ) },
        //        {"RUB", new FlagItem(flagImage:"ru" ,description: "Russian ruble" ) },
        //        {"NZD", new FlagItem(flagImage:"nz" ,description: "New Zeland dollar" ) },
        //        {"UAH", new FlagItem(flagImage:"ua" ,description: "Ukrainian grivna" ) }
        //};


        //}
   // }

    public class FlagItem { 
        public FlagItem() { }
    
        public FlagItem (string flagImage, string description) {

            this.flagImage = flagImage;
            this.description = description;

        }

        public string flagImage { get; set; }
        public string description { get; set; }
       

    }

}
