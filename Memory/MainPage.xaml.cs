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
using System.Threading;
using System.Threading.Tasks;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int initialLoad = 0;
        public MainPage()
        {
            this.InitializeComponent();
            if (initialLoad == 0)
            {
                SetUpBoard();
                CreateList();
            }

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

        List<int> cards = new List<int>();
        private int[] inputs = new int[2];
        private int clicks = 0;
        private int buttonIndex = 0;
        private string uriString = "";
        List<Button> buttons = new List<Button>();

        ImageBrush imageBrush;


        public void CreateList() 
        {
            for (int num = 1; num <= 2; num++)
            {
                for (int digits = 1; digits <= 8; digits++)
                {
                    cards.Add(digits);
                } 
            }


            
            DateTime time = DateTime.Now;

            int randomLoopNo = time.Hour - time.Minute;

            if (randomLoopNo < 0)
            {
                randomLoopNo *= (-1);
            }

            for (int loop = 0; loop < randomLoopNo; loop++ )
            {
                cards = ShuffleList(cards);
            }
        }

        private List<int> ShuffleList(List<int> inputList)
        {
            List<int> randomList = new List<int>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }


        public async void UserInputsChecking() 
        {
            if (clicks == 2)
            {
                clicks = 0;

                await Task.Delay(TimeSpan.FromSeconds(0.5));
                MemoryJudgment();
            }
        }

        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 1;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button1.Background = imageBrush;

            buttons.Add(Button1);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking();
            

        }

        public void MemoryJudgment() 
        {
            if (cards[inputs[0] -1] == cards[inputs[1] - 1])
            {
                //await Task.Delay(TimeSpan.FromSeconds(2));
                foreach (Button button in buttons)
                {
                    button.Visibility = Visibility.Collapsed;      
                }     
            }
            else 
            {
                SetUpBoard();
            }
            buttons = new List<Button>();
        }

        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 2;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button2.Background = imageBrush;
            
            buttons.Add(Button2);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking();   
        }

        private void Button3_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 3;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button3.Background = imageBrush;

            buttons.Add(Button3);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button4_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 4;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button4.Background = imageBrush;

            buttons.Add(Button4);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button5_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 5;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button5.Background = imageBrush;

            buttons.Add(Button5);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button6_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 6;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button6.Background = imageBrush;

            buttons.Add(Button6);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button7_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 7;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button7.Background = imageBrush;

            buttons.Add(Button7);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button8_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 8;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button8.Background = imageBrush;

            buttons.Add(Button8);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button9_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 9;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button9.Background = imageBrush;

            buttons.Add(Button9);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button10_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 10;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button10.Background = imageBrush;

            buttons.Add(Button10);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button11_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 11;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button11.Background = imageBrush;

            buttons.Add(Button11);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button12_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 12;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button12.Background = imageBrush;

            buttons.Add(Button12);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button13_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 13;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button13.Background = imageBrush;

            buttons.Add(Button13);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button14_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 14;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button14.Background = imageBrush;

            buttons.Add(Button14);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button15_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 15;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button15.Background = imageBrush;

            buttons.Add(Button15);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void Button16_Click_1(object sender, RoutedEventArgs e)
        {
            imageBrush = new ImageBrush();
            buttonIndex = 16;

            uriString = "ms-appx:///Assets/Digits/" + cards[buttonIndex - 1].ToString() + ".jpg";
            imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
            Button16.Background = imageBrush;

            buttons.Add(Button16);
            inputs[clicks] = buttonIndex;
            clicks++;
            UserInputsChecking(); 
        }

        private void RestartGameButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Take player to home page
        }
    }
}
