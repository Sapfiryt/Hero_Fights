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

namespace HeroFight
{
    /// <summary>
    /// Логика взаимодействия для BattleField.xaml
    /// </summary>
    public partial class BattleField : UserControl
    {
         
        Battle battle;
        public static string strLog="Battle Begin:\n";
       

        public String BattleLog
        {
            get
            {
                return strLog;
            }
        }
        public IHero Player
        {
            get
            {
                return battle.Player;
            } 
        }
        public IHero Enemy
        {
            get
            {
                return battle.Enemy;
            }
        }
        public int PlayerX
        {
            get
            {
                return (int)(Player.X * (topField.ActualWidth - 60 - playerImage.ActualWidth) / 100.0);
            }
        }
        public int EnemyX
        {
            get
            {
                return (int)((Enemy.X-100) * (topField.ActualWidth - 60 - enemyImage.ActualWidth) / 100.0);
            }
        }


        public BattleField(IHero Player)
        {

            battle = new Battle(Player);

            strLog = "Battle Begin:\n";

            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            log.Text = strLog;

            
            btnAttack.IsEnabled = false;
            btnLeft.IsEnabled = false;
            btnRight.IsEnabled = false;

            playerHPBar.DataContext = Player;
            enemyHPBar.DataContext = Enemy;

            playerImage.Source = Player.Icon;
            enemyImage.Source = Enemy.Icon;
            playerName.Text = Player.Name;
            enemyName.Text = Enemy.Name;


            enemyTranslate.X = EnemyX;
            playerTranslate.X = PlayerX;


            imgFightStory.Completed += (s, ea) =>
            {
                fight.Opacity = 0.0;
                btnAttack.IsEnabled = true;
                btnLeft.IsEnabled = true;
                btnRight.IsEnabled = true;

                battle.BeginBattle();
            };

        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            CheckDistance();

            battle.Turn();

            log.Text = strLog;
            logScroller.ScrollToEnd();

            enemyTranslate.X = EnemyX;
            playerTranslate.X = PlayerX;

            
            CheckForEnd();
            

        }

        private void CheckDistance()
        {
           
            if (Math.Abs(topField.ActualWidth - 60 - playerTranslate.X - enemyTranslate.X - playerImage.ActualWidth) < playerImage.ActualWidth * 3 / 4)
                battle.Melee();
            else
                battle.Range();
        }

        private void CheckForEnd()
        {
            MessageBoxResult res = MessageBoxResult.None;
            if (battle.isEnded())
            {

                if (battle.isTie)
                {
                    res = MessageBox.Show("Wanna repeat???", "Tie!", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                }
                else
                {
                    if (battle.isWin)
                    {
                        res = MessageBox.Show("You Win!", "Fight Result", MessageBoxButton.OK, MessageBoxImage.Question);

                    }
                    else if (battle.isLose)
                    {
                        res = MessageBox.Show("You Lose!\nGood day,sir!", "You get nothing!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                }
                if (res == MessageBoxResult.OK)
                {
                    (Parent as MainWindow).SetMainElement(new Menu());
                }
                else if (res == MessageBoxResult.Cancel)
                {
                    this.Reload();
                }
            }
        }

        private void Reload()
        {
            battle.Restart();


            fight.Opacity = 1.0;
            Console.WriteLine(fight.Opacity);
            btnAttack.IsEnabled = false;
            btnLeft.IsEnabled = false;
            btnRight.IsEnabled = false;

            enemyTranslate.X = EnemyX;
            playerTranslate.X = PlayerX;

            strLog = "Battle Begin:\n";
            log.Text = strLog;
            imgFightStory.Begin();
           
                     
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            battle.PlayerMoveLeft();
            playerTranslate.X = PlayerX;
           
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            battle.PlayerMoveRight();
            playerTranslate.X = PlayerX;
        }

       
    }
}
