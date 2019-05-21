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
        UIKit.UIView btnChangeCurrencyLeft { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView btnChangeCurrentRigh { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnReverse { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField textEditRight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnChangeCurrencyLeft != null) {
                btnChangeCurrencyLeft.Dispose ();
                btnChangeCurrencyLeft = null;
            }

            if (btnChangeCurrentRigh != null) {
                btnChangeCurrentRigh.Dispose ();
                btnChangeCurrentRigh = null;
            }

            if (btnReverse != null) {
                btnReverse.Dispose ();
                btnReverse = null;
            }

            if (textEditRight != null) {
                textEditRight.Dispose ();
                textEditRight = null;
            }
        }
    }
}