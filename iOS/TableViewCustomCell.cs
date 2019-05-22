using Foundation;
using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class TableViewCustomCell : UITableViewCell
    {

        public string LabelCellTextAbriveature
        {
            get => labelCellXXX.Text;
            set => labelCellXXX.Text = value;
        }
        public string LabelCellTextDescription
        {
            get => labelCellDesc.Text;
            set => labelCellDesc.Text = value;
        }

        public UIImage ImageViewCell
        {
            get => imageCell.Image;
            set => imageCell.Image = value;
        }


        public TableViewCustomCell (IntPtr handle) : base (handle)
        {

        }

        public TableViewCustomCell(NSString cellId, string description, string abriveature, UIImage flagPhoto) : base(UITableViewCellStyle.Default, cellId)
        {
            LabelCellTextDescription = description;
            LabelCellTextAbriveature = abriveature;
            ImageViewCell = flagPhoto;
        }

        //This methods is to update cell data when reuse:
        public void UpdateCellData(string description, string abriveature, UIImage flagFoto)
        {

            LabelCellTextDescription = description;
           /// imageCell.Image = flagFoto;
            LabelCellTextAbriveature = abriveature;
            

        }

    }
}