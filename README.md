# Windows
Demo App in Windows Phone Platform 10 

> UWP stands for Universal Windows Platform app, And in Layout Demo we have created UWP App which implements AppBar, SplitView, Buttons and Click on them

# XAML 

```sh
The Layout app implements <AppBar>, on top and <CommandBar> on the bottom.
Using <CommandBar.SecondaryCommands> we can add additional commands separating them from the
lower deck.
<SplitView> containing <SplitView.Pane> and <SplitView.Content> with a handburger button is
also implemented.
```
#  C# 

```sh
 private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog messageDialog =
            new Windows.UI.Popups.MessageDialog("The the text contains."+Text.QueryText);
            await messageDialog.ShowAsync();

        }
 private void Everlasting_OnClick(object sender, RoutedEventArgs e)
        {
            ShowToast(-1, "No timeout toast from Webonise!");
        }
 private void ShowToast(int timeoutInSeconds, string text)
        {
            var toastTemplate = ToastTemplateType.ToastImageAndText01;

            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            var toast = new ToastNotification(toastXml);

            if (timeoutInSeconds >= 0)
                toast.ExpirationTime = DateTime.Now.AddSeconds(timeoutInSeconds);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

  private void OnClick_Navigate(object sender, RoutedEventArgs e)
        {          
            Frame.Navigate(typeof(StackPanelLayout));
          
        }
```


