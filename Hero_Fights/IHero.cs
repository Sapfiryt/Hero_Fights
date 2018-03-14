using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;

namespace HeroFight
{
    public interface IHero:INotifyPropertyChanged
    {
        int X
        {
            get;
            set;
        }
        ImageSource Icon
        {
            get;
        }
        int HPbar
        {
            get;
        }
        int HP
        {
            get;
            set;
        }
        int MaxHP
        {
            get;            
        }
        int CritChance
        {
            get;
        }
        int Damage
        {
            get;
            set;
        }
        int Speed
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
        void Attack(IHero enemy,bool melee);
        void Move(String dir);
        void Restore();
    }
}
