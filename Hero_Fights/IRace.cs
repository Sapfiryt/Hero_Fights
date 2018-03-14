using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HeroFight
{
    public interface IRace
    {
        ImageSource ArcherImgSrc { get; }
        ImageSource MageImgSrc { get; }
        ImageSource WarriorImgSrc { get; }
        //void Greating();

        double HPfactor { get; }
        double Speedfactor { get; }
        double Damagefactor { get; }
    }
}
