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
using System.Windows.Threading;

namespace MartinKristiansen.WpfGaming2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ellipse> points = new List<Ellipse>();
        int playerScore = 0;
        double playerLeft;
        double playerTop;
        Random rnd = new Random();
        int tickCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            lbl_Score.Content = playerScore;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(3500000);
            timer.Start();
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            playerLeft = rect_Player.Margin.Left;
            playerTop = rect_Player.Margin.Top;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            switch (tickCount)
            {
                case 1:
                    EnemyAdd();
                    EnemyMove();
                    break;
                case 2:
                    EnemyMove();
                    break;
                case 3:
                    EnemyMove();
                    break;
                case 4:
                    EnemyMove();
                    break;
                case 5:
                    EnemyMove();
                    break;
                case 6:
                    EnemyMove();
                    break;
                case 7:
                    EnemyMove();
                    break;
                default:
                    EnemyMove();
                    tickCount = 0;
                    break;
            }
        }

        private void EnemyAdd()
        {
            Ellipse newEnemy = new Ellipse();
            newEnemy.Width = 10;
            newEnemy.Height = 10;
            newEnemy.Fill = Brushes.Blue;
            newEnemy.HorizontalAlignment = HorizontalAlignment.Left;
            newEnemy.VerticalAlignment = VerticalAlignment.Top;
            newEnemy.Margin = new Thickness(rnd.Next(1, 750), 0, 0, 0);
            grd_Playground.Children.Add(newEnemy);
            points.Add(newEnemy);
        }

        private void EnemyMove()
        {
            foreach (Ellipse enemy in points)
            {
                double enemyLeft = enemy.Margin.Left;
                double enemyTop = enemy.Margin.Top;
                enemyTop = enemyTop + 10;
                enemy.Margin = new Thickness(enemyLeft, enemyTop, 0, 0);
            }
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    playerLeft = playerLeft + 20;
                    rect_Player.Margin = new Thickness(playerLeft, playerTop, 0, 0);
                    break;
                case Key.Left:
                    playerLeft = playerLeft - 20;
                    rect_Player.Margin = new Thickness(playerLeft, playerTop, 0, 0);
                    break;
                default:
                    break;
            }
        }
    }
}
