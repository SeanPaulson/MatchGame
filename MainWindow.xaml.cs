﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            List<String> animalEmoji = new List<String>()
            {
                "🐻‍","🐻‍",
                "👽","👽",
                    "🐩","🐩",
                    "🐻","🐻",
                    "🐗","🐗",
                    "🐒","🐒",
                    "🐒","🐒",
                    "🐎","🐎",


            };
            Random random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                Console.WriteLine(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }
    }
}
