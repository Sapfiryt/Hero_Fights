using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HeroFight
{
    public class Orcs:IRace
    {
        public double Damagefactor
        {
            get
            {
                return 0.8;
            }
        }
        /*
        public void Greating()
        {
            Console.WriteLine("Arrgh!!!");
        }
        */
        public double HPfactor
        {
            get
            {
                return 1.2;
            }
        }

        public double Speedfactor
        {
            get
            {
                return 0.8;
            }
        }

        public ImageSource ArcherImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/orc_archer.png", UriKind.Relative));
            }
        }

        public ImageSource MageImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/orc_mage.png", UriKind.Relative));
            }
        }

        public ImageSource WarriorImgSrc
        {
            get
            {
               return new BitmapImage(new Uri("Resources/orc_warrior.png", UriKind.Relative));
            }
        }
    }
}
