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
    public class Warrior<T> : Hero where T : IRace, new()
    {

        public Warrior(String name)
        {
            race = new T();
            rnd = new Random();
            icon = race.WarriorImgSrc;

            this.name = name;
            this.hp = (int)(1200 * race.HPfactor);
            this.maxHp = hp;
            this.speed = (int)(12 * race.Speedfactor);
            this.damage = (int)(80 * race.Damagefactor);
            crit = 2;

            observers.Add(new DamageObserver());
            observers.NotifyObjectCreated(this);
        }

        public override void Attack(IHero enemy, bool melee)
        {
           
            int damage;
            if (melee)
            {
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
                enemy.HP -= damage;
            }
        }
    }
}
