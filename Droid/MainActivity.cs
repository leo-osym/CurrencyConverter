using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;

namespace CurrencyConverter.Droid
{
    [Activity(Label = "CurrencyConverter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        IInteractor interactor;
        IRequester requester;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            TextView textView = FindViewById<TextView>(Resource.Id.myTextView);
            EditText editText = FindViewById<EditText>(Resource.Id.editText1);

            requester = new Requester();
            interactor = new Interactor(requester);


            editText.TextChanged += async (s, e) => {
                //textView.Text = requester.RequestAsync("USD", "UAH").Result.ToString();

                decimal value;
                if (decimal.TryParse(editText.Text, out value))
                {


                    //Task.Run(TestMethod);
                    var temp = await TestMethod(value);

                    textView.Text = temp.ToString();
                }
            };        
        }

        public async Task<decimal> TestMethod(decimal value)
        {
            return await interactor.GetCourse("USD", "UAH", value);

        }
    }
}

