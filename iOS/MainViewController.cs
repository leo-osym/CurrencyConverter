using System;
using System.Threading.Tasks;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class MainViewController : UIViewController
    {

        public string _segue;
        public ChosenButton chosenButton;
        public bool operaitionIsDone = false;
        Requester requester;
        Interactor interactor;
       
        public MainViewController() : base("MainViewController", null)
        {
        }
        public MainViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            requester = new Requester();
            interactor = new Interactor(requester);
           
            textEditLeft.EditingChanged += async (sender, e) => {
                await SetDataToFields(buttonLabelLeft, buttonLabelRight, textEditLeft, textEditRight);
            };
            textEditRight.EditingChanged += async (sender, e) => {
                //if (String.IsNullOrEmpty(textEditRight.Text)) textEditLeft.Text = "0.00";
                await SetDataToFields(buttonLabelRight, buttonLabelLeft, textEditRight, textEditLeft);
            };

            btnChangeCurrencyLeft.TouchUpInside += (sender, e) => {
                chosenButton = ChosenButton.LeftButton;
                base.PerformSegue("toTableView", this);
            };
            btnChangeCurrentRight.TouchUpInside += (sender, e) => {
                chosenButton = ChosenButton.RightButton;
                base.PerformSegue("toTableView", this);
            };

        }

        private async Task SetDataToFields(UILabel label1, UILabel label2, UITextField tfield1, UITextField tfield2)
        {
            decimal value = 1;
            decimal.TryParse(tfield1.Text, out value);
            var temp = await interactor.GetCourse(label1.Text, label2.Text, value);
            if(temp != -1) 
            {
                tfield2.Text = temp != 0 ? String.Format("{0:0.00}", temp) : "";
                TimeLabel.Text = interactor.LastTimeUpdated;
            }
            else 
            {
                tfield2.Text = "";
                TimeLabel.Text = "Connection error!";
            }
        }


        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            await SetDataToFields(buttonLabelLeft, buttonLabelRight, textEditLeft, textEditRight);
            if (_segue != null && operaitionIsDone)
            {
                if (chosenButton == ChosenButton.LeftButton)
                {
                    buttonLabelLeft.Text = _segue;
                    leftButtonImage.Image = UIImage.FromBundle(FlagsData.FlagDictionary[_segue].flagImage);

                }
                if (chosenButton == ChosenButton.RightButton)
                {
                    buttonLabelRight.Text = _segue;
                    rightButtonImage.Image = UIImage.FromBundle(FlagsData.FlagDictionary[_segue].flagImage);
                }
            }
        }

        partial void BtnReverse_TouchUpInside(UIButton sender)
        {
            double temp = 0;
            double.TryParse(textEditLeft.Text, out temp);
            textEditLeft.Text = temp != 0 ? String.Format("{0:0.00}", temp) : "";
            (buttonLabelLeft.Text, buttonLabelRight.Text) = (buttonLabelRight.Text, buttonLabelLeft.Text);
            (rightButtonImage.Image, leftButtonImage.Image) = (leftButtonImage.Image,rightButtonImage.Image);
            (textEditLeft.Text, textEditRight.Text) = (textEditRight.Text, textEditLeft.Text);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue,
            Foundation.NSObject sender)
        {

            if (segue.Identifier == "toTableView")
            {
                var callTVController = segue.DestinationViewController
                                              as TableView;
                callTVController.chosenButton = chosenButton;
            }
        }
    }

    public enum ChosenButton {LeftButton, RightButton};
}

