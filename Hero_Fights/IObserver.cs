using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
    public interface IObserver
    {
        void ObjectCreated(IHero hero);
        void ObjectModified(IHero hero);
    }
}
