using Foundation;
using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class TableViewCustomCell : UITableViewCell
    {
        public TableViewCustomCell (IntPtr handle) : base (handle)
        {

        }

        public TableViewCustomCell(NSString cellId, string friendName, UIImage friendPhoto) : base(UITableViewCellStyle.Default, cellId)
        {
            labelCell.Text = friendName;
            imageCell.Image = friendPhoto;
        }

        //This methods is to update cell data when reuse:
        public void UpdateCellData(string friendName, UIImage friendPhoto)
        {
            labelCell.Text = friendName;
            imageCell.Image = friendPhoto;
        }

    }
}