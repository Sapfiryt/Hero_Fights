using System;
using System.Collections.Generic;

namespace HeroFight
{
    public class Battle
    {
        private IHero player;
        private IHero enemy;
        private bool moved;
        private bool onBattle;
        private bool win;
        private bool tie;
        private bool lose;
        private bool melee;
        private Random rand;
        private List<IHero> enemyList = new List<IHero>();
        private String[] names = {
            "Иснадил", "Дихалион", "Арарендор", "Барам","Басилнон","Халедил", "Турбринин", "Эльголир", "Ольринан", "Маанеф", "Маэдбримин", "Кагорм", "Прушнак", "Хок", "Грувык", "Годаш", "Мокай", "Агукай"
        };

        public bool isWin { get { return win; }}
        public bool isLose { get { return lose; }}
        public bool isTie { get { return tie; }}
        public bool isMoved { get { return moved; } }
        public IHero Player { get { return player; }}
        public IHero Enemy { get { return enemy; }}

        public Battle(IHero player)
        {
            rand = new Random();
            LoadEnemies();

            this.win = false;
            this.tie = false;
            this.lose = false;

            this.moved = false;
           
            this.player = player;
            this.enemy = enemyList[rand.Next(0,enemyList.Count)];

            this.player.X = 0;
            this.enemy.X = 100;
        }

        private void LoadEnemies()
        {
            BaseFactory<Orcs> orcs = new BaseFactory<Orcs>();
            BaseFactory<Humans> humans = new BaseFactory<Humans>();
            BaseFactory<Elfs> elfs = new BaseFactory<Elfs>();

            enemyList.AddRange(elfs.CreateAll(CreateNameSet()));
            enemyList.AddRange(humans.CreateAll(CreateNameSet()));
            enemyList.AddRange(orcs.CreateAll(CreateNameSet()));
        }

        private string[] CreateNameSet()
        {
            String[] enemyNames = new String[3];
           
            for (int i = 0; i < enemyNames.Length; i++)
                enemyNames[i] = names[rand.Next(0, names.Length)];
            return enemyNames;
        }

        public void BeginBattle()
        {
            onBattle = true;
        }

        public bool isEnded()
        {

            if (onBattle) {
                if (player.HP == 0)
                {
                    if (enemy.HP == 0) { 

                      
                        tie = true;
                        onBattle = false;
                    }
                    else
                    {
                       
                        lose = true;
                        onBattle = false;
                    }
                    
                }else if (enemy.HP==0)
                {
                    
                    win = true;
                    onBattle = false;
                }
            }
            return !onBattle;
        }

        public void Turn()
        {
            player.Attack(enemy,melee);
            enemy.Attack(player,melee);
            this.moved = false;
        }

        public void Restart()
        {
            win = false;
            tie = false;
            lose = false;
            player.Restore();
            enemy.Restore();
            player.X = 0;
            enemy.X = 100;
        }

        internal void Range()
        {
            this.melee = false;
        }

        internal void Melee()
        {
            this.melee = true;
        }

        public void PlayerMoveRight()
        {
            if (!this.moved)
            {
                this.moved = true;
                this.player.Move("Right");
            }
        }

        public void PlayerMoveLeft()
        {
            if (!this.moved)
            {
                this.moved = true;
                this.player.Move("Left");
            }
        }

    }
}