using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.Globalization;
using Windows.UI.Xaml.Media.Imaging;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetUpBoard();

        }

        public void SetUpBoard() 
        {
            ImageBrush brush1 = new ImageBrush();
            brush1.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/card_backview.jpg"));
            Button1.Background = brush1;
            Button2.Background = brush1;
            Button3.Background = brush1;
            Button4.Background = brush1;
            Button5.Background = brush1;
            Button6.Background = brush1;
            Button7.Background = brush1;
            Button8.Background = brush1;
            Button9.Background = brush1;
            Button10.Background = brush1;
            Button11.Background = brush1;
            Button12.Background = brush1;
            Button13.Background = brush1;
            Button14.Background = brush1;
            Button15.Background = brush1;
            Button16.Background = brush1;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
