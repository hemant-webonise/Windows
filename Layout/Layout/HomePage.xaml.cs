using System;

using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Layout
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
      
        public MainPage()
        {
            this.InitializeComponent();

        }

        static int Clicks = 0;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            Clicks += 1;
            clickTextBlock.Text = "Number of Clicks: " + Clicks;
        }


        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("The the text contains."+Text.QueryText);
            await messageDialog.ShowAsync();

        }
        private void Everlasting_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(-1, "No timeout toast from Webonise!");
        }

        private void WithTimeout_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(10, "10s timeout toast from Webonise!");
        }

        private void ZeroTimeout_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(1, "Short timeout toast from Webonise!");
        }

        private void ShowToast(int timeoutInSeconds, string text)
        {
            var toastTemplate = ToastTemplateType.ToastImageAndText01;

            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            ////Andreas Hammar 2014-10-08 08:39: note! does not work on windows phone
            //var toastImageAttributes = toastXml.GetElementsByTagName("image");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("src", "ms-appx:///Assets/jay_transparent.png");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "jay");

            var toast = new ToastNotification(toastXml);

            if (timeoutInSeconds >= 0)
                toast.ExpirationTime = DateTime.Now.AddSeconds(timeoutInSeconds);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private void OnClick_Navigate(object sender, RoutedEventArgs e)
        {          
            Frame.Navigate(typeof(StackPanelLayout));
          
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
