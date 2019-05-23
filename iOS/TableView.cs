using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class TableView : UITableViewController, IUITableViewDataSource
    {
        List<String> listItem =new List<string>(FlagsData.FlagDictionary.Keys);
        public int tableFlag;
       

        public TableView() : base("TableView", null)
        {
        }
        public TableView(IntPtr handle) : base(handle)
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



        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return FlagsData.FlagDictionary.Count;
        }


        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // UIAlertController okAlertController = UIAlertController.Create("Row Selected", listItem[indexPath.Row], UIAlertControllerStyle.Alert);
            //okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            //this.PresentViewController(okAlertController, true, null);

            // PrepareForSegue(PrepareForSegue, this);
            //MainViewController._segue = listItem[indexPath.Row];

            var myUIViewController = this.NavigationController.ViewControllers[0] as MainViewController;
            myUIViewController._segue = listItem[indexPath.Row];
            myUIViewController.flag = tableFlag;
            NavigationController.PopViewController(true);
            tableView.DeselectRow(indexPath, true);
        }



        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellIdentifier) as TableViewCustomCell;
            string item = listItem[indexPath.Row];

            var setImage = FlagsData.FlagDictionary[item];
            cell.ImageViewCell = UIImage.FromBundle(setImage.flagImage);
            cell.LabelCellTextAbriveature = item;
            cell.LabelCellTextDescription = setImage.description;
          

            return cell;
        }

        string cellIdentifier = "FlagsCell";


        //override func prepare(for segue: UIStoryboardSegue, sender: Any?)
        //{
        //    if (segue.identifier == "WebViewController")
        //    {
        //        let vc = segue.destination as!WebViewController
        //        vc.segue_in = textViewField.text
        //    }
        //}
        //override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        //if (segue.identifier == "WebViewController") {
        //    let vc = segue.destination as! WebViewController
        //    vc.segue_in = textViewField.text
        //}
   // }

        public override void PrepareForSegue(UIStoryboardSegue segue,
            Foundation.NSObject sender)
        {

            if (segue.Identifier == "toTableView")
            {

                //  base.PrepareForSegue(segue, sender);

                var callMVController = segue.DestinationViewController
                                              as MainViewController;
              //  callMVController._segue = sender.
                // if (callHistoryController != null)
                // {
                //     callHistoryController.PhoneNumbers = PhoneNumbers;
                //  }
            }
        }


    }
}

