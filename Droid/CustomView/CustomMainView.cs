using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
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
        private RelativeLayout _leftLayout;
        private RelativeLayout _rightLayout;
        private Button _switch;
        private EditText _leftValue;
        private EditText _rightValue;

        public event Action LeftButton;

        public CustomMainView(Context context) : base(context)
        {
            _context = context;
            Init();
        }

        public CustomMainView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            _context = context;
            Init();
        }

        public CustomMainView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            _context = context;
            Init();
        }

        public CustomMainView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            _context = context;
            Init();
        }

        protected CustomMainView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
           
        }


        protected  void Init()
        {
           
            _inflater = LayoutInflater.From(Context);
            _inflater.Inflate(Resource.Layout.Main, this, true);
            InitViewComponents();
            //var draw = ContextCompat.GetDrawable(_context, Resource.Mipmap.au);
            //_leftButton.SetCompoundDrawablesWithIntrinsicBounds(draw, null, null, null);
          
            


        }

        

        public void InitViewComponents()
        {
            _leftLayout = FindViewById<RelativeLayout>(Resource.Id.left_layout);
            _rightLayout = FindViewById<RelativeLayout>(Resource.Id.right_layout);
            _switch = FindViewById<Button>(Resource.Id.switch_button);
            _leftValue = FindViewById<EditText>(Resource.Id.left_edit_text);
            _rightValue = FindViewById<EditText>(Resource.Id.right_edit_text);

        }
    }

   
}