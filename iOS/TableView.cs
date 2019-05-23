using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class TableView : UITableViewController, IUITableViewDataSource
    {
        FlagsData data = new FlagsData();
        List<String> listItem;

        public ChosenButton chosenButton;

        public TableView() : base("TableView", null)
        {
        }
        public TableView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            listItem = new List<string>(data.FlagDictionary.Keys);
            (NavigationController.ViewControllers[0] as MainViewController).operationIsDone = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }



        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return data.FlagDictionary.Count;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var myUIViewController = this.NavigationController.ViewControllers[0] as MainViewController;
            myUIViewController.currencyKey = listItem[indexPath.Row];
            myUIViewController.chosenButton = chosenButton;
            myUIViewController.operationIsDone = true;
            NavigationController.PopViewController(true);
            tableView.DeselectRow(indexPath, true);
        }



        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as TableViewCustomCell;
            string item = listItem[indexPath.Row];

            var setImage = data.FlagDictionary[item];
            cell.ImageViewCell = UIImage.FromBundle(setImage.flagImage);
            cell.LabelCellTextAbriveature = item;
            cell.LabelCellTextDescription = setImage.description;
          

            return cell;
        }

        string cellIdentifier = "FlagsCell";

        public override void PrepareForSegue(UIStoryboardSegue segue,
            Foundation.NSObject sender)
        {

            if (segue.Identifier == "toTableView")
            {
                var callMVController = segue.DestinationViewController as MainViewController;
            }
        }


    }
}

