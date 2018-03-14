using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HeroFight
{
    public abstract class Hero:IHero
    {
        protected int x;
        protected int hp;
        protected int maxHp;
        protected int speed;
        protected int damage;
        protected string name;
        protected int crit;
        protected IRace race;
        protected Random rnd;
        protected ImageSource icon;
        protected Observers<IObserver> observers = new Observers<IObserver>();
        public event PropertyChangedEventHandler PropertyChanged;

        public int X
        {
            get
            {
                
                return x;
            }
            set
            {
                x = (value >= 0 && value <= 100) ? value : (value > 100) ? 100 : 0;
            }
        }
        public int HP
        {
            get
            {
                return hp;
            }

            set
            {
                hp = value > 0 ? value : 0;
                observers.NotifyObjectModified(this);
                OnPropertyChanged("HPbar");
            }
        }

        public int MaxHP
        {
            get
            {
                return maxHp;
            }

        }
        public int CritChance
        {
            get
            {
                return crit;
            }
        }
        public int Damage
        {
            get
            {
                return (int)(damage*(1.0+rnd.NextDouble()*0.1));
            }

            set
            {
                damage = value > 0 ? value : 0;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value > 0 ? value : 0;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public ImageSource Icon
        {
            get
            {
                return icon;
            }
        }

        public int HPbar
        {
            get
            {
                return hp * 300 / maxHp;
            }
        }

        

        public virtual void Attack(IHero enemy,bool melee)
        {

            int damage;

            int chance = rnd.Next(101);
            if (chance <= crit)
            {
                damage = (int)(this.damage * 3.0);
            }
            else if (chance > crit && chance <= 20)
            {
                damage = (int)(this.damage * 2.0);
            }
            else
            {
                damage = this.damage;
            }
            enemy.HP -= damage;
        }

        public void Move(String dir)
        {
            if (dir.Equals("Left"))
            {
                this.X -= this.Speed;
            }else if (dir.Equals("Right"))
            {
                this.X += this.Speed;
            }
        }
        private void OnPropertyChanged(String args)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(args));
            };
        }

        public void Restore()
        {
            this.HP = this.MaxHP;
            
        }
    }
}
