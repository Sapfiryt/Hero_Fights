using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
    public class DamageObserver : IObserver
    {
        int currentHP;
        public void ObjectCreated(IHero hero)
        {
            currentHP = hero.HP;
        }

        public void ObjectModified(IHero hero)
        {
            var damage = hero.HP - currentHP;
            currentHP = hero.HP;
            if(damage<0)
                BattleField.strLog += String.Format("\nHero {0} damaged on: {1}", hero.Name, damage);
            //Console.WriteLine(String.Format("Hero {0} damaged on: {1}",hero.Name,damage));
        }
    }
}
