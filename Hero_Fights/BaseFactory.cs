using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
    public class BaseFactory<T>:Factory<T> where T:IRace, new()
    {
        public new Mage<T> CreateMage(String name)
        {
            return new Mage<T>(name);
        }
        public new Archer<T> CreateArcher(String name)
        {
            return new Archer<T>(name);
        }
        public new Warrior<T> CreateWarrior(String name)
        {
            return new Warrior<T>(name);
        }

        public List<IHero> CreateAll(String[] names)
        {
            List<IHero> list = new List<IHero>();
            list.Add(CreateArcher(names[0]));
            list.Add(CreateMage(names[0]));
            list.Add(CreateWarrior(names[0]));

            return list;
        }
    }
}
