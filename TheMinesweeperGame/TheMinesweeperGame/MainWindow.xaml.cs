using System;
using System.Windows;

namespace MinesweeperApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            int sizeX = int.Parse(sizeXInput.Text);
            int sizeY = int.Parse(sizeYInput.Text);

            if (sizeX >= 9 && sizeX < 30 && sizeY >= 9 && sizeY <= 30)
            {
                MineSweeper mineSweeper = new MineSweeper(sizeX, sizeY);
                mineSweeper.Calc();

                GameWindow gameWindow = new GameWindow(mineSweeper);
                gameWindow.Show();
            }
        }
    }
}
