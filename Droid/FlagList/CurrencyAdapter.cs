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

namespace CurrencyConverter.Droid.FlagList
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageView { get; set; }
        public TextView FlagsDescriprion { get; set; }
        public TextView FlagsId { get; set; }
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.card_flags);
            FlagsId = itemView.FindViewById<TextView>(Resource.Id.flags_id);
            FlagsDescriprion = itemView.FindViewById<TextView>(Resource.Id.flags_description);


        }

    }
    class CurrencyAdapter : RecyclerView.Adapter
    {

        public override int ItemCount {get { return FlagsDictionary.FlagDictionary.Count; } }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            var keysList = FlagsDictionary.FlagDictionary.Keys.ToList();
            var key = keysList[position];
            FlagsDictionary.FlagDictionary.TryGetValue(key, out var CurrencyObj);
            var flag = CurrencyObj.Flag;
            var desc = CurrencyObj.CurrencyDescription;
            viewHolder.ImageView.SetImageResource(flag);
            viewHolder.FlagsId.Text = key;
            viewHolder.FlagsDescriprion.Text = desc;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.layout_card, parent, false);
            return new RecyclerViewHolder(itemView);
        }
    }
}