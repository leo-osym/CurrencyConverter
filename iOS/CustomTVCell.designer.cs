// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CurrencyConverter.iOS
{
    [Register ("CustomTVCell")]
    partial class CustomTVCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        CurrencyConverter.iOS.TableView dataSource { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        CurrencyConverter.iOS.TableView @delegate { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (dataSource != null) {
                dataSource.Dispose ();
                dataSource = null;
            }

            if (@delegate != null) {
                @delegate.Dispose ();
                @delegate = null;
            }
        }
    }
}