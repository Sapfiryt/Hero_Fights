using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace HeroFight
{
    public class Mage<T>:Hero where T:IRace, new()
    {
       
        public Mage(String name)
        {

            race = new T();
            rnd = new Random();
            icon = race.MageImgSrc;
            this.name = name;
            this.hp = (int)(800 * race.HPfactor);
            this.maxHp = this.hp;
            this.speed = (int)(24 * race.Speedfactor);
            this.damage = (int)(120 * race.Damagefactor);
            crit = 8;
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
        //public override string ToString()
        //{
        //    return String.Format("Mage({0}) {1} HP:{2} Damage:{3} Speed:{4}", typeof(T).Name.ToString(), this.name,this.hp,this.damage,this.speed);
       // }
    }
}
