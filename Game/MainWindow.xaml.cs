using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        GameLogic _GameLogic = new GameLogic();

        private void PlayerClicksSpace(object sender, RoutedEventArgs e)
        {
            Button space = (Button)sender;
            //If the button content is not empty, it means it has already been clicked
            if (!string.IsNullOrWhiteSpace(space.Content?.ToString()))
            {
                return;
            }
            //If the button content is empty, set x first, and x or o depending on conditions
            else
            {
                //Display X first
                space.Content = _GameLogic.CurrentPlayer;
                //Set coordinates
                //It retrieves the coordinates of the button that was clicked from the Tag property of the Button control.
                var coordinates = space.Tag.ToString().Split(',');
                //It splits the coordinates string into an array of two integers, x and y.
                var x = int.Parse(coordinates[0]);
                var y = int.Parse(coordinates[1]);
                //It creates a Position object with the x and y coordinates.
                Position buttonPosition = new Position (x,y);
                //It updates the Board array at the x and y coordinates with the current player's symbol, either "X" or "O", now X or O has Board x and y coordinates.
                //e.g. (0,1)
                _GameLogic.UpdateBoard(buttonPosition, _GameLogic.CurrentPlayer);

            }
            //Check if a player has won the game
            if (_GameLogic.PlayerWin())
            {
                MessageBox.Show("Congrats! " +_GameLogic.CurrentPlayer + " Player, You Win The Game!"); //Exit early since the game is over
            }
            //Check for draw
            else if (_GameLogic.BoardFull())
            {
                MessageBox.Show("The game is a draw!");
            }

            //If the game is not over, set up the next player
            _GameLogic.SetNextPlayer();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (var element in grid.Children)
            {
                if (element is Button)
                {
                    Button button = (Button)element;
                    button.Content = string.Empty;
                }
            }

            _GameLogic = new GameLogic();
        }




    }



}

