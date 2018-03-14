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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeroFight
{
    /// <summary>
    /// Логика взаимодействия для PlayerMenu.xaml
    /// </summary>
    public partial class PlayerMenu : UserControl
    {


        //Image CurrentIcon;
        IHero Player = new BaseFactory<Elfs>().CreateArcher("Name");
        String Race="Elfs";

        public PlayerMenu()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            playerImg.Source = Player.Icon;
            btnStartStory.Completed += (s, ev) => {
                Player.Name = tbName.GetLineText(0);
                (this.Parent as MainWindow).SetMainElement(new BattleField(Player));
            };
            btnWarriorStory.Completed += (s, ev) => {

                switch (Race)
                {
                    case "Orcs":
                        Player = new BaseFactory<Orcs>().CreateWarrior(tbName.GetLineText(0));
                        break;
                    case "Humans":
                        Player = new BaseFactory<Humans>().CreateWarrior(tbName.GetLineText(0));
                        break;
                    case "Elfs":
                        Player = new BaseFactory<Elfs>().CreateWarrior(tbName.GetLineText(0));
                        break;
                }

               
                playerImg.Source = Player.Icon;
            };
            btnArcherStory.Completed += (s, ev) => {

                switch (Race)
                {
                    case "Orcs":
                        Player = new BaseFactory<Orcs>().CreateArcher(tbName.GetLineText(0));
                        break;
                    case "Humans":
                        Player = new BaseFactory<Humans>().CreateArcher(tbName.GetLineText(0));
                        break;
                    case "Elfs":
                        Player = new BaseFactory<Elfs>().CreateArcher(tbName.GetLineText(0));
                        break;
                }


                playerImg.Source = Player.Icon;
            };
            btnMageStory.Completed += (s, ev) => {

                switch (Race)
                {
                    case "Orcs":
                        Player = new BaseFactory<Orcs>().CreateMage(tbName.GetLineText(0));
                        break;
                    case "Humans":
                        Player = new BaseFactory<Humans>().CreateMage(tbName.GetLineText(0));
                        break;
                    case "Elfs":
                        Player = new BaseFactory<Elfs>().CreateMage(tbName.GetLineText(0));
                        break;
                }


                playerImg.Source = Player.Icon;
            };
            btnOrcstory.Completed += (s, ev) =>
            {

                Race = "Orcs";
                Console.WriteLine(Race);

            };
            btnHumansStory.Completed += (s, ev) =>
            {

                Race = "Humans";
                Console.WriteLine(Race);

            };
            btnElfsStory.Completed += (s, ev) =>
            {

                Race = "Elfs";
                Console.WriteLine(Race);

            };
        }

    

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as MainWindow).SetMainElement(new Menu());
        }

      
    }
}
