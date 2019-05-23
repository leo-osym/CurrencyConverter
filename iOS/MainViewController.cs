using System;

using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class MainViewController : UIViewController
    {

        public string _segue;
        public  int flag = 3;
       
       

        public MainViewController() : base("MainViewController", null)
        {
        }
        public MainViewController(IntPtr handle) : base(handle)
        {
        }


        public async override void ViewDidLoad()
        {
            base.ViewDidLoad();


            // Perform any additional setup after loading the view, typically from a nib.

            var requester = new Requester();
            var interactor = new Interactor(requester);
            decimal value = 1;

            decimal.TryParse(textEditLeft.Text, out value);
            var temp = await interactor.GetCourse(buttonLabelLeft.Text, buttonLabelRight.Text, value);
            textEditRight.Text = temp.ToString();

            textEditLeft.EditingChanged += async (sender, e) => {
                decimal.TryParse(textEditLeft.Text, out value);
                temp = await interactor.GetCourse(buttonLabelLeft.Text, buttonLabelRight.Text, value);
                textEditRight.Text = temp.ToString();
            };
            textEditRight.EditingChanged += async (sender, e) => {
                decimal.TryParse(textEditRight.Text, out value);
                temp = await interactor.GetCourse(buttonLabelRight.Text, buttonLabelLeft.Text, value);
                textEditLeft.Text = temp.ToString();
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



        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
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

