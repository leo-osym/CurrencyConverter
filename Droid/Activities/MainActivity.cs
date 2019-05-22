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
using Android.Graphics.Drawables;

namespace CurrencyConverter.Droid
{
    [Activity(Label = "CurrencyConverter", Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private RelativeLayout leftLayout;
        private RelativeLayout rightLayout;
        private CustomMainView _customView;
        private ImageView rightImage;
        private ImageView leftImage;
        private TextView rightText;
        private TextView leftText;
        private Button switchButton;
        private EditText leftEditText;
        private EditText rightEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
          
            leftLayout = FindViewById<RelativeLayout>(Resource.Id.left_layout);
            rightLayout = FindViewById<RelativeLayout>(Resource.Id.right_layout);
            rightImage = FindViewById<ImageView>(Resource.Id.right_flag);
            rightText = FindViewById<TextView>(Resource.Id.right_key);
            leftImage = FindViewById<ImageView>(Resource.Id.left_flag);
            leftText = FindViewById<TextView>(Resource.Id.left_key);
            switchButton = FindViewById<Button>(Resource.Id.switch_button);
            leftEditText = FindViewById<EditText>(Resource.Id.left_edit_text);
            rightEditText = FindViewById<EditText>(Resource.Id.right_edit_text);


            rightLayout.Click += delegate
            {
                var intent = new Intent(this, typeof(ActivityList));
                intent.PutExtra("buttonSide", true);
                StartActivity(intent);
            };

            leftLayout.Click += delegate
            {
                var intent = new Intent(this, typeof(ActivityList));
                intent.PutExtra("buttonSide", false);
                StartActivity(intent);
            };

            switchButton.Click += delegate
            {
                Reverse();
            };
                
        }

        private void Reverse()
        {
            var flagTemp = GetBitmap(leftImage);
            var keyTemp = leftText.Text;
            var editTemp = leftEditText.Text;
                        
            leftImage.SetImageBitmap(GetBitmap(rightImage));
            leftText.SetText(rightText.Text, null);
            leftEditText.SetText(rightEditText.Text, null);

            rightImage.SetImageBitmap(flagTemp);
            rightText.SetText(keyTemp,null);
            rightEditText.SetText(editTemp, null);
                      
        }

        private Bitmap GetBitmap(ImageView view)
        {
            view.BuildDrawingCache(true);
            Bitmap bitmap = view.GetDrawingCache(true);
            BitmapDrawable drawable = (BitmapDrawable)view.Drawable;
            bitmap = drawable.Bitmap;
            return bitmap;
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (Intent.HasExtra("buttonSide"))
            {
                var flag = Intent.GetIntExtra("image", 0);
                var key = Intent.GetStringExtra("id");
                var buttonSide = Intent.GetBooleanExtra("buttonSide", true);
                SetFlag(flag, key, buttonSide);
            }

        }

        private void SetFlag(int flag, string key, bool buttonSide)
        {
            switchButton.Clickable = true;
            if (buttonSide)
            {
               
                rightImage.SetImageResource(flag);
                rightText.SetText(key, null);
                Helper.Helper.saveRightImage = flag;
                Helper.Helper.saveRightText = key;
                leftImage.SetImageResource(Helper.Helper.saveLeftImage);
                leftText.SetText(Helper.Helper.saveLeftText, null);
            }
            else
            {
               
                leftImage.SetImageResource(flag);
                leftText.SetText(key, null);
                Helper.Helper.saveLeftImage = flag;
                Helper.Helper.saveLeftText = key;
                rightImage.SetImageResource(Helper.Helper.saveRightImage);
                rightText.SetText(Helper.Helper.saveRightText, null);
            }
        }
    }
}

