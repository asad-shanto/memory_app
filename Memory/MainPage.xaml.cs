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
    public sealed partial class MainPage : Page
    {
        // Field Declaration
        private int initialLoad = 0;
        private int[] inputs = new int[2];
        private int clicks = 0;
        private int stateCounter = 0;
        private int timeLeft = 30;
        private int fullTime = 30;

        private Button button;
        private Button clickedButton;
        private Button previousClickedButton;

        private List<Button> buttonList = new List<Button>();
        private List<int> cards = new List<int>();
        private List<Button> buttons = new List<Button>();

        private string uriString = "";

        ImageBrush buttonImageBrush;
        ImageBrush imageBrush;

        private DispatcherTimer timer;



        // Start of Execution
        public MainPage()
        {
            this.InitializeComponent();
            if (initialLoad == 0)
            {
                CreateButtons();
                CreateList();
            }
            GameBoard.Visibility = Visibility.Collapsed;
        }

        // Dynamically Design Game Board with Cards
        private void CreateButtons()
        {
            buttonImageBrush = new ImageBrush();
            buttonImageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/card_backview.jpg"));
            for (int buttonNumber = 1; buttonNumber <= 16; buttonNumber++)
            {
                button = new Button();
                button.Background = buttonImageBrush;
                button.Style = ButtonStyle;
                button.Tag = buttonNumber;
                button.Click += new RoutedEventHandler(Button_Click);
                AddButtonsToBoard(buttonNumber, button);
            }
        }
        private void AddButtonsToBoard(int buttonNumber, Button button)
        {
            if (buttonNumber > 0 && buttonNumber <= 4)
            {
                FirstRow.Children.Add(button);
            }
            if (buttonNumber > 4 && buttonNumber <= 8)
            {
                SecondRow.Children.Add(button);
            }
            if (buttonNumber > 8 && buttonNumber <= 12)
            {
                ThirdRow.Children.Add(button);
            }
            if (buttonNumber > 12 && buttonNumber <= 16)
            {
                FourthRow.Children.Add(button);
            }
        }
        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            clickedButton = (Button)sender;
            if (previousClickedButton != clickedButton)
            {
                imageBrush = new ImageBrush();
                uriString = "ms-appx:///Assets/Digits/" + cards[Convert.ToInt32(clickedButton.Tag) - 1].ToString() + ".jpg";
                imageBrush.ImageSource = new BitmapImage(new Uri(uriString));
                clickedButton.Background = imageBrush;
                buttons.Add(clickedButton);
                inputs[clicks] = Convert.ToInt32(clickedButton.Tag);
                clicks++;
                UserInputsChecking();
                previousClickedButton = clickedButton;
            }
        }




        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        // Suffle Logic
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

            for (int loop = 0; loop < randomLoopNo; loop++)
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

        // Calculation
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
                foreach (Button singleButton in buttons)
                {
                    singleButton.Visibility = Visibility.Collapsed;
                }
                stateCounter++;
            }
            else
            {
                foreach (Button singleButton in buttons)
                {
                    singleButton.Background = buttonImageBrush;
                }
            }
            buttons = new List<Button>();
            if (stateCounter == 8)
            {
                Result.Width = 400;
                timer.Stop();
                ResultTextBlock.Text = "Level 1 Completed";
                ResultTag.Text = "Result";
                output.Text = "Bravo!!! Your Timing is : " + (fullTime - Convert.ToInt32(StopWatch.Text)) + " seconds.";
                ResultTextBlock.FontSize = 40;
            }
        }


        // Left Sidebar
        private void RestartGameButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));

        }
        private void StartButton_Click_1(object sender, RoutedEventArgs e)
        {
            GameBoard.Visibility = Visibility.Visible;
            startMyTimer();
        }
        private void startMyTimer()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer = null;
            }
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_tick;
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
                output.Text = "Your Time is up!";
                GameBoard.Visibility = Visibility.Collapsed;
            }
        }
    }
}