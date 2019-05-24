using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using CurrencyConverter.Droid.Activities;
using Android.Graphics;
using CurrencyConverter.Droid.FlagList;
using Android.Graphics.Drawables;
using CurrencyConverter;
using System.Threading.Tasks;
using Android;
using Android.Runtime;

namespace CurrencyConverter.Droid
{
    [Activity(Label = "CurrencyConverter", Icon = "@mipmap/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        Interactor interactor;
        Requester reqester;

        bool isSwiped = false;
        bool isFirstReqest = true;

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

        protected async override void OnCreate(Bundle savedInstanceState)
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
            rightLayout.Click += RightLayout_Click;
            leftLayout.Click += LeftLayout_Click;
            switchButton.Click += SwitchButton_Click;

            BlockFields();

            await SetDataToFields(leftText, rightText, leftEditText, rightEditText);
        }
       
        private void BlockFields()
        {
            leftEditText.Enabled = false;
            rightEditText.Enabled = false;

            leftEditText.SetBackgroundColor(Color.Gray);
            rightEditText.SetBackgroundColor(Color.Gray);
        }

        private void LeftLayout_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ActivityList));
            intent.PutExtra("buttonSide", "leftButton");
            StartActivityForResult(intent, 666);
        }

        private void RightLayout_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ActivityList));
            intent.PutExtra("buttonSide", "rightButton");
            StartActivityForResult(intent, 666);
        }


        private void SwitchButton_Click(object sender, EventArgs e)
        {
            Reverse();
        }

        protected override async void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if(requestCode == 666 && resultCode == Result.Ok)
            {
                if(data.HasExtra("buttonSide"))
                {
                    var v = data.GetStringExtra("buttonSide");
                    var code = data.GetStringExtra("code");
                    if (v == "leftButton")
                    {
                        var image = FlagsDictionary.FlagDictionary[code].Flag;
                        leftImage.SetImageResource(image);
                        leftText.SetText(code, null);
                        await SetDataToFields(leftText, rightText, leftEditText, rightEditText);
                    }
                    else if (v == "rightButton")
                    {
                        var image = FlagsDictionary.FlagDictionary[code].Flag;
                        rightImage.SetImageResource(image);
                        rightText.SetText(code, null);
                        await SetDataToFields(rightText, leftText, rightEditText, leftEditText);
                    }
                }              
            }
        }

        private void TopTextView_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (topTextView.Text != "Connection Error!" && isFirstReqest)
            {
                leftEditText.SetBackgroundColor(Color.White);
                rightEditText.SetBackgroundColor(Color.White);

                leftEditText.Enabled = true;
                rightEditText.Enabled = true;

                rightEditText.Text = "0";
                isFirstReqest = false;
            }
        }


        private async void LeftEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (leftEditText.IsFocused && !isSwiped)
            {
                await SetDataToFields(leftText, rightText, leftEditText, rightEditText);             
            }
        }

        private async void RightEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (rightEditText.IsFocused && !isSwiped)
            {
                await SetDataToFields(rightText, leftText, rightEditText, leftEditText);             
            }
        }


        private void Reverse()
        {
            ChangeFocus();
            isSwiped = true;

            (rightEditText.Text, leftEditText.Text) = (leftEditText.Text, rightEditText.Text);
            (rightText.Text, leftText.Text) = (leftText.Text, rightText.Text);
            Drawable rightDrawable = rightImage.Drawable;
            rightImage.SetImageDrawable(leftImage.Drawable);
            leftImage.SetImageDrawable(rightDrawable);

            isSwiped = false;
            ChangeFocus();


        }
        private void ChangeFocus()
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

        protected override async void OnResume()
        {
            base.OnResume();    
        }

        private async Task SetDataToFields(TextView label1, TextView label2, EditText textField1, EditText textField2)
        {
            decimal currencyValueFromField = 1;
            decimal.TryParse(textField1.Text, out currencyValueFromField);
            var receivedCurrencyRate = await interactor.GetCourse(label1.Text, label2.Text, currencyValueFromField);
            if (receivedCurrencyRate != -1)
            {
                textField2.Text = receivedCurrencyRate != 0 ? String.Format("{0:0.00}", receivedCurrencyRate) : "";
                topTextView.Text = "Last Time update: " + interactor.LastTimeUpdated;
            }
            else
            {                  
                topTextView.Text = "Connection Error!";
            }
        }
    }
}

