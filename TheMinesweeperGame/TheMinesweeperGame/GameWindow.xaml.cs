using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MinesweeperApp
{
    public partial class GameWindow : Window
    {
         MineSweeper mineSweeper;
        Grid fieldGrid = new Grid();


        public GameWindow(MineSweeper mineSweeper)
        {
            InitializeComponent();
            this.mineSweeper = mineSweeper;
            GenerateField();
        }
        
        private void GenerateField()
        {
            for (int i = 0; i < mineSweeper.mineSweeperFields.Length; i++)
            {
                fieldGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j < mineSweeper.mineSweeperFields[0].Length; j++)
            {
                fieldGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < mineSweeper.mineSweeperFields.Length; i++)
            {
                for (int j = 0; j < mineSweeper.mineSweeperFields[0].Length; j++)
                {
                    Button button = new Button();
                    button.Tag = new int[2] { i, j }; // Store row and column indices
                    button.Click += Button_Click;
                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    fieldGrid.Children.Add(button);
                }
            }
     
            this.Content = fieldGrid;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int[] position = button.Tag as int[];
            int row = position[0];
            int col = position[1];
            var x = mineSweeper;
            var field = mineSweeper.mineSweeperFields[row][col];
            if (field != null)
            {
                // Change button content to an image based on the number of mines
                int mines = field.NeighbourMines;
                if (mines >= 0&&!field.Mine())
                {
                    
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/img/"+mines+".png"));
                    button.Content = image;
                }
                else
                {
                    Image image = new Image();
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/img/bomb.png"));
                    button.Content = image;
                    foreach(Button b in fieldGrid.Children)
                    {
                        b.IsEnabled = false;
                    }
                }
                button.IsEnabled = false;

            }
        }
    }
}
