using System;
using System.Windows;
using Windows.UI.Popups;

namespace WpfApp1
{
    public partial class CustomControlPage
    {
        public CustomControlPage()
        {
            InitializeComponent();
            uiDynamicUwpXaml.Child = (Windows.UI.Xaml.UIElement)Windows.UI.Xaml.Markup.XamlReader.Load(
              "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Button>dynamic xaml!</Button><TextBox Text=\"stuff\" /><DatePicker /><TimePicker /></StackPanel>");
        }

        private void myUwpButton_ChildChanged(object sender, EventArgs e)
        {
            if (myUwpButton.Child is Windows.UI.Xaml.Controls.Button button)
            {
                button.Content = "UWP Button from " + System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
                button.Click += (s, args) =>
                {
                    MessageBox.Show("UWP Button, WPF MessageBox!");
                };
            }
        }

        private async void WPFButton_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("WPF Button, UWP Message Dialog!");
            await messageDialog.ShowAsync();
        }
    }
}
