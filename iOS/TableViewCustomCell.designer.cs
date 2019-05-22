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
        UIKit.UILabel labelCellDesc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelCellXXX { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelDefis { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageCell != null) {
                imageCell.Dispose ();
                imageCell = null;
            }

            if (labelCellDesc != null) {
                labelCellDesc.Dispose ();
                labelCellDesc = null;
            }

            if (labelCellXXX != null) {
                labelCellXXX.Dispose ();
                labelCellXXX = null;
            }

            if (labelDefis != null) {
                labelDefis.Dispose ();
                labelDefis = null;
            }
        }
    }
}