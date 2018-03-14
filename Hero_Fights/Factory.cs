using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
   public abstract class Factory<T> where T : IRace, new()
    {
        public Mage<T> CreateMage(String name)
        {
            return new Mage<T>(name);
        }
        public Archer<T> CreateArcher(String name)
        {
            return new Archer<T>(name);
        }
        public Warrior<T> CreateWarrior(String name)
        {
            return new Warrior<T>(name);
        }

       
    }
}
