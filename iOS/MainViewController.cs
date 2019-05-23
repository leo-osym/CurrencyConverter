using System;
using System.Threading.Tasks;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class MainViewController : UIViewController
    {

        public string _segue;
        public  int flag = 3;
        Requester requester;
        Interactor interactor;
       
       

        public MainViewController() : base("MainViewController", null)
        {
        }
        public MainViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            requester = new Requester();
            interactor = new Interactor(requester);

            textEditLeft.EditingChanged += async (sender, e) => {
                await SetDataToFields(buttonLabelLeft, buttonLabelRight, textEditLeft, textEditRight);
            };
            textEditRight.EditingChanged += async (sender, e) => {
                await SetDataToFields(buttonLabelRight, buttonLabelLeft, textEditRight, textEditLeft);
            };

            btnChangeCurrencyLeft.TouchUpInside += (sender, e) => {
                //var okAlertController = UIAlertController.Create("Title", "The message", UIAlertControllerStyle.Alert);
                //okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                //PresentViewController(okAlertController, true, null);
                flag = 1;
                TapSelectViews();

                        };
            btnChangeCurrentRight.TouchUpInside += (sender, e) => {
               
                flag = 2;
                TapSelectViews();

            };

        }

        private async Task SetDataToFields(UILabel label1, UILabel label2, UITextField tfield1, UITextField tfield2)
        {
            decimal value = 1;
            decimal.TryParse(tfield1.Text, out value);
            var temp = await interactor.GetCourse(label1.Text, label2.Text, value);
            tfield2.Text = String.Format("{0:0.00}", temp);
            TimeLabel.Text = interactor.LastTimeUpdated;
        }


        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            await SetDataToFields(buttonLabelLeft, buttonLabelRight, textEditLeft, textEditRight);
            if (_segue != null)
                if (flag == 1)
                {
                    buttonLabelLeft.Text = _segue;
                    leftButtonImage.Image = UIImage.FromBundle(FlagsData.FlagDictionary[_segue].flagImage); 

                } if (flag == 2) { 
                buttonLabelRight.Text = _segue;
                rightButtonImage.Image = UIImage.FromBundle(FlagsData.FlagDictionary[_segue].flagImage);
            }
        }

        partial void BtnReverse_TouchUpInside(UIButton sender)
        {
            (buttonLabelLeft.Text, buttonLabelRight.Text) = (buttonLabelRight.Text, buttonLabelLeft.Text);
            (rightButtonImage.Image, leftButtonImage.Image) = (leftButtonImage.Image,rightButtonImage.Image);
            (textEditLeft.Text, textEditRight.Text) = (textEditRight.Text, textEditLeft.Text);
        }

        public void TapSelectViews () {
            base.PerformSegue("toTableView", this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public void TapGestureLeft () {

            UITapGestureRecognizer gestureL = new UITapGestureRecognizer();
            gestureL.AddTarget(() => TapSelectViews());
            btnChangeCurrencyLeft.AddGestureRecognizer(gestureL);
         
        }

        public void TapGestureRight()
        {
            UITapGestureRecognizer gestureR = new UITapGestureRecognizer();
            gestureR.AddTarget(() => TapSelectViews());
            btnChangeCurrentRight.AddGestureRecognizer(gestureR);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue,
            Foundation.NSObject sender)
        {

            if (segue.Identifier == "toTableView")
            {

                var callTVController = segue.DestinationViewController
                                              as TableView;
                callTVController.tableFlag = flag;

            }
        }
    }
}

