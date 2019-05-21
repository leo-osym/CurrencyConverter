using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CurrencyConverter.Droid.CustomView
{
    [Register("repos.CurrencyConverter.Droid.CustomView.CustomMainView")] 
    public class CustomMainView:RelativeLayout

    {
        private LayoutInflater _inflater;
        private Context _context;
        private Button _leftButton;
        private Button _rightButton;
        private Button _switch;
        private EditText _leftValue;
        private EditText _rightValue;

        public CustomMainView(Context context) : base(context)
        {
        }

        public CustomMainView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomMainView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CustomMainView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected CustomMainView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            _inflater = LayoutInflater.From(Context);
            _inflater.Inflate(Resource.Layout.Main, this, true);
            InitViewComponents();
        }

        private void InitViewComponents()
        {
            _leftButton = FindViewById<Button>(Resource.Id.left_button);
            _rightButton = FindViewById<Button>(Resource.Id.right_button);
            _switch = FindViewById<Button>(Resource.Id.switch_button);
            _leftValue = FindViewById<EditText>(Resource.Id.left_edit_text);
            _rightValue = FindViewById<EditText>(Resource.Id.right_edit_text);

        }
    }

   
}