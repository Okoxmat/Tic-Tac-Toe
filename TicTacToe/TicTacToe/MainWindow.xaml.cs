using System.Linq;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Holds the current Results of cells in the active game
        /// </summary>
        private MarkType[] mResults;

        /// <summary>
        /// True if it is player 1´s turn (X) or player  2´s turn (0)
        /// </summary>
        private bool mPlayer1Turn;

        ///<summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;


        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion


        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        private void NewGame()
        {
            // Create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free; }

            //Make sure Player 1 starts the game
            mPlayer1Turn = true;

            // Interate every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            });
            // Make sure the game hasn´t finished
            mGameEnded = false;
        }
        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }
            //Cast the sender to a button
            var button = (Button)sender;

            //Find the buttons positions in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);
            //Don´t do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free)
                return;


            //Set the cells value based on which Player turn it is
            if (mPlayer1Turn)
                mResults[index] = MarkType.Cross;
            else
                mResults[index] = MarkType.Nought;

            //Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";

            //Change noughts to green
            if (!mPlayer1Turn)
                button.Foreground = Brushes.ForestGreen;
            else
                button.Foreground = Brushes.OrangeRed;



            //Toggle the players turns
            if (mPlayer1Turn)
                mPlayer1Turn = false;
            else
                mPlayer1Turn = true;

            //Check for a winner
            CheckForWinner();
        }

        /// <summary>
        /// Checks if there is a winner of a 3 line straight
        /// </summary>
            private void CheckForWinner()
            {
                //Check for horizontal wins
                //
                // -row 0
                //
                if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.LightGreen;
            }
                //
                // -row 1
                //
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.LightGreen;
            }
                 //
                 // -row 2
                 //
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.LightGreen;
            }

            //Check for vertical wins
            //
            // -Column 0
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.LightGreen;
            }
            //
            // -Column 1
            //
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.LightGreen;
            }
            //
            // -Column 2
            //
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.LightGreen;
            }

            //Check for diagonal wins
            //
            // -diagonal 1
            //
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.LightGreen;
            }
            //
            // -diagonal 2
            //
            if (mResults[2] != MarkType.Free && (mResults[4] & mResults[6] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.LightGreen;
            }

            //Check for no Winner
            
                if (!mGameEnded&&!mResults.Any(result => result == MarkType.Free))
                {
                    // Game ended
                    mGameEnded = true;

                    //Turn all cells orange
                    Container.Children.Cast<Button>().ToList().ForEach(button =>
                    {
                        button.Background = Brushes.DarkOrange;

                    });
                }
            
        }   
    }
}
