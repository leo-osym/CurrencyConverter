using System;

using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController() : base("MainViewController", null)
        {
        }
        public MainViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            TapGesture();

        }

        public void TapSelectViews () {
            base.PerformSegue("toTableView", this);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

      //  partial void btnTapReverse(UIButton sender)
       // {
       //     throw new NotImplementedException();
       // }

        //public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        //{
        //    base.TouchesBegan(touches, evt);
        //    UITouch touch = touches.AnyObject as UITouch;

        //    if (touch != null)
        //    {
        //        base.PerformSegue("toTableView", this);
               

        //        var okAlertController = UIAlertController.Create("Title", "The message", UIAlertControllerStyle.Alert);
        //        okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
        //        PresentViewController(okAlertController, true, null);
        //        //base.PrepareForSegue()
        //    }
        //}


        public void TapGesture () {
            UITapGestureRecognizer gestureL = new UITapGestureRecognizer();
            UITapGestureRecognizer gestureR = new UITapGestureRecognizer();
            gestureL.AddTarget(() => TapSelectViews());
            gestureR.AddTarget(() => TapSelectViews());
            btnChangeCurrencyLeft.AddGestureRecognizer(gestureL);
            btnChangeCurrentRigh.AddGestureRecognizer(gestureR);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue,
            Foundation.NSObject sender)
        {

            if (segue.Identifier == "toTableView")
            {

                //  base.PrepareForSegue(segue, sender);

                var callTVController = segue.DestinationViewController
                                              as UITableViewController;

                // if (callHistoryController != null)
                // {
                //     callHistoryController.PhoneNumbers = PhoneNumbers;
                //  }
            }
        }
    }
}

