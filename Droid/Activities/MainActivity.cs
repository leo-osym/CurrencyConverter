﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using CurrencyConverter.Droid.CustomView;
using System;
using Android.Content;
using CurrencyConverter.Droid.Activities;
using Android.Graphics;

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

            //var buttonLeft = FindViewById<Button>(Resource.Id.left_button);
            //buttonLeft.Click += delegate {
            //    var intent = new Intent(this, typeof(ActivityList));
            //    StartActivity(intent);
            //};
            //buttonLeft.Text = "Hello";
            //buttonLeft.SetTextColor(Color.Black);
        }

       
    }
}

