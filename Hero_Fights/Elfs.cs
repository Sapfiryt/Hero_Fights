using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HeroFight
{
    class Elfs:IRace
    {
        public ImageSource ArcherImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/elf_archer.png", UriKind.Relative));
            }
        }

        public ImageSource MageImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/elf_mage.png", UriKind.Relative));
            }
        }

        public ImageSource WarriorImgSrc
        {
            get
            {
                return new BitmapImage(new Uri("Resources/elf_warrior.png", UriKind.Relative));
            }
        }

        public double Damagefactor
        {
            get
            {
                return 1.2;
            }
        }
        /*
        public void Greating()
        {
            Console.WriteLine("Hello!");
        }
        */

        public double HPfactor
        {
            get
            {
                return 0.8;
            }
        }

        public double Speedfactor
        {
            get
            {
                return 1.5;
            }
        }
    }
}
