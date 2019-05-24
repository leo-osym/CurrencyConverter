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
using CurrencyConverter.Droid.Activities;

namespace CurrencyConverter.Droid.FlagList
{
    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageView { get; set; }
        public TextView FlagsDescriprion { get; set; }
        public TextView FlagsId { get; set; }
        public LinearLayout CardsId { get; set; }

        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            CardsId = itemView.FindViewById<LinearLayout>(Resource.Id.cards_id);
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.card_flags);
            FlagsId = itemView.FindViewById<TextView>(Resource.Id.flags_id);
            FlagsDescriprion = itemView.FindViewById<TextView>(Resource.Id.flags_description);
        }
    }

    class CurrencyAdapter : RecyclerView.Adapter
    {
        public override int ItemCount { get { return FlagsDictionary.FlagDictionary.Count; } }
        private Context context;
        private string buttonSide;

        public CurrencyAdapter(Context context, string buttonSide)
        {
            this.context = context;
            this.buttonSide = buttonSide;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            var keysList = FlagsDictionary.FlagDictionary.Keys.ToList();
            var code = keysList[position];
            FlagsDictionary.FlagDictionary.TryGetValue(code, out var CurrencyObj);
            var flag = CurrencyObj.Flag;
            var desc = CurrencyObj.CurrencyDescription;
            viewHolder.ImageView.SetImageResource(flag);
            viewHolder.FlagsId.Text = code;
            viewHolder.FlagsDescriprion.Text = "  —  " + desc;
            holder.ItemView.Click += delegate
            {            
                var intent = new Intent();
                intent.PutExtra("code", code);
                intent.PutExtra("image", flag);
                intent.PutExtra("buttonSide", buttonSide);
                (context as Activity).SetResult(Result.Ok, intent);
                (context as Activity).Finish();              
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.layout_card, parent, false);
            return new RecyclerViewHolder(itemView);
        }
    }
}