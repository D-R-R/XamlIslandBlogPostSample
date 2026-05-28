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
              """
              <UserControl
                  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                  xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                  xmlns:local="using:UWPClassLibrary"
                  xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                  d:DesignHeight="300"
                  d:DesignWidth="400"
                  mc:Ignorable="d">

                  <Grid Background="Red">
                      <Grid.RowDefinitions>
                          <RowDefinition Height="Auto" />
                          <RowDefinition Height="*" />
                          <RowDefinition Height="*" />
                      </Grid.RowDefinitions>
                      <TextBlock Text="Hi from UWP dynamic XAML!" />
                      <DatePicker Grid.Row="1" />
                      <TimePicker Grid.Row="2" />
                  </Grid>
              </UserControl>
              """);
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
