using System;
using System.Threading.Tasks;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class MainViewController : UIViewController
    {

        public string currencyKey;
        public ChosenButton chosenButton;
        public bool operationIsDone = false;
        Requester requester;
        Interactor interactor;
        FlagsData data = new FlagsData();
       
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

        private async Task SetDataToFields(UILabel label1, UILabel label2, UITextField textField1, UITextField textField2)
        {
            decimal currencyValueFromField = 1;
            decimal.TryParse(textField1.Text, out currencyValueFromField);
            var receivedCurrencyRate = await interactor.GetCourse(label1.Text, label2.Text, currencyValueFromField);
            if(receivedCurrencyRate != -1) 
            {
                textField2.Text = receivedCurrencyRate != 0 ? String.Format("{0:0.00}", receivedCurrencyRate) : "";
                TimeLabel.Text = $"Last time updated: {interactor.LastTimeUpdated}";
            }
            else 
            {
                textField2.Text = "";
                TimeLabel.Text = "Connection error!";
            }
        }


        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            await SetDataToFields(buttonLabelLeft, buttonLabelRight, textEditLeft, textEditRight);
            if (currencyKey != null && operationIsDone)
            {
                if (chosenButton == ChosenButton.LeftButton)
                {
                    buttonLabelLeft.Text = currencyKey;
                    leftButtonImage.Image = UIImage.FromBundle(data.FlagDictionary[currencyKey].flagImage);

                }
                else if (chosenButton == ChosenButton.RightButton)
                {
                    buttonLabelRight.Text = currencyKey;
                    rightButtonImage.Image = UIImage.FromBundle(data.FlagDictionary[currencyKey].flagImage);
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

