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

namespace SudokuBot
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Label[] LabelsArray = new Label[81];

        ref Label getLabel(int x, int y)
        {
            return ref LabelsArray[x + y * 9];
        }

        void MakeLabels()
        {
            for(int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                {
                    Label curLab = new Label();
                    getLabel(x, y) = curLab;
                    curLab.Content = "8";
                    curLab.Background = new SolidColorBrush(Colors.Green);
                    curLab.Margin = new Thickness(-252 + (x*60), -252 + (y*60), 0, 0);
                    curLab.Width = 26;
                    curLab.Height = 26;
                    grid_myGrid.Children.Add(curLab);
                }
        }

        public MainWindow()
        {
            InitializeComponent();
            MakeLabels();
        }

        private void bt_Solve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bt_Random_Click(object sender, RoutedEventArgs e)
        {
            // first fill with random numbers
            Random r = new Random();
            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                {
                    int rInt = r.Next(1, 10);
                    getLabel(x, y).Content = "" + rInt;
                }
            // then delete double in lines
            for(int curNb = 1; curNb < 10; curNb++)
                for (int x = 0; x < 9; x++)
                {
                    bool found = false;

                    for (int y = 0; y < 9; y++)
                    {
                        if((string)getLabel(x,y).Content == ""+curNb )
                        {
                            if (!found) found = true;
                            else
                            {
                                getLabel(x, y).Content = "";
                            }
                        }
                    }
                }
            // other direction
            for (int curNb = 1; curNb < 10; curNb++)
                for (int y = 0; y < 9; y++)
                {
                    bool found = false;

                    for (int x = 0; x < 9; x++)
                    {
                        if ((string)getLabel(x, y).Content == "" + curNb)
                        {
                            if (!found) found = true;
                            else
                            {
                                getLabel(x, y).Content = "";
                            }
                        }
                    }
                }
        }
    }
}
