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
    [Register ("TableViewCustomCell")]
    partial class TableViewCustomCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageCell != null) {
                imageCell.Dispose ();
                imageCell = null;
            }

            if (labelCell != null) {
                labelCell.Dispose ();
                labelCell = null;
            }
        }
    }
}