using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CurrencyConverter.Droid.FlagList;

namespace CurrencyConverter.Droid.Activities
{
    [Activity(Label = "ActivityList", Icon = "@mipmap/icon", 
        ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ActivityList : Activity
    {
        private RecyclerView recycler;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter adapter;
        private string buttonSide;

        private string rightValue;
        private string leftValue;
        private string rightEditValue;
        private string leftEditValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.list_flags);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);


            if (Intent.HasExtra("buttonSide"))
            {
                buttonSide = Intent.GetStringExtra("buttonSide");

            }

            recycler = FindViewById<RecyclerView>(Resource.Id.recycler);
            //recycler.SetAdapter(adapter);
            recycler.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);

           
            adapter = new CurrencyAdapter(this,buttonSide);
            recycler.SetAdapter(adapter);
          
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}