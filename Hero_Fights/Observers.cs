using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroFight
{
    public class Observers<T>:List<T> where T:IObserver
    {
        public void NotifyObjectCreated(Object obj)
        {
            for (IEnumerator<T> en = (IEnumerator<T>)GetEnumerator(); en.MoveNext();)
                ((T)en.Current ).ObjectCreated(obj as IHero);
        }
        public void NotifyObjectModified(Object obj)
        {
            for (IEnumerator<T> en = (IEnumerator<T>)GetEnumerator(); en.MoveNext();)
                ((T)en.Current).ObjectModified(obj as IHero);
        }
    }
}
