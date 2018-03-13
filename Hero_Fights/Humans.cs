using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HeroFight
{
    public class Humans : IRace
    {
        public ImageSource ArcherImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/human_archer.png", UriKind.Relative));
            }
        }

        public ImageSource MageImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/human_mage.png", UriKind.Relative));
            }
        }

        public ImageSource WarriorImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/human_warrior.png", UriKind.Relative));
            }
        }

        public double Damagefactor
        {
            get{ 
                return 1.0;
            }
        }

     /*   public void Greating()
        {
            Console.WriteLine("Hey!");
        }
        */
        public double HPfactor
        {
            get
            {
                return 1.0;
            }
        }

        public double Speedfactor
        {
            get
            {
                return 1.0;
            }
        }
    }
}
