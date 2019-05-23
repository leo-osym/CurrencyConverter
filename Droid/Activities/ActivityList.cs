using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using CurrencyConverter.Droid.FlagList;

namespace CurrencyConverter.Droid.Activities
{
    [Activity(Label = "ActivityList", Icon = "@mipmap/icon")]
    public class ActivityList : Activity

    {
        private RecyclerView recycler;
        private RecyclerView.LayoutManager layoutManager;
        private RecyclerView.Adapter adapter;
        private bool buttonSide;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.list_flags);

            if (Intent.HasExtra("buttonSide"))
            {
                buttonSide = Intent.GetBooleanExtra("buttonSide", true);

            }

            recycler = FindViewById<RecyclerView>(Resource.Id.recycler);
            recycler.SetAdapter(adapter);
            recycler.HasFixedSize = true;
            layoutManager = new LinearLayoutManager(this);
            recycler.SetLayoutManager(layoutManager);

            //adapter = new RecyclerView.Adapter(FlagsDictionary.FlagDictionary());
            adapter = new CurrencyAdapter(this,buttonSide);
            recycler.SetAdapter(adapter);


           

        }

        
    }
}