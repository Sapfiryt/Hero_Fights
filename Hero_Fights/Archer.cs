using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HeroFight
{


    public class Archer<T>:Hero where T:IRace, new()
    {
      
        public Archer(String name)
        {
           
            race = new T();
            rnd = new Random();
            icon = race.ArcherImgSrc;

            this.name = name;
            this.hp = (int)(1000 * race.HPfactor);
            this.maxHp = this.hp;
            this.speed = (int)(18 * race.Speedfactor);
            this.damage = (int)(100 * race.Damagefactor);
            crit = 4;
            observers.Add(new DamageObserver());
            observers.NotifyObjectCreated(this);
        }

        public override void Attack(IHero enemy,bool melee)
        {

            int damage;

            int chance = rnd.Next(0,101);
            if (chance <= crit)
            {
                damage = (int)(this.Damage * 3.0);
            }
            else if (chance > crit && chance <= 16)
            {
                damage = (int)(this.Damage * 2.0);
            }
            else
            {
                damage = this.Damage;
            }
            if (melee)
                damage = (int)(damage * 0.2);
            enemy.HP -= damage;         
        }

    }
}
