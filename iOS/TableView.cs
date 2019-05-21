using System;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class TableView : UITableViewController
    {
        public TableView() : base("TableView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }




        string cellIdentifier = "FlagsCell";

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            TableViewCustomCell cell = (TableViewCustomCell)tableView.DequeueReusableCell(cellIdentifier);
            Friend friend = _friends[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new TableViewCustomCell(new NSString(cellIdentifier), friend.FriendName, new UIImage(NSData.FromArray(friend.FriendPhoto))); }

            cell.UpdateCellData(friend.UserName, new UIImage(NSData.FromArray(friend.FriendPhoto)));

            return cell;
        }


    }
}

