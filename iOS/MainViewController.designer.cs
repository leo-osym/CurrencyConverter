// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CurrencyConverter.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIControl btnChangeCurrencyLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIControl btnChangeCurrentRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnReverse { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel buttonLabelLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel buttonLabelRight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView leftButtonImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView rightButtonImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textEditLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textEditRight { get; set; }

        [Action ("BtnReverse_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnReverse_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnChangeCurrencyLeft != null) {
                btnChangeCurrencyLeft.Dispose ();
                btnChangeCurrencyLeft = null;
            }

            if (btnChangeCurrentRight != null) {
                btnChangeCurrentRight.Dispose ();
                btnChangeCurrentRight = null;
            }

            if (btnReverse != null) {
                btnReverse.Dispose ();
                btnReverse = null;
            }

            if (buttonLabelLeft != null) {
                buttonLabelLeft.Dispose ();
                buttonLabelLeft = null;
            }

            if (buttonLabelRight != null) {
                buttonLabelRight.Dispose ();
                buttonLabelRight = null;
            }

            if (leftButtonImage != null) {
                leftButtonImage.Dispose ();
                leftButtonImage = null;
            }

            if (rightButtonImage != null) {
                rightButtonImage.Dispose ();
                rightButtonImage = null;
            }

            if (textEditLeft != null) {
                textEditLeft.Dispose ();
                textEditLeft = null;
            }

            if (textEditRight != null) {
                textEditRight.Dispose ();
                textEditRight = null;
            }
        }
    }
}