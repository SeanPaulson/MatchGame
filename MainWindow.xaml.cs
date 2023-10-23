using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatchGame
    
{

    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tensthsOfSecondsElapsed;
        int matchesFound;
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        public MainWindow()
        {
            InitializeComponent();
            
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tensthsOfSecondsElapsed++;
            timeTextBlock.Text = (tensthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 6)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + "Play again?";
            }
        }

        private void SetUpGame()
        {
            List<String> animalEmoji = new List<String>()
            {
                "🐻‍","🐻‍",
                "👽","👽",
                "🐩","🐩",
                "🐗","🐗",
                "🐒","🐒",
                "🐎","🐎",
            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "timeTextBlock")
                {
                    textBlock.Visibility = Visibility.Visible; 
                    int index = random.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index);
                }
            }
            timer.Start();
            tensthsOfSecondsElapsed = 0;
            matchesFound = 0;
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            } else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            } else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (matchesFound == 6)
            {
                SetUpGame();
            }
        }
    }
}
