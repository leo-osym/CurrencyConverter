using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using CurrencyConverter.Droid.CustomView;
using System;
using Android.Content;
using CurrencyConverter.Droid.Activities;
using Android.Graphics;
using CurrencyConverter.Droid.FlagList;

namespace CurrencyConverter.Droid
{
    [Activity(Label = "CurrencyConverter", Icon = "@mipmap/icon")]
    public class MainActivity :Activity
    {

        private CustomMainView _customView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            _customView = new CustomMainView(this);
            var leftLayout = FindViewById<RelativeLayout>(Resource.Id.left_layout);
            var righttLayout = FindViewById<RelativeLayout>(Resource.Id.right_layout);
            var leftFlag = FindViewById<ImageView>(Resource.Id.left_flag);
            var leftId = FindViewById<TextView>(Resource.Id.left_key);
            leftFlag.SetBackgroundResource(Resource.Mipmap.au);
            leftLayout.Click += delegate
            {
                StartActivity(typeof(ActivityList));
            };
            //var buttonLeft = FindViewById<Button>(Resource.Id.left_button);
            //var buttonRight = FindViewById<Button>(Resource.Id.right_button);
            //buttonLeft.Click += delegate
            //{
            //    var intent = new Intent(this, typeof(ActivityList));
            //    StartActivity(intent);
            //    //};
               
            //};

            //buttonLeft.Text = FlagsDictionary.FlagDictionary["AUD"].CurrencyDescription;
            //buttonLeft.SetTextColor(Color.Black);
            //buttonLeft.TextSize = 5;
            //buttonLeft.TextAlignment = Android.Views.TextAlignment.ViewEnd;
            //buttonLeft.SetCompoundDrawablesWithIntrinsicBounds(FlagsDictionary.FlagDictionary["AUD"].Flag, 0, 0, 0);

            
        }

       
    }
}

