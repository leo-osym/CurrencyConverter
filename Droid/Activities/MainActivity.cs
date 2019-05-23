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
using CurrencyConverter;
using System.Threading.Tasks;
using Android;

namespace CurrencyConverter.Droid
{
    [Activity(Label = "CurrencyConverter", Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Interactor interactor;
        Requester reqester;

        bool isSwiped = false;
        int flag = 0;

        private RelativeLayout leftLayout;
        private RelativeLayout rightLayout;  
        private ImageView rightImage;
        private ImageView leftImage;
        private TextView rightText;
        private TextView leftText;
        private Button switchButton;
        private EditText leftEditText;
        private EditText rightEditText;
        private TextView topTextView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            reqester = new Requester();
            interactor = new Interactor(reqester);

            leftLayout = FindViewById<RelativeLayout>(Resource.Id.left_layout);
            rightLayout = FindViewById<RelativeLayout>(Resource.Id.right_layout);
            rightImage = FindViewById<ImageView>(Resource.Id.right_flag);
            rightText = FindViewById<TextView>(Resource.Id.right_key);
            leftImage = FindViewById<ImageView>(Resource.Id.left_flag);
            leftText = FindViewById<TextView>(Resource.Id.left_key);
            switchButton = FindViewById<Button>(Resource.Id.switch_button);
            leftEditText = FindViewById<EditText>(Resource.Id.left_edit_text);
            rightEditText = FindViewById<EditText>(Resource.Id.right_edit_text);
            topTextView = FindViewById<TextView>(Resource.Id.update_data);

            topTextView.TextChanged += TopTextView_TextChanged;
            leftEditText.TextChanged += LeftEditText_TextChanged;
            rightEditText.TextChanged += RightEditText_TextChanged;

      
            rightLayout.Click += delegate
            {
                Helper.Helper.flag = 2;
                var intent = new Intent(this, typeof(ActivityList));
                intent.PutExtra("buttonSide", true);
                Helper.Helper.leftEditTextRepo = leftEditText.Text;
                Helper.Helper.rightEditTextRepo = rightEditText.Text;
                StartActivity(intent);
             
                
            };

            leftLayout.Click += delegate
            {
                Helper.Helper.flag = 1;
                var intent = new Intent(this, typeof(ActivityList));
                intent.PutExtra("buttonSide", false);
                Helper.Helper.leftEditTextRepo = leftEditText.Text;
                Helper.Helper.rightEditTextRepo = rightEditText.Text;
                StartActivity(intent);
            };

            switchButton.Click += delegate
            {              
                Reverse();
                
            };          
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
        
            outState.PutString("leftEditText", leftEditText.Text);
            outState.PutString("rightEditText", rightEditText.Text);
        

            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            leftEditText.Text = savedInstanceState.GetString("leftEditText");
            rightEditText.Text = savedInstanceState.GetString("rightEditText");

        }
     
        private void TopTextView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {           
            topTextView.TextChanged -= TopTextView_TextChanged;

            leftEditText.SetTextColor(Color.Black);
            rightEditText.SetTextColor(Color.Black);

            leftEditText.Enabled = true;
            rightEditText.Enabled = true;                    
        }
     

        private async void LeftEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (leftEditText.IsFocused && !isSwiped)
            {
                decimal value;
                if (decimal.TryParse(leftEditText.Text, out value))
                {
                    string code1 = leftText.Text;
                    string code2 = rightText.Text;


                    var temp = await getCourse(code1, code2, value);
                    
                    rightEditText.Text = temp.ToString("0.00");
                 
                }

                if(leftEditText.Length() == 0)
                {
                    rightEditText.Text = "";
                }
            }
        }

        private async void RightEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (rightEditText.IsFocused && !isSwiped)
            {
                decimal value;
                if (decimal.TryParse(rightEditText.Text, out value))
                {
                    string code1 = rightText.Text;
                    string code2 = leftText.Text;
                
                    var temp = await getCourse(code1, code2, value);
                  

                    leftEditText.Text = temp.ToString("0.00");
                    
                }

                if (rightEditText.Length() == 0)
                {
                    leftEditText.Text = "";
                }
            }
        }


        public async Task<decimal> getCourse(string code1, string code2, decimal value)
        {
            var temp = await interactor.GetCourse(code1, code2, value);
            if (temp != -1)
            {
                topTextView.Text = "Last Time update: " + interactor.LastTimeUpdated;
                return temp;
            }
            else
            {
                topTextView.Text = "!";
                return 0M;
            }
        }


        private void Reverse()
        {           
            changeFocus();
            isSwiped = true;

            var flagTemp = GetBitmap(leftImage);
            var keyTemp = leftText.Text;
            var editTemp = leftEditText.Text;
                        
            leftImage.SetImageBitmap(GetBitmap(rightImage));
            leftText.SetText(rightText.Text, null);
            leftEditText.SetText(rightEditText.Text, null);

            rightImage.SetImageBitmap(flagTemp);
            rightText.SetText(keyTemp,null);
            rightEditText.SetText(editTemp, null);

            isSwiped = false;
            changeFocus();
        }

        private void changeFocus()
        {
            if (rightEditText.IsFocused)
            {
                leftEditText.RequestFocus();
            }
            else
            {
                rightEditText.RequestFocus();
            }
        }

        private Bitmap GetBitmap(ImageView view)
        {
            view.BuildDrawingCache(true);
            Bitmap bitmap = view.GetDrawingCache(true);
            BitmapDrawable drawable = (BitmapDrawable)view.Drawable;
            bitmap = drawable.Bitmap;
            return bitmap;
        }

        protected override async void OnResume()
        {
            base.OnResume();

       
            if (Intent.HasExtra("buttonSide"))
            {
                var flag = Intent.GetIntExtra("image", 0);
                var key = Intent.GetStringExtra("id");
                var buttonSide = Intent.GetBooleanExtra("buttonSide", true);
               var rightEdit = Intent.GetStringExtra("");
                SetFlag(flag, key, buttonSide);
            }



            rightEditText.Text = Helper.Helper.rightEditTextRepo;
            leftEditText.Text = Helper.Helper.leftEditTextRepo;

            if (Helper.Helper.flag == 1)
            {
                await SetDataToFields(leftText, rightText, leftEditText, rightEditText);
            }
            else if (Helper.Helper.flag == 2)
            {
                await SetDataToFields(rightText, leftText, rightEditText, leftEditText);
            }      
        }

        private async Task SetDataToFields(TextView label1, TextView label2, EditText textField1, EditText textField2)
        {
            decimal currencyValueFromField = 1;
            decimal.TryParse(textField1.Text, out currencyValueFromField);
            var receivedCurrencyRate = await interactor.GetCourse(label1.Text, label2.Text, currencyValueFromField);
            if (receivedCurrencyRate != -1)
            {
                textField2.Text = receivedCurrencyRate != 0 ? String.Format("{0:0.00}", receivedCurrencyRate) : "";               
            }
            else
            {
                textField2.Text = "";            
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
                Helper.Helper.leftEditTextRepo = leftEditText.Text;
                leftImage.SetImageResource(Helper.Helper.saveLeftImage);
                leftText.SetText(Helper.Helper.saveLeftText, null);
               
                
            }
            else
            {
               
                leftImage.SetImageResource(flag);
                leftText.SetText(key, null);
                Helper.Helper.saveLeftImage = flag;
                Helper.Helper.saveLeftText = key;
                Helper.Helper.rightEditTextRepo = rightEditText.Text;
                rightImage.SetImageResource(Helper.Helper.saveRightImage);
                rightText.SetText(Helper.Helper.saveRightText, null);
               
            }
        }
    }
}

