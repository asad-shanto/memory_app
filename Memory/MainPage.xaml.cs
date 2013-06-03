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
            GameBoard.Visibility = Visibility.Collapsed;
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
        private Button previousClickedButton;


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

        public void MemoryJudgment()
        {
            if (cards[inputs[0] - 1] == cards[inputs[1] - 1])
            {
                //await Task.Delay(TimeSpan.FromSeconds(2));
                foreach (Button button in buttons)
                {
                    button.Visibility = Visibility.Collapsed;
                }
                stateCounter++;
            }
            else
            {
                SetUpBoard();
            }
            buttons = new List<Button>();
            if (stateCounter == 8)
            {
                Result.Width = 400;
                timer.Stop();
                ResultTextBlock.Text = "Level 1 Completed";
                output.Text = "Your Time is : " + (fullTime - Convert.ToInt32(StopWatch.Text));
                ResultTextBlock.FontSize = 40;
            }
        }

        private int stateCounter = 0;

        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button1)
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
                previousClickedButton = Button1;
            }
            
        }

        private void Button2_Click_1(object sender, RoutedEventArgs e)
        {

            if (previousClickedButton != Button2)
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
                previousClickedButton = Button2;
            }
        }

        private void Button3_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button3)
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
                previousClickedButton = Button3;
            }
            

        }

        private void Button4_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button4)
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
                previousClickedButton = Button4;
            }
            
        }

        private void Button5_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button5)
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
                previousClickedButton = Button5;
            }
            
        }

        private void Button6_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button6)
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
                previousClickedButton = Button6;
            }
            
        }

        private void Button7_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button7)
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
                previousClickedButton = Button7;
            }
            
        }

        private void Button8_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button8)
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
                previousClickedButton = Button8;
            }
            
        }

        private void Button9_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button9)
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
                previousClickedButton = Button9;
            }
            
        }

        private void Button10_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button10)
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
                previousClickedButton = Button10;
            }
            
        }

        private void Button11_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button11)
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
                previousClickedButton = Button11;
            }
            
        }

        private void Button12_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button12)
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
                previousClickedButton = Button12;
            }
            
        }

        private void Button13_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button13)
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
                previousClickedButton = Button13;
            }
            
        }

        private void Button14_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button14)
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
                previousClickedButton = Button14;
            }
            
        }

        private void Button15_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button15)
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
                previousClickedButton = Button15;
            }
            
        }

        private void Button16_Click_1(object sender, RoutedEventArgs e)
        {
            if (previousClickedButton != Button16)
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
                previousClickedButton = Button16;
            }
            
        }

        private void RestartGameButton_Click_1(object sender, RoutedEventArgs e)
        {
            // Take player to home page

        }

        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            GameBoard.Visibility = Visibility.Visible;
            startMyTimer();
        }


        private int timeLeft = 30;
        private int fullTime = 30;
        private DispatcherTimer timer;

        private void startMyTimer()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer = null;
            }
            //create a new DispatcherTimer type of object
            timer = new DispatcherTimer();
            //set the interval between two timer ticks. Here it 1 s.
            //the format is hr.min.sec
            //if you put (0,2,0) your timer will change in every two minutes
            timer.Interval = new TimeSpan(0, 0, 1);
            //this one here is event
            timer.Tick += timer_tick;
            //kick off the timer
            timer.Start();

        }


        public void timer_tick(object sender, object args)
        {
            if (timeLeft > 0)
            {
                timeLeft -= 1;
                this.StopWatch.Text = Convert.ToString(timeLeft);
            }
            else
            {
                timer.Stop();
                //check if the time is up!
                output.Text = "Your Time is up!";
                GameBoard.Visibility = Visibility.Collapsed;
            }
        }
    }
}
